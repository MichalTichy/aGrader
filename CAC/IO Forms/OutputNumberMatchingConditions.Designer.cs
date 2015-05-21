namespace CAC.IO_Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.butAddCondition = new System.Windows.Forms.Button();
            this.butRemoveConditon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podmínky";
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.Location = new System.Drawing.Point(15, 25);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new System.Drawing.Size(234, 95);
            this.lbConditions.TabIndex = 1;
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(189, 198);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 20;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(15, 198);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 19;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(15, 172);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(234, 20);
            this.tbCondition.TabIndex = 21;
            // 
            // butAddCondition
            // 
            this.butAddCondition.Location = new System.Drawing.Point(15, 126);
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.Size = new System.Drawing.Size(114, 23);
            this.butAddCondition.TabIndex = 22;
            this.butAddCondition.Text = "+";
            this.butAddCondition.UseVisualStyleBackColor = true;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // butRemoveConditon
            // 
            this.butRemoveConditon.Location = new System.Drawing.Point(135, 126);
            this.butRemoveConditon.Name = "butRemoveConditon";
            this.butRemoveConditon.Size = new System.Drawing.Size(114, 23);
            this.butRemoveConditon.TabIndex = 23;
            this.butRemoveConditon.Text = "-";
            this.butRemoveConditon.UseVisualStyleBackColor = true;
            this.butRemoveConditon.Click += new System.EventHandler(this.butRemoveConditon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Podmínka";
            // 
            // OutputNumberMatchingConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butRemoveConditon);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.tbCondition);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.Controls.Add(this.lbConditions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutputNumberMatchingConditions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OutputNumberMatchingConditions";
            this.Click += new System.EventHandler(this.OutputNumber_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butAddOrDelete;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.Button butRemoveConditon;
        private System.Windows.Forms.Label label2;
    }
}