using System.ComponentModel;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    partial class InputRandomNumber
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.labErr = new System.Windows.Forms.Label();
            this.cbNoDecimal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Náhodné číslo";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(100, 148);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(58, 23);
            this.butClose.TabIndex = 17;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 148);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 16;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "max";
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(12, 50);
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
            this.numMin.Size = new System.Drawing.Size(148, 20);
            this.numMin.TabIndex = 24;
            this.numMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(12, 102);
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
            this.numMax.Size = new System.Drawing.Size(146, 20);
            this.numMax.TabIndex = 25;
            this.numMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // labErr
            // 
            this.labErr.AutoSize = true;
            this.labErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(3, 73);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(0, 13);
            this.labErr.TabIndex = 26;
            // 
            // cbNoDecimal
            // 
            this.cbNoDecimal.AutoSize = true;
            this.cbNoDecimal.Checked = true;
            this.cbNoDecimal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoDecimal.Location = new System.Drawing.Point(43, 128);
            this.cbNoDecimal.Name = "cbNoDecimal";
            this.cbNoDecimal.Size = new System.Drawing.Size(89, 17);
            this.cbNoDecimal.TabIndex = 27;
            this.cbNoDecimal.Text = "jen celá čísla";
            this.cbNoDecimal.UseVisualStyleBackColor = true;
            this.cbNoDecimal.CheckedChanged += new System.EventHandler(this.cbNoDecimal_CheckedChanged);
            // 
            // InputRandomNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 183);
            this.Controls.Add(this.cbNoDecimal);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputRandomNumber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InputRandomNumber";
            this.Activated += new System.EventHandler(this.InputRandomNumber_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button butClose;
        private Button butAddOrDelete;
        private Label label3;
        private Label label4;
        private NumericUpDown numMin;
        private NumericUpDown numMax;
        private Label labErr;
        private CheckBox cbNoDecimal;
    }
}