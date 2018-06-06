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
    }
}
