using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCADataAnalyzer
{
    [Flags]
    public enum ChartSelect
    {
        E_CHART_NONE,
        E_CHART_HOURLY,
        E_CHART_DAILY,
        E_CHART_WEEKLY,
        E_CHART_LAST
    }

    static class Program
    {

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
