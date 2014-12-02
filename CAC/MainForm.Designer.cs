namespace CAC
{
    partial class CaC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.butRunTest = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.butReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.lbCodes = new System.Windows.Forms.ListBox();
            this.tabProtocol = new System.Windows.Forms.TabPage();
            this.butExport = new System.Windows.Forms.Button();
            this.butImport = new System.Windows.Forms.Button();
            this.butMoveDown = new System.Windows.Forms.Button();
            this.butMoveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labHelop = new System.Windows.Forms.Label();
            this.cbobjects = new System.Windows.Forms.ComboBox();
            this.lbObjects = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabProtocol.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbCode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbOutput);
            this.splitContainer1.Size = new System.Drawing.Size(499, 314);
            this.splitContainer1.SplitterDistance = 157;
            this.splitContainer1.TabIndex = 3;
            // 
            // rtbCode
            // 
            this.rtbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCode.Location = new System.Drawing.Point(0, 0);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.ReadOnly = true;
            this.rtbCode.Size = new System.Drawing.Size(499, 157);
            this.rtbCode.TabIndex = 0;
            this.rtbCode.Text = "";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(499, 153);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // butRunTest
            // 
            this.butRunTest.Location = new System.Drawing.Point(13, 12);
            this.butRunTest.Name = "butRunTest";
            this.butRunTest.Size = new System.Drawing.Size(98, 23);
            this.butRunTest.TabIndex = 5;
            this.butRunTest.Text = "Spustit test";
            this.butRunTest.UseVisualStyleBackColor = true;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabProtocol);
            this.Tabs.Location = new System.Drawing.Point(517, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(291, 344);
            this.Tabs.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butReload);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbpath);
            this.tabPage1.Controls.Add(this.butBrowse);
            this.tabPage1.Controls.Add(this.lbCodes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(283, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Průzkumník";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butReload
            // 
            this.butReload.Location = new System.Drawing.Point(211, 4);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(68, 23);
            this.butReload.TabIndex = 9;
            this.butReload.Text = "Obnovit";
            this.butReload.UseVisualStyleBackColor = true;
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zvolte adresář s *.c soubory";
            // 
            // tbpath
            // 
            this.tbpath.Location = new System.Drawing.Point(3, 32);
            this.tbpath.Name = "tbpath";
            this.tbpath.ReadOnly = true;
            this.tbpath.Size = new System.Drawing.Size(202, 20);
            this.tbpath.TabIndex = 7;
            this.tbpath.Text = "...";
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(211, 30);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(69, 23);
            this.butBrowse.TabIndex = 6;
            this.butBrowse.Text = "Procházet";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // lbCodes
            // 
            this.lbCodes.FormattingEnabled = true;
            this.lbCodes.Location = new System.Drawing.Point(-4, 58);
            this.lbCodes.Name = "lbCodes";
            this.lbCodes.Size = new System.Drawing.Size(291, 264);
            this.lbCodes.TabIndex = 5;
            this.lbCodes.SelectedIndexChanged += new System.EventHandler(this.lbCodes_SelectedIndexChanged);
            // 
            // tabProtocol
            // 
            this.tabProtocol.Controls.Add(this.butExport);
            this.tabProtocol.Controls.Add(this.butImport);
            this.tabProtocol.Controls.Add(this.butMoveDown);
            this.tabProtocol.Controls.Add(this.butMoveUp);
            this.tabProtocol.Controls.Add(this.label1);
            this.tabProtocol.Controls.Add(this.labHelop);
            this.tabProtocol.Controls.Add(this.cbobjects);
            this.tabProtocol.Controls.Add(this.lbObjects);
            this.tabProtocol.Location = new System.Drawing.Point(4, 22);
            this.tabProtocol.Name = "tabProtocol";
            this.tabProtocol.Padding = new System.Windows.Forms.Padding(3);
            this.tabProtocol.Size = new System.Drawing.Size(283, 318);
            this.tabProtocol.TabIndex = 1;
            this.tabProtocol.Text = "Protokol";
            this.tabProtocol.UseVisualStyleBackColor = true;
            // 
            // butExport
            // 
            this.butExport.Location = new System.Drawing.Point(152, 289);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(125, 23);
            this.butExport.TabIndex = 10;
            this.butExport.Text = "Exportovat";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(6, 289);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(125, 23);
            this.butImport.TabIndex = 9;
            this.butImport.Text = "Importovat";
            this.butImport.UseVisualStyleBackColor = true;
            // 
            // butMoveDown
            // 
            this.butMoveDown.Location = new System.Drawing.Point(223, 110);
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.Size = new System.Drawing.Size(54, 23);
            this.butMoveDown.TabIndex = 8;
            this.butMoveDown.Text = "ˇ";
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butMoveUp
            // 
            this.butMoveUp.Location = new System.Drawing.Point(163, 110);
            this.butMoveUp.Name = "butMoveUp";
            this.butMoveUp.Size = new System.Drawing.Size(54, 23);
            this.butMoveUp.TabIndex = 7;
            this.butMoveUp.Text = "^";
            this.butMoveUp.UseVisualStyleBackColor = true;
            this.butMoveUp.Click += new System.EventHandler(this.butMoveUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tvorba testovacího protokolu";
            // 
            // labHelop
            // 
            this.labHelop.AutoSize = true;
            this.labHelop.Location = new System.Drawing.Point(3, 41);
            this.labHelop.Name = "labHelop";
            this.labHelop.Size = new System.Drawing.Size(128, 13);
            this.labHelop.TabIndex = 2;
            this.labHelop.Text = "Zvolte požadovaný úkon.";
            // 
            // cbobjects
            // 
            this.cbobjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobjects.FormattingEnabled = true;
            this.cbobjects.Items.AddRange(new object[] {
            "VSTUP: TEXT",
            "VSTUP: ČÍSLO",
            "VSTUP: NÁHODNÉ ČÍSLO",
            "VSTUP: SOUBOR"});
            this.cbobjects.Location = new System.Drawing.Point(0, 83);
            this.cbobjects.Name = "cbobjects";
            this.cbobjects.Size = new System.Drawing.Size(283, 21);
            this.cbobjects.TabIndex = 1;
            this.cbobjects.SelectedIndexChanged += new System.EventHandler(this.cbobjects_SelectedIndexChanged);
            // 
            // lbObjects
            // 
            this.lbObjects.FormattingEnabled = true;
            this.lbObjects.Location = new System.Drawing.Point(0, 136);
            this.lbObjects.Name = "lbObjects";
            this.lbObjects.Size = new System.Drawing.Size(287, 147);
            this.lbObjects.TabIndex = 0;
            // 
            // CaC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 368);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.butRunTest);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CaC";
            this.Text = "C application Checker";
            this.Activated += new System.EventHandler(this.CaC_Activated);
            this.LocationChanged += new System.EventHandler(this.CaC_LocationChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabProtocol.ResumeLayout(false);
            this.tabProtocol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Button butRunTest;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbpath;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.ListBox lbCodes;
        private System.Windows.Forms.TabPage tabProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labHelop;
        private System.Windows.Forms.ComboBox cbobjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butExport;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butReload;
        private System.Windows.Forms.Button butMoveDown;
        private System.Windows.Forms.Button butMoveUp;
        public System.Windows.Forms.ListBox lbObjects;
    }
}

