using System.ComponentModel;
using System.Windows.Forms;

namespace CAC
{
    partial class CaC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.lV = new System.Windows.Forms.ListView();
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
            this.lErrorMessage = new System.Windows.Forms.Label();
            this.butShowTestProgress = new System.Windows.Forms.Button();
            this.butOpenFile = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ErrorTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabProtocol.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.lV);
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
            // lV
            // 
            this.lV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lV.Location = new System.Drawing.Point(0, 0);
            this.lV.MultiSelect = false;
            this.lV.Name = "lV";
            this.lV.Size = new System.Drawing.Size(499, 153);
            this.lV.TabIndex = 0;
            this.lV.UseCompatibleStateImageBehavior = false;
            this.lV.View = System.Windows.Forms.View.Details;
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
            this.butRunTest.Click += new System.EventHandler(this.butRunTest_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabProtocol);
            this.Tabs.Location = new System.Drawing.Point(517, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(311, 344);
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
            this.tabPage1.Size = new System.Drawing.Size(303, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Průzkumník";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butReload
            // 
            this.butReload.Location = new System.Drawing.Point(229, 3);
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
            this.label3.Location = new System.Drawing.Point(6, 8);
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
            this.tbpath.Size = new System.Drawing.Size(219, 20);
            this.tbpath.TabIndex = 7;
            this.tbpath.Text = "...";
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(228, 30);
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
            this.lbCodes.Size = new System.Drawing.Size(307, 264);
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
            this.tabProtocol.Size = new System.Drawing.Size(303, 318);
            this.tabProtocol.TabIndex = 1;
            this.tabProtocol.Text = "Protokol";
            this.tabProtocol.UseVisualStyleBackColor = true;
            // 
            // butExport
            // 
            this.butExport.Location = new System.Drawing.Point(172, 289);
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
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butMoveDown
            // 
            this.butMoveDown.Location = new System.Drawing.Point(243, 110);
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.Size = new System.Drawing.Size(54, 23);
            this.butMoveDown.TabIndex = 8;
            this.butMoveDown.Text = "ˇ";
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butMoveUp
            // 
            this.butMoveUp.Location = new System.Drawing.Point(172, 110);
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
            this.label1.Location = new System.Drawing.Point(149, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tvorba testovacího protokolu";
            // 
            // labHelop
            // 
            this.labHelop.AutoSize = true;
            this.labHelop.Location = new System.Drawing.Point(3, 46);
            this.labHelop.Name = "labHelop";
            this.labHelop.Size = new System.Drawing.Size(128, 13);
            this.labHelop.TabIndex = 2;
            this.labHelop.Text = "Zvolte požadovaný úkon.";
            // 
            // cbobjects
            // 
            this.cbobjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobjects.FormattingEnabled = true;
            this.cbobjects.Location = new System.Drawing.Point(0, 83);
            this.cbobjects.Name = "cbobjects";
            this.cbobjects.Size = new System.Drawing.Size(303, 21);
            this.cbobjects.TabIndex = 1;
            // 
            // lbObjects
            // 
            this.lbObjects.FormattingEnabled = true;
            this.lbObjects.Location = new System.Drawing.Point(0, 136);
            this.lbObjects.Name = "lbObjects";
            this.lbObjects.Size = new System.Drawing.Size(303, 147);
            this.lbObjects.TabIndex = 0;
            this.lbObjects.SelectedIndexChanged += new System.EventHandler(this.lbObjects_SelectedIndexChanged);
            // 
            // lErrorMessage
            // 
            this.lErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lErrorMessage.Location = new System.Drawing.Point(287, 12);
            this.lErrorMessage.Name = "lErrorMessage";
            this.lErrorMessage.Size = new System.Drawing.Size(224, 23);
            this.lErrorMessage.TabIndex = 8;
            this.lErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butShowTestProgress
            // 
            this.butShowTestProgress.Location = new System.Drawing.Point(117, 12);
            this.butShowTestProgress.Name = "butShowTestProgress";
            this.butShowTestProgress.Size = new System.Drawing.Size(75, 23);
            this.butShowTestProgress.TabIndex = 9;
            this.butShowTestProgress.Text = "průběh testů";
            this.butShowTestProgress.UseVisualStyleBackColor = true;
            this.butShowTestProgress.Visible = false;
            this.butShowTestProgress.Click += new System.EventHandler(this.butShowTestProgress_Click);
            // 
            // butOpenFile
            // 
            this.butOpenFile.Location = new System.Drawing.Point(198, 12);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(83, 23);
            this.butOpenFile.TabIndex = 10;
            this.butOpenFile.Text = "otevřít soubor";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Visible = false;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Margin = new System.Windows.Forms.Padding(11, 4, 1, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 15);
            this.progressBar.Step = 1;
            // 
            // CaC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 377);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butOpenFile);
            this.Controls.Add(this.butShowTestProgress);
            this.Controls.Add(this.lErrorMessage);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.butRunTest);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CaC";
            this.Text = "C application Checker";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabProtocol.ResumeLayout(false);
            this.tabProtocol.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private RichTextBox rtbCode;
        private Button butRunTest;
        private TabControl Tabs;
        private TabPage tabPage1;
        private TextBox tbpath;
        private Button butBrowse;
        private ListBox lbCodes;
        private TabPage tabProtocol;
        private Label label1;
        private Label labHelop;
        private ComboBox cbobjects;
        private Label label3;
        private Button butExport;
        private Button butImport;
        private Button butReload;
        private Button butMoveDown;
        private Button butMoveUp;
        private Label lErrorMessage;
        private ListBox lbObjects;
        private ListView lV;
        private Button butShowTestProgress;
        private Button butOpenFile;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar progressBar;
        private ToolTip ErrorTooltip;
    }
}

