namespace SharpSPARQL {

    using System.Windows.Forms;

    /// <summary>
    /// ResultDialog is a Dialog/Form that is used to display
    /// the results from the last query in a seperate window.
    /// </summary>
    public partial class ResultDialog : Form {

        /// <summary>
        /// Constructs a new ResultDialog and initializes the
        /// Windows Form components. 
        /// </summary>
        public ResultDialog() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the last run QueryWorker that has ran.
        /// </summary>
        internal QueryWorker Result { get; set; }

        /// <summary>
        /// Overrides the default ShowDialog method to set the last
        /// ran query to display in a textbox.
        /// </summary>
        /// <returns>DialogResult, will always be the same.</returns>
        public new DialogResult ShowDialog() {
            this.Clear();
            this.tbResult.AppendText(this.Result.Result.ToString());
            return base.ShowDialog();
        }

        /// <summary>
        /// Clears the inner text box before appending the new results.
        /// </summary>
        private void Clear() {
            this.tbResult.Clear();
        }
    }
}
