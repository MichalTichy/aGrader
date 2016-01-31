using System.ComponentModel;
using System.Windows.Forms;

namespace aGrader
{
    partial class aGrader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aGrader));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.butSaveLog = new System.Windows.Forms.Button();
            this.butChart = new System.Windows.Forms.Button();
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
            this.butShowTests = new System.Windows.Forms.Button();
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
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.butSaveLog);
            this.splitContainer1.Panel1.Controls.Add(this.butChart);
            this.splitContainer1.Panel1.Controls.Add(this.rtbCode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lV);
            // 
            // butSaveLog
            // 
            resources.ApplyResources(this.butSaveLog, "butSaveLog");
            this.butSaveLog.Name = "butSaveLog";
            this.butSaveLog.UseVisualStyleBackColor = true;
            this.butSaveLog.Click += new System.EventHandler(this.butSaveLog_Click);
            // 
            // butChart
            // 
            resources.ApplyResources(this.butChart, "butChart");
            this.butChart.Name = "butChart";
            this.butChart.UseVisualStyleBackColor = true;
            this.butChart.Click += new System.EventHandler(this.butChart_Click);
            // 
            // rtbCode
            // 
            resources.ApplyResources(this.rtbCode, "rtbCode");
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.ReadOnly = true;
            // 
            // lV
            // 
            resources.ApplyResources(this.lV, "lV");
            this.lV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lV.MultiSelect = false;
            this.lV.Name = "lV";
            this.lV.UseCompatibleStateImageBehavior = false;
            this.lV.View = System.Windows.Forms.View.Details;
            // 
            // BottomToolStripPanel
            // 
            resources.ApplyResources(this.BottomToolStripPanel, "BottomToolStripPanel");
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // TopToolStripPanel
            // 
            resources.ApplyResources(this.TopToolStripPanel, "TopToolStripPanel");
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // RightToolStripPanel
            // 
            resources.ApplyResources(this.RightToolStripPanel, "RightToolStripPanel");
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // LeftToolStripPanel
            // 
            resources.ApplyResources(this.LeftToolStripPanel, "LeftToolStripPanel");
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // butRunTest
            // 
            resources.ApplyResources(this.butRunTest, "butRunTest");
            this.butRunTest.Name = "butRunTest";
            this.butRunTest.UseVisualStyleBackColor = true;
            this.butRunTest.Click += new System.EventHandler(this.butRunTest_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabProtocol);
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butReload);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbpath);
            this.tabPage1.Controls.Add(this.butBrowse);
            this.tabPage1.Controls.Add(this.lbCodes);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butReload
            // 
            resources.ApplyResources(this.butReload, "butReload");
            this.butReload.Name = "butReload";
            this.butReload.UseVisualStyleBackColor = true;
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbpath
            // 
            resources.ApplyResources(this.tbpath, "tbpath");
            this.tbpath.Name = "tbpath";
            this.tbpath.ReadOnly = true;
            // 
            // butBrowse
            // 
            resources.ApplyResources(this.butBrowse, "butBrowse");
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // lbCodes
            // 
            this.lbCodes.FormattingEnabled = true;
            resources.ApplyResources(this.lbCodes, "lbCodes");
            this.lbCodes.Name = "lbCodes";
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
            resources.ApplyResources(this.tabProtocol, "tabProtocol");
            this.tabProtocol.Name = "tabProtocol";
            this.tabProtocol.UseVisualStyleBackColor = true;
            // 
            // butExport
            // 
            resources.ApplyResources(this.butExport, "butExport");
            this.butExport.Name = "butExport";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // butImport
            // 
            resources.ApplyResources(this.butImport, "butImport");
            this.butImport.Name = "butImport";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butMoveDown
            // 
            resources.ApplyResources(this.butMoveDown, "butMoveDown");
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butMoveUp
            // 
            resources.ApplyResources(this.butMoveUp, "butMoveUp");
            this.butMoveUp.Name = "butMoveUp";
            this.butMoveUp.UseVisualStyleBackColor = true;
            this.butMoveUp.Click += new System.EventHandler(this.butMoveUp_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labHelop
            // 
            resources.ApplyResources(this.labHelop, "labHelop");
            this.labHelop.Name = "labHelop";
            // 
            // cbobjects
            // 
            this.cbobjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobjects.FormattingEnabled = true;
            resources.ApplyResources(this.cbobjects, "cbobjects");
            this.cbobjects.Name = "cbobjects";
            // 
            // lbObjects
            // 
            this.lbObjects.FormattingEnabled = true;
            resources.ApplyResources(this.lbObjects, "lbObjects");
            this.lbObjects.Name = "lbObjects";
            this.lbObjects.SelectedIndexChanged += new System.EventHandler(this.lbObjects_SelectedIndexChanged);
            // 
            // lErrorMessage
            // 
            this.lErrorMessage.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lErrorMessage, "lErrorMessage");
            this.lErrorMessage.Name = "lErrorMessage";
            // 
            // butShowTests
            // 
            resources.ApplyResources(this.butShowTests, "butShowTests");
            this.butShowTests.Name = "butShowTests";
            this.butShowTests.UseVisualStyleBackColor = true;
            this.butShowTests.Click += new System.EventHandler(this.butShowTestProgress_Click);
            // 
            // butOpenFile
            // 
            resources.ApplyResources(this.butOpenFile, "butOpenFile");
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Margin = new System.Windows.Forms.Padding(11, 4, 1, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // aGrader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butOpenFile);
            this.Controls.Add(this.butShowTests);
            this.Controls.Add(this.lErrorMessage);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.butRunTest);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "aGrader";
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
        private Button butShowTests;
        private Button butOpenFile;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar progressBar;
        private ToolTip ErrorTooltip;
        private Button butChart;
        private Button butSaveLog;
    }
}

