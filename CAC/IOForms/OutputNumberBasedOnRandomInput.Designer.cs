namespace aGrader.IOForms
{
    partial class OutputNumberBasedOnRandomInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputNumberBasedOnRandomInput));
            this.tbMath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNumbers = new System.Windows.Forms.ListBox();
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
            // tbMath
            // 
            resources.ApplyResources(this.tbMath, "tbMath");
            this.tbMath.Name = "tbMath";
            this.tbMath.Leave += new System.EventHandler(this.tbMath_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbNumbers
            // 
            this.lbNumbers.FormattingEnabled = true;
            resources.ApplyResources(this.lbNumbers, "lbNumbers");
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // OutputNumberBasedOnRandomInput
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbMath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNumbers);
            this.Name = "OutputNumberBasedOnRandomInput";
            this.Activated += new System.EventHandler(this.OutputNumberBasedOnRandomInput_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.lbNumbers, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbMath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbNumbers;
    }
}
