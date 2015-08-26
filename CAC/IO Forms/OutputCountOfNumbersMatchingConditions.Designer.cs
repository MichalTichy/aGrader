namespace CAC.IO_Forms
{
    partial class OutputCountOfNumbersMatchingConditions
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
            this.numCountOfNumbers = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butRemoveConditon = new System.Windows.Forms.Button();
            this.butAddCondition = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioOutputs = new System.Windows.Forms.RadioButton();
            this.radioInputs = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(189, 260);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 260);
            // 
            // numCountOfNumbers
            // 
            this.numCountOfNumbers.Location = new System.Drawing.Point(155, 195);
            this.numCountOfNumbers.Name = "numCountOfNumbers";
            this.numCountOfNumbers.Size = new System.Drawing.Size(94, 20);
            this.numCountOfNumbers.TabIndex = 43;
            this.numCountOfNumbers.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Počet čísel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Podmínka";
            // 
            // butRemoveConditon
            // 
            this.butRemoveConditon.Location = new System.Drawing.Point(135, 123);
            this.butRemoveConditon.Name = "butRemoveConditon";
            this.butRemoveConditon.Size = new System.Drawing.Size(114, 23);
            this.butRemoveConditon.TabIndex = 40;
            this.butRemoveConditon.Text = "-";
            this.butRemoveConditon.UseVisualStyleBackColor = true;
            this.butRemoveConditon.Click += new System.EventHandler(this.butRemoveConditon_Click);
            // 
            // butAddCondition
            // 
            this.butAddCondition.Location = new System.Drawing.Point(15, 123);
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.Size = new System.Drawing.Size(114, 23);
            this.butAddCondition.TabIndex = 39;
            this.butAddCondition.Text = "+";
            this.butAddCondition.UseVisualStyleBackColor = true;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(15, 169);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(234, 20);
            this.tbCondition.TabIndex = 38;
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.Location = new System.Drawing.Point(15, 22);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new System.Drawing.Size(234, 95);
            this.lbConditions.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Podmínky";
            // 
            // radioOutputs
            // 
            this.radioOutputs.AutoSize = true;
            this.radioOutputs.Location = new System.Drawing.Point(169, 3);
            this.radioOutputs.Name = "radioOutputs";
            this.radioOutputs.Size = new System.Drawing.Size(62, 17);
            this.radioOutputs.TabIndex = 38;
            this.radioOutputs.Text = "Výstupy";
            this.radioOutputs.UseVisualStyleBackColor = true;
            // 
            // radioInputs
            // 
            this.radioInputs.AutoSize = true;
            this.radioInputs.Checked = true;
            this.radioInputs.Location = new System.Drawing.Point(3, 3);
            this.radioInputs.Name = "radioInputs";
            this.radioInputs.Size = new System.Drawing.Size(57, 17);
            this.radioInputs.TabIndex = 37;
            this.radioInputs.TabStop = true;
            this.radioInputs.Text = "Vstupy";
            this.radioInputs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioOutputs);
            this.panel1.Controls.Add(this.radioInputs);
            this.panel1.Location = new System.Drawing.Point(15, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 33);
            this.panel1.TabIndex = 44;
            // 
            // OutputCountOfNumbersMatchingConditions2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(263, 296);
            this.Controls.Add(this.numCountOfNumbers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butRemoveConditon);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.tbCondition);
            this.Controls.Add(this.lbConditions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "OutputCountOfNumbersMatchingConditions2";
            this.Activated += new System.EventHandler(this.OutputNumber_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbConditions, 0);
            this.Controls.SetChildIndex(this.tbCondition, 0);
            this.Controls.SetChildIndex(this.butAddCondition, 0);
            this.Controls.SetChildIndex(this.butRemoveConditon, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numCountOfNumbers, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCountOfNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRemoveConditon;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioOutputs;
        private System.Windows.Forms.RadioButton radioInputs;
        private System.Windows.Forms.Panel panel1;
    }
}
