namespace aGrader
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbCorrect = new System.Windows.Forms.CheckBox();
            this.cbWrong = new System.Windows.Forms.CheckBox();
            this.cbProcessorTime = new System.Windows.Forms.CheckBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.chartBIG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBIG)).BeginInit();
            this.SuspendLayout();
            // 
            // chartResults
            // 
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea3.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartResults.Legends.Add(legend3);
            this.chartResults.Location = new System.Drawing.Point(0, 0);
            this.chartResults.Name = "chartResults";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Lime;
            series7.IsValueShownAsLabel = true;
            series7.Legend = "Legend1";
            series7.Name = "Správně";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Red;
            series8.IsValueShownAsLabel = true;
            series8.Legend = "Legend1";
            series8.Name = "Chybně";
            series9.ChartArea = "ChartArea1";
            series9.Enabled = false;
            series9.IsValueShownAsLabel = true;
            series9.Legend = "Legend1";
            series9.Name = "Processor\\ntime";
            this.chartResults.Series.Add(series7);
            this.chartResults.Series.Add(series8);
            this.chartResults.Series.Add(series9);
            this.chartResults.Size = new System.Drawing.Size(739, 322);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chart1";
            // 
            // cbCorrect
            // 
            this.cbCorrect.AutoSize = true;
            this.cbCorrect.Checked = true;
            this.cbCorrect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCorrect.Location = new System.Drawing.Point(12, 328);
            this.cbCorrect.Name = "cbCorrect";
            this.cbCorrect.Size = new System.Drawing.Size(140, 17);
            this.cbCorrect.TabIndex = 1;
            this.cbCorrect.Text = "Počet správých výstupů";
            this.cbCorrect.UseVisualStyleBackColor = true;
            this.cbCorrect.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbWrong
            // 
            this.cbWrong.AutoSize = true;
            this.cbWrong.Checked = true;
            this.cbWrong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWrong.Location = new System.Drawing.Point(158, 328);
            this.cbWrong.Name = "cbWrong";
            this.cbWrong.Size = new System.Drawing.Size(140, 17);
            this.cbWrong.TabIndex = 2;
            this.cbWrong.Text = "Počet špatných výstupů";
            this.cbWrong.UseVisualStyleBackColor = true;
            this.cbWrong.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbProcessorTime
            // 
            this.cbProcessorTime.AutoSize = true;
            this.cbProcessorTime.Location = new System.Drawing.Point(317, 328);
            this.cbProcessorTime.Name = "cbProcessorTime";
            this.cbProcessorTime.Size = new System.Drawing.Size(152, 17);
            this.cbProcessorTime.TabIndex = 3;
            this.cbProcessorTime.Text = "Náročnost (processor time)";
            this.cbProcessorTime.UseVisualStyleBackColor = true;
            this.cbProcessorTime.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "názvu",
            "počtu správných",
            "počtu špatných",
            "processor time"});
            this.cbSort.Location = new System.Drawing.Point(606, 141);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(121, 21);
            this.cbSort.TabIndex = 4;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(606, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seřadit podle:";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(606, 259);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(121, 23);
            this.butSave.TabIndex = 6;
            this.butSave.Text = "Save graph";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // saveImage
            // 
            this.saveImage.DefaultExt = "bmp";
            this.saveImage.Filter = "bmp (*.bmp)|*.bmp\"";
            // 
            // chartBIG
            // 
            chartArea4.AxisX.Interval = 1D;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.MaximumAutoSize = 90F;
            chartArea4.Name = "ChartArea1";
            this.chartBIG.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartBIG.Legends.Add(legend4);
            this.chartBIG.Location = new System.Drawing.Point(12, 378);
            this.chartBIG.Name = "chartBIG";
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.Lime;
            series10.IsValueShownAsLabel = true;
            series10.Legend = "Legend1";
            series10.Name = "Správně";
            series11.ChartArea = "ChartArea1";
            series11.Color = System.Drawing.Color.Red;
            series11.IsValueShownAsLabel = true;
            series11.Legend = "Legend1";
            series11.Name = "Chybně";
            series12.ChartArea = "ChartArea1";
            series12.Enabled = false;
            series12.IsValueShownAsLabel = true;
            series12.Legend = "Legend1";
            series12.Name = "Processor\\ntime";
            this.chartBIG.Series.Add(series10);
            this.chartBIG.Series.Add(series11);
            this.chartBIG.Series.Add(series12);
            this.chartBIG.Size = new System.Drawing.Size(2500, 900);
            this.chartBIG.TabIndex = 7;
            this.chartBIG.Text = "chart1";
            this.chartBIG.Visible = false;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 345);
            this.Controls.Add(this.chartBIG);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.cbProcessorTime);
            this.Controls.Add(this.cbWrong);
            this.Controls.Add(this.cbCorrect);
            this.Controls.Add(this.chartResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Graph";
            this.ShowIcon = false;
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBIG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.CheckBox cbCorrect;
        private System.Windows.Forms.CheckBox cbWrong;
        private System.Windows.Forms.CheckBox cbProcessorTime;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBIG;
    }
}