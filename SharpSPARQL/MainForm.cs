namespace SharpSPARQL {

    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    /// MainForm class that contains the central GUI for this
    /// application. 
    /// </summary>
    public partial class MainForm : Form {

        /// <summary>
        /// Default QueryFile that will be used to save and load
        /// queries.
        /// </summary>
        private static string QueryFile = System.Environment.CurrentDirectory + @"\Queries.xml";

        /// <summary>
        /// Total time that took all the queries to run. 
        /// </summary>
        private TimeSpan _totalTime = TimeSpan.Zero;

        /// <summary>
        /// List of workers. This is necessary to know if all the
        /// workers are done.
        /// </summary>
        private List<QueryWorker> _workers = new List<QueryWorker>();

        /// <summary>
        /// Highlight style to highlight all the keywords.
        /// </summary>
        private Style _styleBlue = new TextStyle(Brushes.Blue, null, FontStyle.Regular);

        /// <summary>
        /// Highlight style to highlight all the parenthesis.
        /// </summary>
        private Style _styleDarkGold = new TextStyle(Brushes.DarkGoldenrod, null, FontStyle.Regular);

        /// <summary>
        /// Highlight style to highlight all the uri's.
        /// </summary>
        private Style _styleDarkRed = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);

        /// <summary>
        /// Highlight style to highlight all the SPARQL variables.
        /// </summary>
        private Style _styleGreen = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        /// <summary>
        /// Regex to syntax highlight all the keywords.
        /// </summary>
        private Regex _rKeywords;

        /// <summary>
        /// Regex to syntax highlight the parenthesis.
        /// </summary>
        private Regex _rParenthesis;

        /// <summary>
        /// Regex to syntax highlight SPARQL uri's.
        /// </summary>
        private Regex _rUris;

        /// <summary>
        /// Regex to syntax highlight SPARQL variables.
        /// </summary>
        private Regex _rVariables;

        /// <summary>
        /// Constructs a new MainForm with all the Windows Forms
        /// components and also initializes the syntax highlighting.
        /// </summary>
        public MainForm() {
            this.AddRegex();
            this.InitializeComponent();
            this.GetSavedQueries();

            this.btnResult.Enabled = false;
            this.Result = new ResultDialog();

            // TODO ThreadPool instead of backgroundworkers!?
            //               ~ could stop threads if necessary
            //               ~ handles pooling better than a list.
            if (this.Queries.Count <= 0) { this.btnDelete.Enabled = false; }
        }

        /// <summary>
        /// Gets or sets the list of saved queries.
        /// </summary>
        private List<Query> Queries { get; set; }

        /// <summary>
        /// Gets or sets the result dialog to display the last result.
        /// </summary>
        private ResultDialog Result { get; set; }

        /// <summary>
        /// Invokes an update on this Form from another thread and set
        /// the appropiate values from the set QueryWorker.
        /// </summary>
        /// <param name="qw">QueryWorker to invoke from.</param>
        internal void InvokeUpdate(QueryWorker qw) {
            this.Invoke(new Action(() => {
                this._workers.Remove(qw);

                if (qw.QueryException != null) {
                    this.tbTimes.Text = qw.QueryException.Message;
                    this._totalTime = TimeSpan.Zero;

                    this.lblStatus.Text = "Idle";
                    this.btnQuery.Enabled = true;
                    this.numQueryCount.Enabled = true;

                    return;
                }

                this.tbResult.AppendText(string.Format("  Run {0}: {1} ms{2}",
                    qw.Iteration + 1, qw.FormattedTimespan, Environment.NewLine));

                this._totalTime = this._totalTime.Add(qw.QueryTimer.Elapsed);

                if (this._workers.Count == 0) {
                    var totalTime = string.Format("{0:00}:{1:00}.{2:00}", this._totalTime.Minutes, this._totalTime.Seconds, this._totalTime.Milliseconds);
                    var average = this._totalTime.TotalMilliseconds / (int)this.numQueryCount.Value;

                    this.tbTimes.Clear();
                    this.tbTimes.AppendText(string.Format("Total time:    {0}{1}", totalTime, Environment.NewLine));
                    this.tbTimes.AppendText(string.Format("Average query: {0} ms", average.ToString("#.##")));

                    this.Result.Result = qw;
                    this._totalTime = TimeSpan.Zero;

                    this.lblStatus.Text = "Idle";
                    this.btnResult.Enabled = true;
                    this.btnQuery.Enabled = true;
                    this.numQueryCount.Enabled = true;
                }
            }));
        }

        /// <summary>
        /// Adds the right regular expressions to apply syntax highlighting
        /// to.
        /// </summary>
        private void AddRegex() {
            // Manually build keyword regex because each word should be unique and escaped...
            string keywordRegex = string.Empty;
            string[] keywords = { "SELECT", "CONSTRUCT", "ASK", "DESCRIBE", "BASE", "PREFIX", "PREFIX:", 
                                    "DISTINCT", "FROM", "WHERE", "NAMED", "ORDER", "BY", "ASC", "DESC", 
                                    "LIMIT", "OFFSET", "OPTIONAL", "GRAPH", "UNION", "FILTER", "COUNT", 
                                    "AVG", "MIN", "MAX", "SUM", "LIKE", "IN", "INSERT", "DELETE", "MODIFY",
                                    "INTO", "DATA", "GROUP"};

            foreach (var keyword in keywords) { keywordRegex += string.Concat(@"\b", keyword, @"\b|"); }

            this._rKeywords = new Regex(keywordRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            this._rVariables = new Regex(@"\?(\w*)?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            this._rUris = new Regex(@"(\<([^\>]+)\>)|\""([^\""]+)\""", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            this._rParenthesis = new Regex(@"\{|\}|\[|\]|\(|\)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }

        /// <summary>
        /// Gets the saved queries from the XML file or creates a new
        /// XML file when no file exists. 
        /// </summary>
        private void GetSavedQueries() {
            if (File.Exists(MainForm.QueryFile)) {
                this.Queries = XmlSerialization.ReadFromXmlFile<List<Query>>(MainForm.QueryFile);
            } else {
                this.Queries = new List<Query>();
                this.Queries.Add(new Query() { Name = "Query", Endpoint = "http://", SPARQLQuery = "" });
                XmlSerialization.WriteToXmlFile<List<Query>>(MainForm.QueryFile, this.Queries, false);
            }

            this.InvalidateDataSource();
        }

        /// <summary>
        /// Invalidates the DataSource for the Combobox that holds
        /// the list of queries that were saved and are now in memory.
        /// </summary>
        private void InvalidateDataSource() {
            this.cbQueries.DataSource = null;
            this.cbQueries.DataSource = this.Queries;
            this.cbQueries.DisplayMember = "Name";
            this.cbQueries.SelectedIndex = this.Queries.Count - 1;
        }

        /// <summary>
        /// Event that is triggered when the delete button is either enabled 
        /// or disabled. We do this because of fancy colouring in our form.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnDelete_EnabledChanged(object sender, EventArgs e) {
            if (this.Queries.Count <= 0) {
                this.btnQuery.Enabled = false;
                this.btnSave.Enabled = false;
            } else {
                this.btnQuery.Enabled = true;
                this.btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// Event that is triggered when the New-button has been clicked
        /// and a new Query is created. 
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnNew_Click(object sender, EventArgs e) {
            var dialog = new InputDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK) {
                this.Queries.Add(new Query() { Name = dialog.QueryName, 
                    SPARQLQuery = string.Empty, Endpoint = "http://" });
            }

            dialog.Close();
            dialog.Dispose();

            this.cbQueries_Click(null, null);
            this.InvalidateDataSource();
        }

        /// <summary>
        /// Event that is triggered when the Delete button has been
        /// clicked and this deletes a Query.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnDelete_Click(object sender, EventArgs e) {
            this.Queries.Remove((Query)this.cbQueries.SelectedItem);
            this.InvalidateDataSource();

            if (this.Queries.Count <= 0) {
                this.btnDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Event that is triggered when the selection on the combobox
        /// is changed. After it has been changed we get the new Query from
        /// memory.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void cbQueries_SelectedIndexChanged(object sender, EventArgs e) {
            this.btnDelete.Enabled = true;

            if (this.cbQueries.SelectedIndex >= 0) {
                this.tbEndpoint.Text = this.Queries[this.cbQueries.SelectedIndex].Endpoint;
                this.tbFastColored.Text = this.Queries[this.cbQueries.SelectedIndex].SPARQLQuery;
            }
        }

        /// <summary>
        /// Event that is triggered when the combobox is clicked. We do this 
        /// because we really, really want to save the current query to 
        /// memory... Or else it will be lost FOREVER!
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void cbQueries_Click(object sender, EventArgs e) {
            if (this.cbQueries.SelectedIndex >= 0) {
                this.Queries[this.cbQueries.SelectedIndex].Endpoint = this.tbEndpoint.Text;
                this.Queries[this.cbQueries.SelectedIndex].SPARQLQuery = this.tbFastColored.Text;
            }
        }

        /// <summary>
        /// Event that is triggered when the Save button is clicked
        /// and this will serialize the queries to disk. 
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnSave_Click(object sender, EventArgs e) {
            this.cbQueries_Click(null, null);
            XmlSerialization.WriteToXmlFile<List<Query>>(MainForm.QueryFile, this.Queries, false);
            MessageBox.Show(this, "Query file saved.", "File saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event that is triggered when the Query button is clicked. This
        /// is one of the most important methods of our application and
        /// will start a new BackgroundWorker to run the query. 
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnQuery_Click(object sender, EventArgs e) {
            if (!Uri.IsWellFormedUriString(this.tbEndpoint.Text, UriKind.Absolute)) {
                MessageBox.Show(this, "This endpoint is an invalid URI.", "Invalid URI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.cbQueries_Click(null, null);
            this.btnResult.Enabled = false;
            this.btnQuery.Enabled = false;
            this.numQueryCount.Enabled = false;
            this.tbResult.Clear();
            this.tbTimes.Clear();
            this.lblStatus.Text = "Running...";

            this.tbResult.Text = string.Format("{0} [{1}]{2}",
                this.Queries[this.cbQueries.SelectedIndex].Name, this.numQueryCount.Value.ToString(),
                Environment.NewLine);

            for (int i = 0; i < this.numQueryCount.Value; i++) {
                var qw = new QueryWorker(this) { Query = this.Queries[this.cbQueries.SelectedIndex], Iteration = i };
                this._workers.Add(qw);
                qw.Run();
            }
        }

        /// <summary>
        /// Event that is triggered when the Result button is clicked. This
        /// will open a new window with the query result.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnResult_Click(object sender, EventArgs e) {
            this.Result.ShowDialog();
        }

        /// <summary>
        /// Event that is triggered when the text is changed in the
        /// fast colored syntax highlighter. 
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void tbFastColored_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(new Style[] { this._styleBlue, this._styleDarkGold, this._styleDarkRed, this._styleGreen });

            e.ChangedRange.SetStyle(this._styleGreen, this._rVariables);
            e.ChangedRange.SetStyle(this._styleBlue, this._rKeywords);
            e.ChangedRange.SetStyle(this._styleDarkRed, this._rUris);
            e.ChangedRange.SetStyle(this._styleDarkGold, this._rParenthesis);
        }

        /// <summary>
        /// Main entry point of our application that will start the
        /// Windows Form and DO MAGIC!
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}