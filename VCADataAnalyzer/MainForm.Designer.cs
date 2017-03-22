namespace VCADataAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileLoadBtn = new System.Windows.Forms.Button();
            this.loadHourReportBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.loadWeekReportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileLoadBtn
            // 
            this.fileLoadBtn.Location = new System.Drawing.Point(247, 49);
            this.fileLoadBtn.Name = "fileLoadBtn";
            this.fileLoadBtn.Size = new System.Drawing.Size(141, 47);
            this.fileLoadBtn.TabIndex = 0;
            this.fileLoadBtn.Text = "Load Data";
            this.fileLoadBtn.UseVisualStyleBackColor = true;
            this.fileLoadBtn.Click += new System.EventHandler(this.fileLoadBtn_Click);
            // 
            // loadHourReportBtn
            // 
            this.loadHourReportBtn.Location = new System.Drawing.Point(247, 102);
            this.loadHourReportBtn.Name = "loadHourReportBtn";
            this.loadHourReportBtn.Size = new System.Drawing.Size(141, 47);
            this.loadHourReportBtn.TabIndex = 1;
            this.loadHourReportBtn.Text = "View Hourly Report";
            this.loadHourReportBtn.UseVisualStyleBackColor = true;
            this.loadHourReportBtn.Click += new System.EventHandler(this.loadHourReportBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 100);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "# Guide\n1. Load data file\n(It may take some time to load.)\n2. Click the View Repo" +
    "rt button you want.";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(376, 27);
            this.progressBar1.TabIndex = 3;
            // 
            // loadWeekReportBtn
            // 
            this.loadWeekReportBtn.Location = new System.Drawing.Point(247, 155);
            this.loadWeekReportBtn.Name = "loadWeekReportBtn";
            this.loadWeekReportBtn.Size = new System.Drawing.Size(141, 47);
            this.loadWeekReportBtn.TabIndex = 4;
            this.loadWeekReportBtn.Text = "View Weekly Report";
            this.loadWeekReportBtn.UseVisualStyleBackColor = true;
            this.loadWeekReportBtn.Click += new System.EventHandler(this.loadWeekReportBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 381);
            this.Controls.Add(this.loadWeekReportBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.loadHourReportBtn);
            this.Controls.Add(this.fileLoadBtn);
            this.Name = "MainForm";
            this.Text = "VCA Result Analyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fileLoadBtn;
        private System.Windows.Forms.Button loadHourReportBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button loadWeekReportBtn;
    }
}

