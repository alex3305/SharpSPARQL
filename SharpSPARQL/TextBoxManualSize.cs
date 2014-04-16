namespace SharpSPARQL {

    using System.Windows.Forms;

    /// <summary>
    /// TextBox with manual height size control without
    /// multiline enabled. This is normally not possible
    /// thus is the default TextBox overriden with this 
    /// property enabled.
    /// </summary>
    class TextBoxManualSize : TextBox {

        /// <summary>
        /// Constructs a new TextBox with manual height
        /// size control. 
        /// </summary>
        public TextBoxManualSize() : base() {
            this.AutoSize = false;
        }
    }
}
