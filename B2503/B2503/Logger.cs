/*
 *  Author: MoonChang Chae (Future Systems Inc.) 
 *  Author-orientation: Athony La Forge (Validity Systems Inc.) 
 */

using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace B2503
{

    public enum LOGTYPE
    {
        B = 1,  //BuySell
        C,      //Condition
        D,      //Debug
        E,      //Event
    }

    public class Logger
    {
        FileStream fs;
        StreamReader sr;
        StreamWriter sw;
        public string fileName;
        RichTextBox[] logList = new RichTextBox[5];

        public Logger()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/log"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/log");

            fileName = Directory.GetCurrentDirectory() + "/log/";
            fileName += DateTime.Now.ToString("yy-MM-dd");
            fileName += ".log";

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            sw = new StreamWriter(fs);
            sw.AutoFlush = true;
        }

        public void Write(LOGTYPE type, string value)
        {
            string log = string.Format("[{0:12}] ({1}) {2}",
                DateTime.Now.ToString("hh:mm:ss.fff"), type.ToString(), value);

            sw.WriteLine(log);
            if (Properties.Settings.Default.logFormEnabled) {
                logList[0].AppendText( string.Format("{0}" + Environment.NewLine, log));
                logList[(int)type].AppendText(string.Format("{0}" + Environment.NewLine, log));
            }
        }

        public void Close()
        {
            sw.Flush();
            sw.Close();
        }

        public void SetLogFormList(ref RichTextBox allLog, ref RichTextBox buySell, ref RichTextBox cond,
            ref RichTextBox debug, ref RichTextBox Event)
        {
            string data = null;

            logList[0] = allLog;
            logList[(int)LOGTYPE.B] = buySell;
            logList[(int)LOGTYPE.C] = cond;
            logList[(int)LOGTYPE.D] = debug;
            logList[(int)LOGTYPE.E] = Event;

            sw.Flush();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            sr = new StreamReader(fs);

            do {
                data = sr.ReadLine();
                allLog.AppendText(data + Environment.NewLine);

                string[] spData = data.Split(' ');
                if (spData.Length < 2)
                    continue;

                if (spData[1].Contains(string.Format("({0})", LOGTYPE.B.ToString())))
                    buySell.AppendText(data + Environment.NewLine);
                else if (spData[1].Contains(string.Format("({0})", LOGTYPE.C.ToString())))
                    cond.AppendText(data + Environment.NewLine);
                else if (spData[1].Contains(string.Format("({0})", LOGTYPE.D.ToString())))
                    debug.AppendText(data + Environment.NewLine);
                else if (spData[1].Contains(string.Format("({0})", LOGTYPE.E.ToString())))
                    Event.AppendText(data + Environment.NewLine);
            } while (!sr.EndOfStream);
            sr.Close();
        }
    }
}
