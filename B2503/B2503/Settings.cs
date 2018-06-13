using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace B2503
{
    public class Settings
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string          serverType;
        public string          s투자타입;
        public string          s설정파일명 = "settings.ini";

        public string          s전략명;
        public DateTime        t매수운영시작시간;
        public DateTime        t매수운영종료시간;
        public string          s초기매수조건식;
        public string          s매수방식;
        public string          s매수호가;

        public bool[]          b추가매수조건식arr = new bool[3];
        public string[]        s추가매수조건식arr = new string[3];
        public int[]           i추가매수조건식수량arr = new int[3];

        public bool[]          b추가매수수익률arr = new bool[3];
        public int[]           i추가매수수익률수익arr = new int[3];
        public string[]        s추가매수수익률범위arr = new string[3];
        public int[]           i추가매수수익률수량arr = new int[3];

        public bool            b일괄청산시간check;
        public DateTime        t일괄청산시간;
        public bool            b초기매도조건식check;
        public string          s초기매도조건식;
        public string          s매도방식;
        public string          s매도호가;
        public bool[]          b분할매도조건식arr = new bool[3];
        public string[]        s분할매도조건식arr = new string[3];
        public int[]           i분할매도조건식수량arr = new int[3];

        public bool[]          b분할매도수익률arr = new bool[3];
        public int[]           i분할매도수익률수익arr = new int[3];
        public string[]        s분할매도수익률범위arr = new string[3];
        public int[]           i분할매도수익률수량arr = new int[3];

        public bool            b미체결취소check;
        public int             i미체결취소시간;

        public bool            b매수시간종료후익절손절;

        public bool            b전체익절률;
        public int             i전체익절률;
        public bool            b전체손절률;
        public int             i전체손절률;
        public bool            b전체청산종료;

        public string          s선택계좌 = "";
        public long            l총매수가능금액;
        public long            l종목별초기매수금액;
        public long            l종목별최대매수금액;
        public long            l최대매수종목수;
        public List<string>       l블랙리스트 = new List<string>();

        public Settings(string serverType, string s투자타입)
        {
            this.serverType = serverType;
            this.s투자타입 = s투자타입;
            if (serverType.CompareTo("0") != 0)
                this.s설정파일명 = this.s설정파일명.Insert(0, "Real");

            this.s설정파일명 = this.s설정파일명.Insert(0, s투자타입);
        }

        public void SaveSettings()
        {
            string section = s투자타입.ToUpper() + "_INFO";

            //매수
            WritePrivateProfileString(section, "매수운영시작시간", t매수운영시작시간.ToString("HH:mm:ss"), s설정파일명);
            WritePrivateProfileString(section, "매수운영종료시간", t매수운영시작시간.ToString("HH:mm:ss"), s설정파일명);
            WritePrivateProfileString(section, "초기매수조건식", s초기매수조건식, s설정파일명);
            WritePrivateProfileString(section, "매수방식", s매수방식, s설정파일명);
            WritePrivateProfileString(section, "매수호가", s매수호가, s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식1_ON", b추가매수조건식arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식2_ON", b추가매수조건식arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식3_ON", b추가매수조건식arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식1", s추가매수조건식arr[0], s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식2", s추가매수조건식arr[1], s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식3", s추가매수조건식arr[2], s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식1수량", i추가매수조건식수량arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식2수량", i추가매수조건식수량arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수조건식3수량", i추가매수조건식수량arr[2].ToString(), s설정파일명);

            WritePrivateProfileString(section, "추가매수수익률1_ON", b추가매수수익률arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률2_ON", b추가매수수익률arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률3_ON", b추가매수수익률arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률1수익률", i추가매수수익률수익arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률2수익률", i추가매수수익률수익arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률3수익률", i추가매수수익률수익arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률1범위", s추가매수수익률범위arr[0], s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률2범위", s추가매수수익률범위arr[1], s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률3범위", s추가매수수익률범위arr[2], s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률1수량", i추가매수수익률수량arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률2수량", i추가매수수익률수량arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "추가매수수익률3수량", i추가매수수익률수량arr[2].ToString(), s설정파일명);

            //매도
            WritePrivateProfileString(section, "일괄청산시간_ON", b일괄청산시간check.ToString(), s설정파일명);
            WritePrivateProfileString(section, "일괄청산시간", t일괄청산시간.ToString("HH:mm:ss"), s설정파일명);
            WritePrivateProfileString(section, "초기매수조건식_ON", b초기매도조건식check.ToString(), s설정파일명);
            WritePrivateProfileString(section, "초기매수조건식", s초기매도조건식, s설정파일명);
            WritePrivateProfileString(section, "매도방식", s매도방식, s설정파일명);
            WritePrivateProfileString(section, "매도호가", s매도호가, s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식1_ON", b분할매도조건식arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식2_ON", b분할매도조건식arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식3_ON", b분할매도조건식arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식1", s분할매도조건식arr[0], s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식2", s분할매도조건식arr[1], s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식3", s분할매도조건식arr[2], s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식1수량", i분할매도조건식수량arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식2수량", i분할매도조건식수량arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도조건식3수량", i분할매도조건식수량arr[2].ToString(), s설정파일명);

            WritePrivateProfileString(section, "분할매도수익률1_ON", b분할매도수익률arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률2_ON", b분할매도수익률arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률3_ON", b분할매도수익률arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률1수익률", i분할매도수익률수익arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률2수익률", i분할매도수익률수익arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률3수익률", i분할매도수익률수익arr[2].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률1범위", s분할매도수익률범위arr[0], s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률2범위", s분할매도수익률범위arr[1], s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률3범위", s분할매도수익률범위arr[2], s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률1수량", i분할매도수익률수량arr[0].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률2수량", i분할매도수익률수량arr[1].ToString(), s설정파일명);
            WritePrivateProfileString(section, "분할매도수익률3수량", i분할매도수익률수량arr[2].ToString(), s설정파일명);

            WritePrivateProfileString(section, "미체결취소_ON", b미체결취소check.ToString(), s설정파일명);
            WritePrivateProfileString(section, "미체결취소시간", i미체결취소시간.ToString(), s설정파일명);
            WritePrivateProfileString(section, "종료후익절손절", b매수시간종료후익절손절.ToString(), s설정파일명);
            WritePrivateProfileString(section, "전체익절률_ON", b전체익절률.ToString(), s설정파일명);
            WritePrivateProfileString(section, "전체익절률", i전체익절률.ToString(), s설정파일명);
            WritePrivateProfileString(section, "전체손절률_ON", b전체손절률.ToString(), s설정파일명);
            WritePrivateProfileString(section, "전체손절률", i전체손절률.ToString(), s설정파일명);
            WritePrivateProfileString(section, "청산종료_ON", b전체청산종료.ToString(), s설정파일명);

            WritePrivateProfileString(section, "전략", s전략명, s설정파일명);
            WritePrivateProfileString(section, "계좌", s선택계좌, s설정파일명);
            WritePrivateProfileString(section, "총매수가능금액", l총매수가능금액.ToString(), s설정파일명);
            WritePrivateProfileString(section, "종목별초기매수금액", l종목별초기매수금액.ToString(), s설정파일명);
            WritePrivateProfileString(section, "종목별최대매수금액", l종목별최대매수금액.ToString(), s설정파일명);
            WritePrivateProfileString(section, "최대매수종목수", l최대매수종목수.ToString(), s설정파일명);            

            string blackList = "";
            foreach (string str in l블랙리스트) {
                blackList += str + ";";
            }
            WritePrivateProfileString(section, "블랙리스트", blackList, s설정파일명);
        }

        private string GetProfileString(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);

            return sb.ToString();
        }
        public void LoadSettings()
        {
            string section = s투자타입.ToUpper() + "_INFO";
            try {
                //매수
                t매수운영시작시간 = DateTime.Parse(GetProfileString(section, "매수운영시작시간", s설정파일명));
                t매수운영종료시간 = DateTime.Parse(GetProfileString(section, "매수운영종료시간", s설정파일명));
                s초기매수조건식 = GetProfileString(section, "초기매수조건식", s설정파일명);
                s매수방식 = GetProfileString(section, "매수방식", s설정파일명);
                s매수호가 = GetProfileString(section, "매수호가", s설정파일명);
                b추가매수조건식arr[0] = bool.Parse(GetProfileString(section, "추가매수조건식1_ON", s설정파일명));
                b추가매수조건식arr[1] = bool.Parse(GetProfileString(section, "추가매수조건식2_ON", s설정파일명));
                b추가매수조건식arr[2] = bool.Parse(GetProfileString(section, "추가매수조건식3_ON", s설정파일명));
                s추가매수조건식arr[0] = GetProfileString(section, "추가매수조건식1", s설정파일명);
                s추가매수조건식arr[1] = GetProfileString(section, "추가매수조건식2", s설정파일명);
                s추가매수조건식arr[2] = GetProfileString(section, "추가매수조건식3", s설정파일명);
                i추가매수조건식수량arr[0] = int.Parse(GetProfileString(section, "추가매수조건식1수량", s설정파일명));
                i추가매수조건식수량arr[1] = int.Parse(GetProfileString(section, "추가매수조건식2수량", s설정파일명));
                i추가매수조건식수량arr[2] = int.Parse(GetProfileString(section, "추가매수조건식3수량", s설정파일명));

                b추가매수수익률arr[0] = bool.Parse(GetProfileString(section, "추가매수수익률1_ON", s설정파일명));
                b추가매수수익률arr[1] = bool.Parse(GetProfileString(section, "추가매수수익률2_ON", s설정파일명));
                b추가매수수익률arr[2] = bool.Parse(GetProfileString(section, "추가매수수익률3_ON", s설정파일명));
                i추가매수수익률수익arr[0] = int.Parse(GetProfileString(section, "추가매수수익률1수익률", s설정파일명));
                i추가매수수익률수익arr[1] = int.Parse(GetProfileString(section, "추가매수수익률2수익률", s설정파일명));
                i추가매수수익률수익arr[2] = int.Parse(GetProfileString(section, "추가매수수익률3수익률", s설정파일명));
                s추가매수수익률범위arr[0] = GetProfileString(section, "추가매수수익률1범위", s설정파일명);
                s추가매수수익률범위arr[1] = GetProfileString(section, "추가매수수익률2범위", s설정파일명);
                s추가매수수익률범위arr[2] = GetProfileString(section, "추가매수수익률3범위", s설정파일명);
                i추가매수수익률수량arr[0] = int.Parse(GetProfileString(section, "추가매수수익률1수량", s설정파일명));
                i추가매수수익률수량arr[1] = int.Parse(GetProfileString(section, "추가매수수익률2수량", s설정파일명));
                i추가매수수익률수량arr[2] = int.Parse(GetProfileString(section, "추가매수수익률3수량", s설정파일명));

                //매도
                b일괄청산시간check = bool.Parse(GetProfileString(section, "일괄청산시간_ON", s설정파일명));
                t일괄청산시간 = DateTime.Parse(GetProfileString(section, "일괄청산시간", s설정파일명));
                b초기매도조건식check = bool.Parse(GetProfileString(section, "초기매수조건식_ON", s설정파일명));
                s초기매도조건식 = GetProfileString(section, "초기매수조건식", s설정파일명);
                s매도방식 = GetProfileString(section, "매도방식", s설정파일명);
                s매도호가 = GetProfileString(section, "매도호가", s설정파일명);
                b분할매도조건식arr[0] = bool.Parse(GetProfileString(section, "분할매도조건식1_ON", s설정파일명));
                b분할매도조건식arr[1] = bool.Parse(GetProfileString(section, "분할매도조건식2_ON", s설정파일명));
                b분할매도조건식arr[2] = bool.Parse(GetProfileString(section, "분할매도조건식3_ON", s설정파일명));
                s분할매도조건식arr[0] = GetProfileString(section, "분할매도조건식1", s설정파일명);
                s분할매도조건식arr[1] = GetProfileString(section, "분할매도조건식2", s설정파일명);
                s분할매도조건식arr[2] = GetProfileString(section, "분할매도조건식3", s설정파일명);
                i분할매도조건식수량arr[0] = int.Parse(GetProfileString(section, "분할매도조건식1수량", s설정파일명));
                i분할매도조건식수량arr[1] = int.Parse(GetProfileString(section, "분할매도조건식2수량", s설정파일명));
                i분할매도조건식수량arr[2] = int.Parse(GetProfileString(section, "분할매도조건식3수량", s설정파일명));

                b분할매도수익률arr[0] = bool.Parse(GetProfileString(section, "분할매도수익률1_ON", s설정파일명));
                b분할매도수익률arr[1] = bool.Parse(GetProfileString(section, "분할매도수익률2_ON", s설정파일명));
                b분할매도수익률arr[2] = bool.Parse(GetProfileString(section, "분할매도수익률3_ON", s설정파일명));
                i분할매도수익률수익arr[0] = int.Parse(GetProfileString(section, "분할매도수익률1수익률", s설정파일명));
                i분할매도수익률수익arr[1] = int.Parse(GetProfileString(section, "분할매도수익률2수익률", s설정파일명));
                i분할매도수익률수익arr[2] = int.Parse(GetProfileString(section, "분할매도수익률3수익률", s설정파일명));
                s분할매도수익률범위arr[0] = GetProfileString(section, "분할매도수익률1범위", s설정파일명);
                s분할매도수익률범위arr[1] = GetProfileString(section, "분할매도수익률2범위", s설정파일명);
                s분할매도수익률범위arr[2] = GetProfileString(section, "분할매도수익률3범위", s설정파일명);
                i분할매도수익률수량arr[0] = int.Parse(GetProfileString(section, "분할매도수익률1수량", s설정파일명));
                i분할매도수익률수량arr[1] = int.Parse(GetProfileString(section, "분할매도수익률2수량", s설정파일명));
                i분할매도수익률수량arr[2] = int.Parse(GetProfileString(section, "분할매도수익률3수량", s설정파일명));

                b미체결취소check = bool.Parse(GetProfileString(section, "미체결취소_ON", s설정파일명));
                i미체결취소시간 = int.Parse(GetProfileString(section, "미체결취소시간", s설정파일명));
                b매수시간종료후익절손절 = bool.Parse(GetProfileString(section, "종료후익절손절", s설정파일명));
                b전체익절률 = bool.Parse(GetProfileString(section, "전체익절률_ON", s설정파일명));
                i전체익절률 = int.Parse(GetProfileString(section, "전체익절률", s설정파일명));
                b전체손절률 = bool.Parse(GetProfileString(section, "전체손절률_ON", s설정파일명));
                i전체손절률 = int.Parse(GetProfileString(section, "전체손절률", s설정파일명));
                b전체청산종료 = bool.Parse(GetProfileString(section, "청산종료_ON", s설정파일명));

                s전략명 = GetProfileString(section, "전략", s설정파일명);
                s선택계좌 = GetProfileString(section, "계좌", s설정파일명);
                l총매수가능금액 = int.Parse(GetProfileString(section, "총매수가능금액", s설정파일명));
                l종목별초기매수금액 = int.Parse(GetProfileString(section, "종목별초기매수금액", s설정파일명));
                l종목별최대매수금액 = int.Parse(GetProfileString(section, "종목별최대매수금액", s설정파일명));
                l최대매수종목수 = int.Parse(GetProfileString(section, "최대매수종목수", s설정파일명));

                string[] spStr = GetProfileString(section, "블랙리스트", s설정파일명).Split(';');
                l블랙리스트.AddRange(spStr);
            } catch {

            }
        }
    }
}
