namespace SharpSPARQL {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlQuery = new System.Windows.Forms.Panel();
            this.tbFastColored = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cbQueries = new System.Windows.Forms.ComboBox();
            this.pnlQueries = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbTimes = new System.Windows.Forms.TextBox();
            this.numQueryCount = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnResult = new SharpSPARQL.MetroButton();
            this.tbEndpoint = new SharpSPARQL.TextBoxManualSize();
            this.btnSave = new SharpSPARQL.MetroButton();
            this.btnDelete = new SharpSPARQL.MetroButton();
            this.btnNew = new SharpSPARQL.MetroButton();
            this.btnQuery = new SharpSPARQL.MetroButton();
            this.pnlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFastColored)).BeginInit();
            this.pnlQueries.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueryCount)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlQuery
            // 
            this.pnlQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuery.Controls.Add(this.tbFastColored);
            this.pnlQuery.Location = new System.Drawing.Point(354, 58);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(614, 477);
            this.pnlQuery.TabIndex = 3;
            // 
            // tbFastColored
            // 
            this.tbFastColored.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.tbFastColored.AutoScrollMinSize = new System.Drawing.Size(31, 23);
            this.tbFastColored.BackBrush = null;
            this.tbFastColored.CharHeight = 23;
            this.tbFastColored.CharWidth = 10;
            this.tbFastColored.CommentPrefix = "#";
            this.tbFastColored.CurrentLineColor = System.Drawing.Color.LightBlue;
            this.tbFastColored.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFastColored.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbFastColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFastColored.Font = new System.Drawing.Font("Consolas", 10.8F);
            this.tbFastColored.ForeColor = System.Drawing.Color.Black;
            this.tbFastColored.IndentBackColor = System.Drawing.Color.Snow;
            this.tbFastColored.IsReplaceMode = false;
            this.tbFastColored.LineInterval = 2;
            this.tbFastColored.LineNumberColor = System.Drawing.Color.SteelBlue;
            this.tbFastColored.Location = new System.Drawing.Point(0, 0);
            this.tbFastColored.Name = "tbFastColored";
            this.tbFastColored.Paddings = new System.Windows.Forms.Padding(0);
            this.tbFastColored.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.tbFastColored.ServiceLinesColor = System.Drawing.Color.Snow;
            this.tbFastColored.Size = new System.Drawing.Size(612, 475);
            this.tbFastColored.TabIndex = 0;
            this.tbFastColored.Zoom = 100;
            this.tbFastColored.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.tbFastColored_TextChanged);
            // 
            // cbQueries
            // 
            this.cbQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbQueries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbQueries.FormattingEnabled = true;
            this.cbQueries.Location = new System.Drawing.Point(0, 0);
            this.cbQueries.Name = "cbQueries";
            this.cbQueries.Size = new System.Drawing.Size(322, 33);
            this.cbQueries.TabIndex = 4;
            this.cbQueries.SelectedIndexChanged += new System.EventHandler(this.cbQueries_SelectedIndexChanged);
            this.cbQueries.Click += new System.EventHandler(this.cbQueries_Click);
            // 
            // pnlQueries
            // 
            this.pnlQueries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQueries.Controls.Add(this.cbQueries);
            this.pnlQueries.Location = new System.Drawing.Point(13, 58);
            this.pnlQueries.Name = "pnlQueries";
            this.pnlQueries.Size = new System.Drawing.Size(324, 35);
            this.pnlQueries.TabIndex = 7;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnResult);
            this.pnlMain.Controls.Add(this.tbTimes);
            this.pnlMain.Controls.Add(this.numQueryCount);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.tbResult);
            this.pnlMain.Controls.Add(this.tbEndpoint);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.pnlQueries);
            this.pnlMain.Controls.Add(this.btnDelete);
            this.pnlMain.Controls.Add(this.btnNew);
            this.pnlMain.Controls.Add(this.pnlQuery);
            this.pnlMain.Controls.Add(this.btnQuery);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(982, 555);
            this.pnlMain.TabIndex = 11;
            // 
            // tbTimes
            // 
            this.tbTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTimes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimes.Location = new System.Drawing.Point(12, 413);
            this.tbTimes.Multiline = true;
            this.tbTimes.Name = "tbTimes";
            this.tbTimes.ReadOnly = true;
            this.tbTimes.Size = new System.Drawing.Size(325, 50);
            this.tbTimes.TabIndex = 101;
            this.tbTimes.TabStop = false;
            // 
            // numQueryCount
            // 
            this.numQueryCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numQueryCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numQueryCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQueryCount.Location = new System.Drawing.Point(734, 14);
            this.numQueryCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQueryCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQueryCount.Name = "numQueryCount";
            this.numQueryCount.Size = new System.Drawing.Size(95, 31);
            this.numQueryCount.TabIndex = 2;
            this.numQueryCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(835, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(139, 29);
            this.lblStatus.TabIndex = 103;
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbResult.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResult.Location = new System.Drawing.Point(12, 176);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(325, 220);
            this.tbResult.TabIndex = 100;
            this.tbResult.TabStop = false;
            // 
            // btnResult
            // 
            this.btnResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResult.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnResult.Enabled = false;
            this.btnResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResult.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.ForeColor = System.Drawing.Color.White;
            this.btnResult.Location = new System.Drawing.Point(181, 480);
            this.btnResult.Name = "btnResult";
            this.btnResult.OriginalColor = System.Drawing.Color.RoyalBlue;
            this.btnResult.Size = new System.Drawing.Size(158, 58);
            this.btnResult.TabIndex = 9;
            this.btnResult.Text = "Last result...";
            this.btnResult.UseVisualStyleBackColor = false;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // tbEndpoint
            // 
            this.tbEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEndpoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEndpoint.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEndpoint.Location = new System.Drawing.Point(14, 14);
            this.tbEndpoint.Name = "tbEndpoint";
            this.tbEndpoint.Size = new System.Drawing.Size(709, 31);
            this.tbEndpoint.TabIndex = 1;
            this.tbEndpoint.Text = "http://";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(126, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.OriginalColor = System.Drawing.Color.SeaGreen;
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(239, 109);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OriginalColor = System.Drawing.Color.Crimson;
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.btnDelete_EnabledChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(12, 109);
            this.btnNew.Name = "btnNew";
            this.btnNew.OriginalColor = System.Drawing.Color.DarkGoldenrod;
            this.btnNew.Size = new System.Drawing.Size(100, 50);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Add...";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuery.BackColor = System.Drawing.Color.Indigo;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(9, 480);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.OriginalColor = System.Drawing.Color.Indigo;
            this.btnQuery.Size = new System.Drawing.Size(158, 58);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 555);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "Sharp SPARQL - Benchmark tool";
            this.pnlQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbFastColored)).EndInit();
            this.pnlQueries.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueryCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxManualSize tbEndpoint;
        private MetroButton btnQuery;
        private MetroButton btnSave;
        private MetroButton btnDelete;
        private MetroButton btnNew;
        private MetroButton btnResult;
        private System.Windows.Forms.Panel pnlQuery;
        private System.Windows.Forms.ComboBox cbQueries;
        private System.Windows.Forms.Panel pnlQueries;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numQueryCount;
        private System.Windows.Forms.TextBox tbTimes;
        private FastColoredTextBoxNS.FastColoredTextBox tbFastColored;
    }
}

