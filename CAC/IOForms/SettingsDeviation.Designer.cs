namespace aGrader.IOForms
{
    partial class SettingsDeviation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDeviation));
            this.label2 = new System.Windows.Forms.Label();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Name = "label2";
            // 
            // numeric
            // 
            this.numeric.DecimalPlaces = 3;
            this.numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            resources.ApplyResources(this.numeric, "numeric");
            this.numeric.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numeric.Name = "numeric";
            this.numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numeric.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SettingsDeviation
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.label1);
            this.Name = "SettingsDeviation";
            this.Activated += new System.EventHandler(this.InputNumber_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.numeric, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric;
        private System.Windows.Forms.Label label1;
    }
}
