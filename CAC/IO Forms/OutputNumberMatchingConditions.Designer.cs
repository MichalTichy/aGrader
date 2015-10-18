namespace aGrader.IO_Forms
{
    partial class OutputNumberMatchingConditions
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
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(191, 194);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(15, 194);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Podmínka";
            // 
            // butRemoveConditon
            // 
            this.butRemoveConditon.Location = new System.Drawing.Point(137, 126);
            this.butRemoveConditon.Name = "butRemoveConditon";
            this.butRemoveConditon.Size = new System.Drawing.Size(114, 23);
            this.butRemoveConditon.TabIndex = 29;
            this.butRemoveConditon.Text = "-";
            this.butRemoveConditon.UseVisualStyleBackColor = true;
            this.butRemoveConditon.Click += new System.EventHandler(this.butRemoveConditon_Click);
            // 
            // butAddCondition
            // 
            this.butAddCondition.Location = new System.Drawing.Point(15, 126);
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.Size = new System.Drawing.Size(114, 23);
            this.butAddCondition.TabIndex = 28;
            this.butAddCondition.Text = "+";
            this.butAddCondition.UseVisualStyleBackColor = true;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(15, 168);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(236, 20);
            this.tbCondition.TabIndex = 27;
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.Location = new System.Drawing.Point(15, 25);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new System.Drawing.Size(236, 95);
            this.lbConditions.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Podmínky";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(110, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "odchylka neni brana v potaz";
            // 
            // OutputNumberMatchingConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(263, 224);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butRemoveConditon);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.tbCondition);
            this.Controls.Add(this.lbConditions);
            this.Controls.Add(this.label1);
            this.Name = "OutputNumberMatchingConditions";
            this.Activated += new System.EventHandler(this.OutputNumber_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbConditions, 0);
            this.Controls.SetChildIndex(this.tbCondition, 0);
            this.Controls.SetChildIndex(this.butAddCondition, 0);
            this.Controls.SetChildIndex(this.butRemoveConditon, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRemoveConditon;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
