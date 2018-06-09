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
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public int             i서버;
        public string          s투자타입;

        public string          s전략명;
        public DateTime        t매수운영시작시간;
        public DateTime        t매수운영종료시간;
        public List<string>    l초기매수조건식;
        public bool[]          b추가매수조건식arr;
        public List<string>[]  l추가매수조건식arr;
        public int[]           i추가매수조건식수량arr;

        public bool[]          b추가매수수익률arr;
        public int[]           i추가매수수익률수익arr;
        public string[]        s추가매수수익률범위arr;
        public int[]           i추가매수수익률수량arr;

        public bool            b일괄청산시간;
        public DateTime        t일괄정찬시간;
        public List<string>    l초기매도조건식;
        public bool[]          b분할매도조건식arr;
        public List<string>[]  l분할매도조건식arr;
        public int[]           i분할매도조건식수량arr;

        public bool[]          b분할매도수익률arr;
        public int[]           i분할매도수익률수익arr;
        public string[]        s분할매도수익률범위arr;
        public int[]           i분할매도수익률수량arr;

        public int             i미체결취소시간;
        public bool            b미체결취소;
        public bool            b매수시간종료후익절손절;

        public bool            b전체익절률;
        public int             i전체익절률;
        public bool            b전체손절률;
        public int             i전체손절률;
        public bool            b전체청산종료;

        public string          s단기계좌;
        public long            l총매수가능금액;
        public long            l종목별초기매수금액;
        public long            l종목별최대매수금액;
        public long            l최대매수종목수;
        public List<int>       l블랙리스트;

        public Settings()
        {

        }

        public void saveSettings()
        {

        }
    }
}
