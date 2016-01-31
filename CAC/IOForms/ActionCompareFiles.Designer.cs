namespace aGrader.IOForms
{
    partial class ActionCompareFiles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionCompareFiles));
            this.butBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.radioHash = new System.Windows.Forms.RadioButton();
            this.radioLines = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipPath = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            resources.ApplyResources(this.butClose, "butClose");
            // 
            // butAddOrDelete
            // 
            resources.ApplyResources(this.butAddOrDelete, "butAddOrDelete");
            // 
            // butBrowse
            // 
            resources.ApplyResources(this.butBrowse, "butBrowse");
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbPath
            // 
            resources.ApplyResources(this.tbPath, "tbPath");
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            // 
            // radioHash
            // 
            resources.ApplyResources(this.radioHash, "radioHash");
            this.radioHash.Name = "radioHash";
            this.radioHash.UseVisualStyleBackColor = true;
            // 
            // radioLines
            // 
            resources.ApplyResources(this.radioLines, "radioLines");
            this.radioLines.Checked = true;
            this.radioLines.Name = "radioLines";
            this.radioLines.TabStop = true;
            this.radioLines.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioHash);
            this.panel1.Controls.Add(this.radioLines);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ActionCompareFiles
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPath);
            this.Name = "ActionCompareFiles";
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.tbPath, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.butBrowse, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.RadioButton radioLines;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTipPath;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton radioHash;
    }
}
