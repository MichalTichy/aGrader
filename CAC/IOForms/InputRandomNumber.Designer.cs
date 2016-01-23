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
            this.butClose.Location = new System.Drawing.Point(191, 121);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 121);
            // 
            // cbNoDecimal
            // 
            this.cbNoDecimal.AutoSize = true;
            this.cbNoDecimal.Checked = true;
            this.cbNoDecimal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoDecimal.Location = new System.Drawing.Point(87, 125);
            this.cbNoDecimal.Name = "cbNoDecimal";
            this.cbNoDecimal.Size = new System.Drawing.Size(89, 17);
            this.cbNoDecimal.TabIndex = 33;
            this.cbNoDecimal.Text = "jen celá čísla";
            this.cbNoDecimal.UseVisualStyleBackColor = true;
            this.cbNoDecimal.CheckedChanged += new System.EventHandler(this.cbNoDecimal_CheckedChanged);
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(9, 95);
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
            this.numMax.Size = new System.Drawing.Size(242, 20);
            this.numMax.TabIndex = 32;
            this.numMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(9, 43);
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
            this.numMin.Size = new System.Drawing.Size(244, 20);
            this.numMin.TabIndex = 31;
            this.numMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Náhodné číslo";
            // 
            // LabErr
            // 
            this.LabErr.AutoSize = true;
            this.LabErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabErr.ForeColor = System.Drawing.Color.Red;
            this.LabErr.Location = new System.Drawing.Point(12, 66);
            this.LabErr.Name = "LabErr";
            this.LabErr.Size = new System.Drawing.Size(0, 13);
            this.LabErr.TabIndex = 34;
            // 
            // InputRandomNumber2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(263, 154);
            this.Controls.Add(this.LabErr);
            this.Controls.Add(this.cbNoDecimal);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "InputRandomNumber2";
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
