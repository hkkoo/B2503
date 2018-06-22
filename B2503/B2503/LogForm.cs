using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Future.Logger;

namespace B2503
{
    public partial class LogForm : Form
    {
        private Future.Logger.Logger logger;

        public LogForm(Point mainformPostion)
        {
            InitializeComponent();
            this.Location = new Point(mainformPostion.X - this.Size.Width + 14, mainformPostion.Y);
            
            logger = Future.Logger.Logger.singleton();
            
;        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.logFormEnabled = false;
            logger.shutdown();
        }

        public enum Log
        {
            조건식로그,
            실시간주식거래,
            송수신이벤트,
            자동매매로그
        }



        public void Logger(Log type, logLevel loglevel, string format, params Object[] args)
        {
            string message = String.Format(format, args);
            string time = System.DateTime.Now.ToString();
            string test;
            string logtype = "전체";


            switch (type)
            {
                case Log.송수신이벤트:
                    logtype = "송수신이벤트";
                    test = "<" + loglevel + ">" + "[" + time + "]" + logtype + " : " + message + " \r\n";
                    송수신이벤트로그.AppendText(test);
                    전체로그.AppendText(test);

                    break;
                case Log.실시간주식거래:
                    logtype = "실시간주식거래";
                    test = "<" + loglevel + ">" + "[" + time + "]" + logtype + " : " + message + " \r\n";
                    실시간주식거래.AppendText(test);
                    전체로그.AppendText(test);
                    break;
                case Log.조건식로그:
                    logtype = "조건식로그";
                    test = "<" + loglevel + ">" + "[" + time + "]" + logtype + " : " + message + " \r\n";
                    조건식로그.AppendText(test);
                    전체로그.AppendText(test);
                    break;
                case Log.자동매매로그:
                    logtype = "자동매매로그";
                    test = "<" + loglevel + ">" + "[" + time + "]" + logtype + " : " + message + " \r\n";
                    조건식로그.AppendText(test);
                    전체로그.AppendText(test);
                    break;
            }
            //파일에 log write
            logger.log(loglevel, logtype, message);
        }
    }
}
