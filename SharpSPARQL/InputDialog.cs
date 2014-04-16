namespace SharpSPARQL {

    using System;
    using System.Windows.Forms;

    /// <summary>
    /// InputDialog class that is used to display a dialog inside
    /// this application to enter a name for the query.
    /// </summary>
    public partial class InputDialog : Form {
        
        /// <summary>
        /// Constructs a new InputDialog and initializes the 
        /// Windows Form components. 
        /// </summary>
        public InputDialog() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the name of the query that the user has
        /// inputted in the text field.
        /// </summary>
        public string QueryName {
            get { return this.tbName.Text; }
        }

        /// <summary>
        /// Event that is triggered when the Create-button inside the 
        /// dialog is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnCreate_Click(object sender, EventArgs e) {
            if (this.tbName.Text.Equals(string.Empty)) {
                this.tbName.Text = "Query";
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Event that is triggered when the Cancel-button inside the
        /// dialog is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments</param>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
