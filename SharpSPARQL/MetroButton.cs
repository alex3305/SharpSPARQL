namespace SharpSPARQL {

    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// MetroButton class which extends a regular button but has
    /// a nice, flat display style.... Not by default?! No this is
    /// actually a class to display a nice backgroundcolor.
    /// </summary>
    public partial class MetroButton : Button {

        /// <summary>
        /// Gets or sets a value whether the control is enabled. This will
        /// also influence the backgroundcolor.
        /// </summary>
        public new bool Enabled {
            get { return base.Enabled; }
            set {
                base.Enabled = value;
                this.BackColor = (base.Enabled) ? this.OriginalColor : Color.DarkGray;
            }
        }

        /// <summary>
        /// Gets or sets the original color for this control.
        /// </summary>
        public Color OriginalColor { get; set; }
    }
}
