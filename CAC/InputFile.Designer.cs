namespace CAC
{
    partial class InputFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.butDel = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.tBLineFormat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LabHelp = new System.Windows.Forms.LinkLabel();
            this.FullPathToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cesta k souboru";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(14, 39);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(144, 20);
            this.tbPath.TabIndex = 22;
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(141, 111);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(60, 23);
            this.butDel.TabIndex = 21;
            this.butDel.Text = "Zavřít";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 111);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 20;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(164, 37);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(37, 23);
            this.butBrowse.TabIndex = 24;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // tBLineFormat
            // 
            this.tBLineFormat.Location = new System.Drawing.Point(14, 85);
            this.tBLineFormat.Name = "tBLineFormat";
            this.tBLineFormat.Size = new System.Drawing.Size(187, 20);
            this.tBLineFormat.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Formát řádku";
            // 
            // LabHelp
            // 
            this.LabHelp.AutoSize = true;
            this.LabHelp.Location = new System.Drawing.Point(91, 66);
            this.LabHelp.Name = "LabHelp";
            this.LabHelp.Size = new System.Drawing.Size(13, 13);
            this.LabHelp.TabIndex = 27;
            this.LabHelp.TabStop = true;
            this.LabHelp.Text = "?";
            // 
            // FullPathToolTip
            // 
            this.FullPathToolTip.ShowAlways = true;
            // 
            // InputFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 146);
            this.Controls.Add(this.LabHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBLineFormat);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InputFile";
            this.Activated += new System.EventHandler(this.InputFile_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrDelete;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TextBox tBLineFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel LabHelp;
        private System.Windows.Forms.ToolTip FullPathToolTip;
    }
}