namespace SharpSPARQL {

    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// QueryWorker class that is used to start a new thread (as a
    /// BackgroundWorker) and connect to the server to benchmark.
    /// </summary>
    class QueryWorker {

        /// <summary>
        /// BackgroundWorker that has nice threading and such...
        /// </summary>
        private BackgroundWorker _worker = new BackgroundWorker();

        /// <summary>
        /// Constructs a new QueryWorker without a parent.
        /// </summary>
        public QueryWorker() : this(null) { }

        /// <summary>
        /// Constructs a new QueryWorker with a parent to invoke
        /// some stuff on and update a Windows Forms application.
        /// </summary>
        /// <param name="parent">Parent to invoke on</param>
        public QueryWorker(MainForm parent) {
            this.Parent = parent;

            this._worker.DoWork += new DoWorkEventHandler(this.DoQuery);
            this.QueryTimer = new Stopwatch();
            this.Result = new StringBuilder();
        }

        /// <summary>
        /// Gets a formatted TimeSpan (in milliseconds).
        /// </summary>
        public string FormattedTimespan {
            get { return this.QueryTimer.ElapsedMilliseconds.ToString(); }
        }

        /// <summary>
        /// Gets or sets the current iteration.
        /// </summary>
        public int Iteration { get; set; }

        /// <summary>
        /// Gets the parent of this worker to invoke Windows Forms
        /// stuff on.
        /// </summary>
        public MainForm Parent { get; private set; }

        /// <summary>
        /// Gets or sets the query that has to be run.
        /// </summary>
        public Query Query { get; set; }

        /// <summary>
        /// Gets an exception if any has occured during the
        /// query execution.
        /// </summary>
        public Exception QueryException { get; private set; }

        /// <summary>
        /// Gets the QueryTimer that can be used to calculate the
        /// query length.
        /// </summary>
        public Stopwatch QueryTimer { get; private set; }

        /// <summary>
        /// Gets the result as a StringBuilder that can be used to
        /// display the result somewhere, somehow.
        /// </summary>
        public StringBuilder Result { get; private set; }

        /// <summary>
        /// Event that is triggered when the BackgroundWorker
        /// has been started and this is will run a Webrequest
        /// against the given Endpoint with the given Query. 
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void DoQuery(object sender, DoWorkEventArgs e) {
            this.QueryTimer.Start();

            HttpWebRequest webrequest = null;
            HttpWebResponse response = null;
            StreamReader reader = null;

            try {
                if (this.Query.Endpoint.EndsWith(@"/")) {
                    this.Query.Endpoint = this.Query.Endpoint.Remove(this.Query.Endpoint.Length - 1);
                }

                // Escape new lines. 
                var queryString = WebUtility.UrlEncode(this.Query.SPARQLQuery.Replace("\n", " "));
                byte[] postData = Encoding.UTF8.GetBytes("query=" + queryString);

                webrequest = WebRequest.Create(this.Query.Endpoint) as HttpWebRequest;

                webrequest.Accept = "application/sparql-results+json";
                webrequest.ContentLength = postData.Length;
                webrequest.ContentType = "application/x-www-form-urlencoded";
                webrequest.Credentials = CredentialCache.DefaultCredentials;
                webrequest.Method = "POST";
                webrequest.Proxy = null; // Very important to eliminate delay in the first request!
                webrequest.Timeout = 600000; // Timeout of 10 minutes per request :).

                Stream dataStream = webrequest.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();

                response = webrequest.GetResponse() as HttpWebResponse;

                var stream = response.GetResponseStream();
                reader = new StreamReader(stream);

                string line = string.Empty;
                while ((line = reader.ReadLine()) != null) {
                    this.Result.AppendLine(line);
                }

                this.QueryTimer.Stop();
            } catch (Exception exc) {
                this.QueryException = exc;
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
                this.QueryTimer.Stop();
            } finally {
                this.QueryTimer.Stop();
                
                if (reader != null) reader.Close();
                if (response != null) response.Close();
            }

            if (this.Parent != null) { this.Parent.InvokeUpdate(this); }
        }

        /// <summary>
        /// Locks the required objects and starts a new thread
        /// with the query. This method will also lock the properties
        /// QueryTimer, Query and Result.
        /// </summary>
        public void Run() {
            lock (this.QueryTimer) lock (this.Query) lock (this.Result) {
                this._worker.RunWorkerAsync();
            }
        }
    }
}
