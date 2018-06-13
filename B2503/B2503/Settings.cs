using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace B2503
{
    public class Settings
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string          serverType = "";
        public string          s투자타입 = "";
        public string          s설정파일명 = "";

        public string          s전략명 = "";
        public DateTime        t매수운영시작시간 = DateTime.Now;
        public DateTime        t매수운영종료시간 = DateTime.Now;
        public string          s초기매수조건식 = "";
        public string          s매수방식 = "";
        public string          s매수호가 = "";

        public bool[]          b추가매수조건식arr = new bool[3];
        public string[]        s추가매수조건식arr = new string[3];
        public int[]           i추가매수조건식수량arr = new int[3];

        public bool[]          b추가매수수익률arr = new bool[3];
        public int[]           i추가매수수익률수익arr = new int[3];
        public string[]        s추가매수수익률범위arr = new string[3];
        public int[]           i추가매수수익률수량arr = new int[3];

        public bool            b일괄청산시간check = false;
        public DateTime        t일괄청산시간 = DateTime.Now;
        public bool            b초기매도조건식check = false;
        public string          s초기매도조건식 = "";
        public string          s매도방식 = "";
        public string          s매도호가 = "";
        public bool[]          b분할매도조건식arr = new bool[3];
        public string[]        s분할매도조건식arr = new string[3];
        public int[]           i분할매도조건식수량arr = new int[3];

        public bool[]          b분할매도수익률arr = new bool[3];
        public int[]           i분할매도수익률수익arr = new int[3];
        public string[]        s분할매도수익률범위arr = new string[3];
        public int[]           i분할매도수익률수량arr = new int[3];

        public bool            b미체결취소check = false;
        public int             i미체결취소시간 = 0;

        public bool            b매수시간종료후익절손절 = false;

        public bool            b전체익절률 = false;
        public int             i전체익절률 = 0;
        public bool            b전체손절률 = false;
        public int             i전체손절률 = 0;
        public bool            b전체청산종료 = false;

        public string          s선택계좌 = "";
        public long            l총매수가능금액 = 0;
        public long            l종목별초기매수금액 = 0;
        public long            l종목별최대매수금액 = 0;
        public long            l최대매수종목수 = 0;
        public List<string>       l블랙리스트 = new List<string>();

        public Settings(string serverType, string s투자타입)
        {
            this.serverType = serverType;
            this.s투자타입 = s투자타입;
            if (serverType.CompareTo("0") != 0)
                this.s설정파일명 = this.s설정파일명.Insert(0, "Real");

            this.s설정파일명 = this.s설정파일명.Insert(0, s투자타입) + "settings.ini";
            this.s설정파일명 = this.s설정파일명.Insert(0, Directory.GetCurrentDirectory() + "/");

        }

        public void SaveSettings(string fileName)
        {
            string section = s투자타입.ToUpper() + "_INFO";

            //매수
            WritePrivateProfileString(section, "매수운영시작시간", t매수운영시작시간.ToString("HH:mm:ss"), fileName);
            WritePrivateProfileString(section, "매수운영종료시간", t매수운영종료시간.ToString("HH:mm:ss"), fileName);
            WritePrivateProfileString(section, "초기매수조건식", s초기매수조건식, fileName);
            WritePrivateProfileString(section, "매수방식", s매수방식, fileName);
            WritePrivateProfileString(section, "매수호가", s매수호가, fileName);
            WritePrivateProfileString(section, "추가매수조건식1_ON", b추가매수조건식arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수조건식2_ON", b추가매수조건식arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수조건식3_ON", b추가매수조건식arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수조건식1", s추가매수조건식arr[0], fileName);
            WritePrivateProfileString(section, "추가매수조건식2", s추가매수조건식arr[1], fileName);
            WritePrivateProfileString(section, "추가매수조건식3", s추가매수조건식arr[2], fileName);
            WritePrivateProfileString(section, "추가매수조건식1수량", i추가매수조건식수량arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수조건식2수량", i추가매수조건식수량arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수조건식3수량", i추가매수조건식수량arr[2].ToString(), fileName);

            WritePrivateProfileString(section, "추가매수수익률1_ON", b추가매수수익률arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률2_ON", b추가매수수익률arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률3_ON", b추가매수수익률arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률1수익률", i추가매수수익률수익arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률2수익률", i추가매수수익률수익arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률3수익률", i추가매수수익률수익arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률1범위", s추가매수수익률범위arr[0], fileName);
            WritePrivateProfileString(section, "추가매수수익률2범위", s추가매수수익률범위arr[1], fileName);
            WritePrivateProfileString(section, "추가매수수익률3범위", s추가매수수익률범위arr[2], fileName);
            WritePrivateProfileString(section, "추가매수수익률1수량", i추가매수수익률수량arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률2수량", i추가매수수익률수량arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "추가매수수익률3수량", i추가매수수익률수량arr[2].ToString(), fileName);

            //매도
            WritePrivateProfileString(section, "일괄청산시간_ON", b일괄청산시간check.ToString(), fileName);
            WritePrivateProfileString(section, "일괄청산시간", t일괄청산시간.ToString("HH:mm:ss"), fileName);
            WritePrivateProfileString(section, "초기매도조건식_ON", b초기매도조건식check.ToString(), fileName);
            WritePrivateProfileString(section, "초기매도조건식", s초기매도조건식, fileName);
            WritePrivateProfileString(section, "매도방식", s매도방식, fileName);
            WritePrivateProfileString(section, "매도호가", s매도호가, fileName);
            WritePrivateProfileString(section, "분할매도조건식1_ON", b분할매도조건식arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도조건식2_ON", b분할매도조건식arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도조건식3_ON", b분할매도조건식arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도조건식1", s분할매도조건식arr[0], fileName);
            WritePrivateProfileString(section, "분할매도조건식2", s분할매도조건식arr[1], fileName);
            WritePrivateProfileString(section, "분할매도조건식3", s분할매도조건식arr[2], fileName);
            WritePrivateProfileString(section, "분할매도조건식1수량", i분할매도조건식수량arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도조건식2수량", i분할매도조건식수량arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도조건식3수량", i분할매도조건식수량arr[2].ToString(), fileName);

            WritePrivateProfileString(section, "분할매도수익률1_ON", b분할매도수익률arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률2_ON", b분할매도수익률arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률3_ON", b분할매도수익률arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률1수익률", i분할매도수익률수익arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률2수익률", i분할매도수익률수익arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률3수익률", i분할매도수익률수익arr[2].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률1범위", s분할매도수익률범위arr[0], fileName);
            WritePrivateProfileString(section, "분할매도수익률2범위", s분할매도수익률범위arr[1], fileName);
            WritePrivateProfileString(section, "분할매도수익률3범위", s분할매도수익률범위arr[2], fileName);
            WritePrivateProfileString(section, "분할매도수익률1수량", i분할매도수익률수량arr[0].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률2수량", i분할매도수익률수량arr[1].ToString(), fileName);
            WritePrivateProfileString(section, "분할매도수익률3수량", i분할매도수익률수량arr[2].ToString(), fileName);

            WritePrivateProfileString(section, "미체결취소_ON", b미체결취소check.ToString(), fileName);
            WritePrivateProfileString(section, "미체결취소시간", i미체결취소시간.ToString(), fileName);
            WritePrivateProfileString(section, "종료후익절손절", b매수시간종료후익절손절.ToString(), fileName);
            WritePrivateProfileString(section, "전체익절률_ON", b전체익절률.ToString(), fileName);
            WritePrivateProfileString(section, "전체익절률", i전체익절률.ToString(), fileName);
            WritePrivateProfileString(section, "전체손절률_ON", b전체손절률.ToString(), fileName);
            WritePrivateProfileString(section, "전체손절률", i전체손절률.ToString(), fileName);
            WritePrivateProfileString(section, "청산종료_ON", b전체청산종료.ToString(), fileName);

            WritePrivateProfileString(section, "전략", s전략명, fileName);
            WritePrivateProfileString(section, "계좌", s선택계좌, fileName);
            WritePrivateProfileString(section, "총매수가능금액", l총매수가능금액.ToString(), fileName);
            WritePrivateProfileString(section, "종목별초기매수금액", l종목별초기매수금액.ToString(), fileName);
            WritePrivateProfileString(section, "종목별최대매수금액", l종목별최대매수금액.ToString(), fileName);
            WritePrivateProfileString(section, "최대매수종목수", l최대매수종목수.ToString(), fileName);

            string blackList = "";
            foreach (string str in l블랙리스트) {
                blackList += str + ";";
            }
            WritePrivateProfileString(section, "블랙리스트", blackList, fileName);
        }

        private string GetProfileString(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);

            return sb.ToString();
        }
        public void LoadSettings(string fileName)
        {
            string section = s투자타입.ToUpper() + "_INFO";
            try {
                //매수
                t매수운영시작시간 = DateTime.Parse(GetProfileString(section, "매수운영시작시간", fileName));
                t매수운영종료시간 = DateTime.Parse(GetProfileString(section, "매수운영종료시간", fileName));
                s초기매수조건식 = GetProfileString(section, "초기매수조건식", fileName);
                s매수방식 = GetProfileString(section, "매수방식", fileName);
                s매수호가 = GetProfileString(section, "매수호가", fileName);
                b추가매수조건식arr[0] = bool.Parse(GetProfileString(section, "추가매수조건식1_ON", fileName));
                b추가매수조건식arr[1] = bool.Parse(GetProfileString(section, "추가매수조건식2_ON", fileName));
                b추가매수조건식arr[2] = bool.Parse(GetProfileString(section, "추가매수조건식3_ON", fileName));
                s추가매수조건식arr[0] = GetProfileString(section, "추가매수조건식1", fileName);
                s추가매수조건식arr[1] = GetProfileString(section, "추가매수조건식2", fileName);
                s추가매수조건식arr[2] = GetProfileString(section, "추가매수조건식3", fileName);
                i추가매수조건식수량arr[0] = int.Parse(GetProfileString(section, "추가매수조건식1수량", fileName));
                i추가매수조건식수량arr[1] = int.Parse(GetProfileString(section, "추가매수조건식2수량", fileName));
                i추가매수조건식수량arr[2] = int.Parse(GetProfileString(section, "추가매수조건식3수량", fileName));

                b추가매수수익률arr[0] = bool.Parse(GetProfileString(section, "추가매수수익률1_ON", fileName));
                b추가매수수익률arr[1] = bool.Parse(GetProfileString(section, "추가매수수익률2_ON", fileName));
                b추가매수수익률arr[2] = bool.Parse(GetProfileString(section, "추가매수수익률3_ON", fileName));
                i추가매수수익률수익arr[0] = int.Parse(GetProfileString(section, "추가매수수익률1수익률", fileName));
                i추가매수수익률수익arr[1] = int.Parse(GetProfileString(section, "추가매수수익률2수익률", fileName));
                i추가매수수익률수익arr[2] = int.Parse(GetProfileString(section, "추가매수수익률3수익률", fileName));
                s추가매수수익률범위arr[0] = GetProfileString(section, "추가매수수익률1범위", fileName);
                s추가매수수익률범위arr[1] = GetProfileString(section, "추가매수수익률2범위", fileName);
                s추가매수수익률범위arr[2] = GetProfileString(section, "추가매수수익률3범위", fileName);
                i추가매수수익률수량arr[0] = int.Parse(GetProfileString(section, "추가매수수익률1수량", fileName));
                i추가매수수익률수량arr[1] = int.Parse(GetProfileString(section, "추가매수수익률2수량", fileName));
                i추가매수수익률수량arr[2] = int.Parse(GetProfileString(section, "추가매수수익률3수량", fileName));

                //매도
                b일괄청산시간check = bool.Parse(GetProfileString(section, "일괄청산시간_ON", fileName));
                t일괄청산시간 = DateTime.Parse(GetProfileString(section, "일괄청산시간", fileName));
                b초기매도조건식check = bool.Parse(GetProfileString(section, "초기매도조건식_ON", fileName));
                s초기매도조건식 = GetProfileString(section, "초기매도조건식", fileName);
                s매도방식 = GetProfileString(section, "매도방식", fileName);
                s매도호가 = GetProfileString(section, "매도호가", fileName);
                b분할매도조건식arr[0] = bool.Parse(GetProfileString(section, "분할매도조건식1_ON", fileName));
                b분할매도조건식arr[1] = bool.Parse(GetProfileString(section, "분할매도조건식2_ON", fileName));
                b분할매도조건식arr[2] = bool.Parse(GetProfileString(section, "분할매도조건식3_ON", fileName));
                s분할매도조건식arr[0] = GetProfileString(section, "분할매도조건식1", fileName);
                s분할매도조건식arr[1] = GetProfileString(section, "분할매도조건식2", fileName);
                s분할매도조건식arr[2] = GetProfileString(section, "분할매도조건식3", fileName);
                i분할매도조건식수량arr[0] = int.Parse(GetProfileString(section, "분할매도조건식1수량", fileName));
                i분할매도조건식수량arr[1] = int.Parse(GetProfileString(section, "분할매도조건식2수량", fileName));
                i분할매도조건식수량arr[2] = int.Parse(GetProfileString(section, "분할매도조건식3수량", fileName));

                b분할매도수익률arr[0] = bool.Parse(GetProfileString(section, "분할매도수익률1_ON", fileName));
                b분할매도수익률arr[1] = bool.Parse(GetProfileString(section, "분할매도수익률2_ON", fileName));
                b분할매도수익률arr[2] = bool.Parse(GetProfileString(section, "분할매도수익률3_ON", fileName));
                i분할매도수익률수익arr[0] = int.Parse(GetProfileString(section, "분할매도수익률1수익률", fileName));
                i분할매도수익률수익arr[1] = int.Parse(GetProfileString(section, "분할매도수익률2수익률", fileName));
                i분할매도수익률수익arr[2] = int.Parse(GetProfileString(section, "분할매도수익률3수익률", fileName));
                s분할매도수익률범위arr[0] = GetProfileString(section, "분할매도수익률1범위", fileName);
                s분할매도수익률범위arr[1] = GetProfileString(section, "분할매도수익률2범위", fileName);
                s분할매도수익률범위arr[2] = GetProfileString(section, "분할매도수익률3범위", fileName);
                i분할매도수익률수량arr[0] = int.Parse(GetProfileString(section, "분할매도수익률1수량", fileName));
                i분할매도수익률수량arr[1] = int.Parse(GetProfileString(section, "분할매도수익률2수량", fileName));
                i분할매도수익률수량arr[2] = int.Parse(GetProfileString(section, "분할매도수익률3수량", fileName));

                b미체결취소check = bool.Parse(GetProfileString(section, "미체결취소_ON", fileName));
                i미체결취소시간 = int.Parse(GetProfileString(section, "미체결취소시간", fileName));
                b매수시간종료후익절손절 = bool.Parse(GetProfileString(section, "종료후익절손절", fileName));
                b전체익절률 = bool.Parse(GetProfileString(section, "전체익절률_ON", fileName));
                i전체익절률 = int.Parse(GetProfileString(section, "전체익절률", fileName));
                b전체손절률 = bool.Parse(GetProfileString(section, "전체손절률_ON", fileName));
                i전체손절률 = int.Parse(GetProfileString(section, "전체손절률", fileName));
                b전체청산종료 = bool.Parse(GetProfileString(section, "청산종료_ON", fileName));

                s전략명 = GetProfileString(section, "전략", fileName);
                s선택계좌 = GetProfileString(section, "계좌", fileName);
                l총매수가능금액 = int.Parse(GetProfileString(section, "총매수가능금액", fileName));
                l종목별초기매수금액 = int.Parse(GetProfileString(section, "종목별초기매수금액", fileName));
                l종목별최대매수금액 = int.Parse(GetProfileString(section, "종목별최대매수금액", fileName));
                l최대매수종목수 = int.Parse(GetProfileString(section, "최대매수종목수", fileName));

                string[] spStr = GetProfileString(section, "블랙리스트", fileName).Split(';');
                l블랙리스트.AddRange(spStr);
            } catch {
            }
        }
    }
}
