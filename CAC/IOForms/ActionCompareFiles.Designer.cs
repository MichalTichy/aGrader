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
            this.butClose.Location = new System.Drawing.Point(191, 155);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 155);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(214, 32);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(37, 23);
            this.butBrowse.TabIndex = 30;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Cesta ke kontrolnímu souboru";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(12, 35);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(196, 20);
            this.tbPath.TabIndex = 28;
            // 
            // radioHash
            // 
            this.radioHash.AutoSize = true;
            this.radioHash.Location = new System.Drawing.Point(169, 3);
            this.radioHash.Name = "radioHash";
            this.radioHash.Size = new System.Drawing.Size(72, 17);
            this.radioHash.TabIndex = 38;
            this.radioHash.Text = "jen HASH";
            this.radioHash.UseVisualStyleBackColor = true;
            // 
            // radioLines
            // 
            this.radioLines.AutoSize = true;
            this.radioLines.Checked = true;
            this.radioLines.Location = new System.Drawing.Point(3, 3);
            this.radioLines.Name = "radioLines";
            this.radioLines.Size = new System.Drawing.Size(79, 17);
            this.radioLines.TabIndex = 37;
            this.radioLines.TabStop = true;
            this.radioLines.Text = "Po řádcích";
            this.radioLines.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioHash);
            this.panel1.Controls.Add(this.radioLines);
            this.panel1.Location = new System.Drawing.Point(12, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 24);
            this.panel1.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Porovnávat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 36);
            this.label2.TabIndex = 47;
            this.label2.Text = "Soubor k porovnání musí být ve stejné složce\r\njako zdrojové kódy a mít název ve t" +
    "varu:\r\njménoZdrojovéhoSouboru.txt";
            // 
            // ActionCompareFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(263, 190);
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
