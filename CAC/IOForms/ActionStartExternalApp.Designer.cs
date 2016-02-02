namespace aGrader.IOForms
{
    partial class ActionStartExternalApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionStartExternalApp));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.tbArguments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAfter = new System.Windows.Forms.RadioButton();
            this.radBefore = new System.Windows.Forms.RadioButton();
            this.linkTip = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            resources.ApplyResources(this.butClose, "butClose");
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            resources.ApplyResources(this.butAddOrDelete, "butAddOrDelete");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbPath
            // 
            resources.ApplyResources(this.tbPath, "tbPath");
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            // 
            // butBrowse
            // 
            resources.ApplyResources(this.butBrowse, "butBrowse");
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // tbArguments
            // 
            resources.ApplyResources(this.tbArguments, "tbArguments");
            this.tbArguments.Name = "tbArguments";
            this.tbArguments.TextChanged += new System.EventHandler(this.tbArguments_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radAfter);
            this.groupBox1.Controls.Add(this.radBefore);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radAfter
            // 
            resources.ApplyResources(this.radAfter, "radAfter");
            this.radAfter.Name = "radAfter";
            this.radAfter.UseVisualStyleBackColor = true;
            this.radAfter.CheckedChanged += new System.EventHandler(this.radAfter_CheckedChanged);
            // 
            // radBefore
            // 
            resources.ApplyResources(this.radBefore, "radBefore");
            this.radBefore.Checked = true;
            this.radBefore.Name = "radBefore";
            this.radBefore.TabStop = true;
            this.radBefore.UseVisualStyleBackColor = true;
            // 
            // linkTip
            // 
            resources.ApplyResources(this.linkTip, "linkTip");
            this.linkTip.Name = "linkTip";
            this.linkTip.TabStop = true;
            this.linkTip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTip_LinkClicked);
            // 
            // ActionStartExternalApp
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.linkTip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbArguments);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ActionStartExternalApp";
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbPath, 0);
            this.Controls.SetChildIndex(this.butBrowse, 0);
            this.Controls.SetChildIndex(this.tbArguments, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.linkTip, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TextBox tbArguments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radAfter;
        private System.Windows.Forms.RadioButton radBefore;
        private System.Windows.Forms.LinkLabel linkTip;
    }
}
