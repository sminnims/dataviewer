using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCADataAnalyzer
{
    public partial class MainForm : Form
    {
        public string filePath;
        public string fileName;

        DataParser _csvParser = new DataParser();
        

        public MainForm()
        {            
            InitializeComponent();            
        }

        private void fileLoadBtn_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;

            OpenFileDialog op_dlg = new OpenFileDialog();
            {
                op_dlg.InitialDirectory = @"C:\";
                op_dlg.Filter = "텍스트파일 (*.csv)|*.csv|모든 파일(*.*)|*.*";
                op_dlg.FilterIndex = 1;
                op_dlg.RestoreDirectory = true;

                if (op_dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                fileName = op_dlg.FileName;
                _csvParser.MyParserDataInit();
                _csvParser.Parse_CSV(fileName);
            }
        }

        private void loadHourReportBtn_Click(object sender, EventArgs e)
        {
            ReportView hourReportView = new ReportView(ChartSelect.E_CHART_HOURLY, _csvParser.parsedDataList);
            hourReportView.ShowDialog();
        }

        private void loadWeekReportBtn_Click(object sender, EventArgs e)
        {
            //ReportView weekReportView = new ReportView(ChartSelect.E_CHART_WEEKLY, _csvParser.parsedDataList);
            //weekReportView.ShowDialog();
        }
    }
}
