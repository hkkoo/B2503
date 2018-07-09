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

        public LogForm(Point mainformPostion, Logger logger)
        {
            InitializeComponent();
            this.Location = new Point(mainformPostion.X - this.Size.Width + 14, mainformPostion.Y);
            logger.SetLogFormList(ref 전체로그, ref 자동매매로그,ref 조건식로그,ref 디버깅로그,ref 송수신이벤트로그);
;        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.logFormEnabled = false;

        }

    }
}
