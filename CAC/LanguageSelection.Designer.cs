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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageSelection));
            this.butC = new System.Windows.Forms.Button();
            this.butJava = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butJavaOneFile = new System.Windows.Forms.Button();
            this.butJavaMultipleFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butC
            // 
            resources.ApplyResources(this.butC, "butC");
            this.butC.Name = "butC";
            this.butC.UseVisualStyleBackColor = true;
            this.butC.Click += new System.EventHandler(this.butC_Click);
            // 
            // butJava
            // 
            resources.ApplyResources(this.butJava, "butJava");
            this.butJava.Name = "butJava";
            this.butJava.UseVisualStyleBackColor = true;
            this.butJava.Click += new System.EventHandler(this.butJava_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // butJavaOneFile
            // 
            resources.ApplyResources(this.butJavaOneFile, "butJavaOneFile");
            this.butJavaOneFile.Name = "butJavaOneFile";
            this.butJavaOneFile.UseVisualStyleBackColor = true;
            this.butJavaOneFile.Click += new System.EventHandler(this.butJavaOneFile_Click);
            // 
            // butJavaMultipleFiles
            // 
            resources.ApplyResources(this.butJavaMultipleFiles, "butJavaMultipleFiles");
            this.butJavaMultipleFiles.Name = "butJavaMultipleFiles";
            this.butJavaMultipleFiles.UseVisualStyleBackColor = true;
            this.butJavaMultipleFiles.Click += new System.EventHandler(this.butJavaMultipleFiles_Click);
            // 
            // LanguageSelection
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ControlBox = false;
            this.Controls.Add(this.butJavaMultipleFiles);
            this.Controls.Add(this.butJavaOneFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butJava);
            this.Controls.Add(this.butC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butC;
        private System.Windows.Forms.Button butJava;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butJavaOneFile;
        private System.Windows.Forms.Button butJavaMultipleFiles;
    }
}