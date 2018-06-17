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
        }

        public enum Log
        {
            조건식로그,
            실시간주식거래,
            주식매매로그,
            송수신이벤트,
            자동매매로그
        }

        public void Logger(Log type, string format, params Object[] args)
        {
            string message = String.Format(format, args);
            message = message + "\n";
            switch (type)
            {
                case Log.송수신이벤트:
                    송수신이벤트로그.AppendText(message);
                    전체로그.AppendText(message);
                    logger.log(Future.Logger.logLevel.Info, "송수신이벤트", message);
                    break;
                case Log.실시간주식거래:                    
                    break;
            }
        }
    }
}
