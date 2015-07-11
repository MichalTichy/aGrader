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
            this.label2 = new System.Windows.Forms.Label();
            this.butRemoveConditon = new System.Windows.Forms.Button();
            this.butAddCondition = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numCountOfNumbers = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioOutputs = new System.Windows.Forms.RadioButton();
            this.radioInputs = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Podmínka";
            // 
            // butRemoveConditon
            // 
            this.butRemoveConditon.Location = new System.Drawing.Point(135, 127);
            this.butRemoveConditon.Name = "butRemoveConditon";
            this.butRemoveConditon.Size = new System.Drawing.Size(114, 23);
            this.butRemoveConditon.TabIndex = 31;
            this.butRemoveConditon.Text = "-";
            this.butRemoveConditon.UseVisualStyleBackColor = true;
            this.butRemoveConditon.Click += new System.EventHandler(this.butRemoveConditon_Click);
            // 
            // butAddCondition
            // 
            this.butAddCondition.Location = new System.Drawing.Point(15, 127);
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.Size = new System.Drawing.Size(114, 23);
            this.butAddCondition.TabIndex = 30;
            this.butAddCondition.Text = "+";
            this.butAddCondition.UseVisualStyleBackColor = true;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(15, 173);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(234, 20);
            this.tbCondition.TabIndex = 29;
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(189, 264);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 28;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(15, 264);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 27;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.Location = new System.Drawing.Point(15, 26);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new System.Drawing.Size(234, 95);
            this.lbConditions.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Podmínky";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Počet čísel";
            // 
            // numCountOfNumbers
            // 
            this.numCountOfNumbers.Location = new System.Drawing.Point(189, 199);
            this.numCountOfNumbers.Name = "numCountOfNumbers";
            this.numCountOfNumbers.Size = new System.Drawing.Size(60, 20);
            this.numCountOfNumbers.TabIndex = 34;
            this.numCountOfNumbers.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioOutputs);
            this.panel1.Controls.Add(this.radioInputs);
            this.panel1.Location = new System.Drawing.Point(15, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 33);
            this.panel1.TabIndex = 35;
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
            // OutputCountOfNumbersMatchingConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 299);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numCountOfNumbers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butRemoveConditon);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.tbCondition);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.Controls.Add(this.lbConditions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutputCountOfNumbersMatchingConditions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OutputCountOfNumbersMatchingConditions";
            this.Activated += new System.EventHandler(this.OutputNumber_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRemoveConditon;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butAddOrDelete;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCountOfNumbers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioOutputs;
        private System.Windows.Forms.RadioButton radioInputs;
    }
}