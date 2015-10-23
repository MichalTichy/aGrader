namespace aGrader
{
    partial class LanguageSelection
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
            this.butC = new System.Windows.Forms.Button();
            this.butJava = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butC
            // 
            this.butC.Location = new System.Drawing.Point(12, 43);
            this.butC.Name = "butC";
            this.butC.Size = new System.Drawing.Size(125, 23);
            this.butC.TabIndex = 0;
            this.butC.Text = "C";
            this.butC.UseVisualStyleBackColor = true;
            this.butC.Click += new System.EventHandler(this.butC_Click);
            // 
            // butJava
            // 
            this.butJava.Location = new System.Drawing.Point(174, 43);
            this.butJava.Name = "butJava";
            this.butJava.Size = new System.Drawing.Size(125, 23);
            this.butJava.TabIndex = 1;
            this.butJava.Text = "Java";
            this.butJava.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(269, 12);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(30, 23);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "X";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zvolte jazyk";
            // 
            // LanguageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(311, 83);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butJava);
            this.Controls.Add(this.butC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(517, 12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LanguageSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butC;
        private System.Windows.Forms.Button butJava;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label1;
    }
}