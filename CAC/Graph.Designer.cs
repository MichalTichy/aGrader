namespace CAC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbCorrect = new System.Windows.Forms.CheckBox();
            this.cbWrong = new System.Windows.Forms.CheckBox();
            this.cbProcessorTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.SuspendLayout();
            // 
            // chartResults
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResults.Legends.Add(legend1);
            this.chartResults.Location = new System.Drawing.Point(0, 0);
            this.chartResults.Name = "chartResults";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Lime;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Správně";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Chybně";
            series3.ChartArea = "ChartArea1";
            series3.Enabled = false;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Processor\\ntime";
            this.chartResults.Series.Add(series1);
            this.chartResults.Series.Add(series2);
            this.chartResults.Series.Add(series3);
            this.chartResults.Size = new System.Drawing.Size(469, 322);
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
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 352);
            this.ControlBox = false;
            this.Controls.Add(this.cbProcessorTime);
            this.Controls.Add(this.cbWrong);
            this.Controls.Add(this.cbCorrect);
            this.Controls.Add(this.chartResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Graph";
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.CheckBox cbCorrect;
        private System.Windows.Forms.CheckBox cbWrong;
        private System.Windows.Forms.CheckBox cbProcessorTime;
    }
}