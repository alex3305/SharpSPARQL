namespace SharpSPARQL {

    using System;

    /// <summary>
    /// Serializable query class that can be used to save
    /// and load queries from disk. 
    /// </summary>
    [Serializable]
    public class Query {

        /// <summary>
        /// Gets or sets the endpoint URL.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the name of the query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the query itself.
        /// </summary>
        public string SPARQLQuery { get; set; }

    }
}
