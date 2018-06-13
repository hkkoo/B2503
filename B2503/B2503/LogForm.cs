using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2503
{
    public partial class LogForm : Form
    {
        public LogForm(Point mainformPostion)
        {
            InitializeComponent();
            this.Location = new Point(mainformPostion.X - this.Size.Width + 14, mainformPostion.Y);
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.logFormEnabled = false;
        }

        public enum Log
        {
            전체,
            송수신이벤트,
            자동매매로그
        }

        public void Logger(Log type, string format, params Object[] args)
        {
            string message = String.Format(format, args);

            switch (type)
            {
                case Log.송수신이벤트:
                    송수신이벤트로그.AppendText(message);
                    break;
                case Log.전체:
                    전체로그.AppendText(message);
                    break;
            }
        }
    }
}
