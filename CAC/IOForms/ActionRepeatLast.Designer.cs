namespace aGrader.IOForms
{
    partial class ActionRepeatLast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionRepeatLast));
            this.labLastAction = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // butClose
            // 
            resources.ApplyResources(this.butClose, "butClose");
            // 
            // labLastAction
            // 
            resources.ApplyResources(this.labLastAction, "labLastAction");
            this.labLastAction.Name = "labLastAction";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numeric
            // 
            resources.ApplyResources(this.numeric, "numeric");
            this.numeric.Name = "numeric";
            this.numeric.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // ActionRepeatLast
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labLastAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric);
            this.Name = "ActionRepeatLast";
            this.Activated += new System.EventHandler(this.ActionRepeatLast_Activated);
            this.Shown += new System.EventHandler(this.ActionRepeatLast_Shown);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.numeric, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.labLastAction, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labLastAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric;
    }
}
