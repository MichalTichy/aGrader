namespace aGrader.IOForms
{
    partial class InputRandomNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputRandomNumber));
            this.cbNoDecimal = new System.Windows.Forms.CheckBox();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabErr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
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
            // cbNoDecimal
            // 
            resources.ApplyResources(this.cbNoDecimal, "cbNoDecimal");
            this.cbNoDecimal.Checked = true;
            this.cbNoDecimal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoDecimal.Name = "cbNoDecimal";
            this.cbNoDecimal.UseVisualStyleBackColor = true;
            this.cbNoDecimal.CheckedChanged += new System.EventHandler(this.cbNoDecimal_CheckedChanged);
            // 
            // numMax
            // 
            resources.ApplyResources(this.numMax, "numMax");
            this.numMax.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            2000000000,
            0,
            0,
            -2147483648});
            this.numMax.Name = "numMax";
            this.numMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // numMin
            // 
            resources.ApplyResources(this.numMin, "numMin");
            this.numMin.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            2000000000,
            0,
            0,
            -2147483648});
            this.numMin.Name = "numMin";
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LabErr
            // 
            resources.ApplyResources(this.LabErr, "LabErr");
            this.LabErr.ForeColor = System.Drawing.Color.Red;
            this.LabErr.Name = "LabErr";
            // 
            // InputRandomNumber
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.LabErr);
            this.Controls.Add(this.cbNoDecimal);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "InputRandomNumber";
            this.Activated += new System.EventHandler(this.InputRandomNumber_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.numMin, 0);
            this.Controls.SetChildIndex(this.numMax, 0);
            this.Controls.SetChildIndex(this.cbNoDecimal, 0);
            this.Controls.SetChildIndex(this.LabErr, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNoDecimal;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabErr;
    }
}
