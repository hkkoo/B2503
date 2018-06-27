using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiwoomCode;
using Future.Logger;

namespace B2503
{
    enum DATATYPE
    {
        INT,
        FLOAT,
        STR,
        DATETIME,
    }

    public partial class MainForm : Form
    {
        LogForm logform = null;
        SettingForm settingform = null;
        Settings shortSettings;
        Settings longSettings;
        string serverType;
        List<string> conditionList = new List<string>();
        List<string> accountList = new List<string>();

        private int _scrNum = 5000;
        private string _strRealConScrNum = "0000";
        private string _strRealConName = "0000";

        public MainForm()
        {
            InitializeComponent();
            conditionList = new List<string>();
            settingBtn.Enabled = false;
            currentTimer.Start();
            //logform default open for test
#if false
            logform = new LogForm(this.Location);
            logform.Show();
            Properties.Settings.Default.logFormEnabled = true;
#endif
            axKHOpenAPI.CommConnect();
        }

        private string GetScrNum()
        {
            if (_scrNum < 9999)
                _scrNum++;
            else
                _scrNum = 5000;

            return _scrNum.ToString();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            if (logform == null || Properties.Settings.Default.logFormEnabled == false) {
                logform = new LogForm(this.Location);
                logform.Show();
                Properties.Settings.Default.logFormEnabled = true;
            } else {
                logform.Focus();
            }
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            if (settingform == null || Properties.Settings.Default.settingformEnabled == false) {
                settingform = new SettingForm(shortSettings, longSettings);
                settingform.UpdateAccountList(accountList);
                settingform.UpdateConditionList(conditionList);
                settingform.Show();
                Properties.Settings.Default.settingformEnabled = true;
            } else {
                settingform.Focus();
            }
        }

        private void currentTimer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.settingformEnabled == false && settingform != null) {
                settingform.Dispose();
                settingform = null;
            }

            if (Properties.Settings.Default.logFormEnabled == false && logform != null) {
                logform.Dispose();
                logform = null;
            }

            DateTime time = DateTime.Now;
            int errSec = 1000 - time.Millisecond;

            currentTimer.Interval = errSec;
            currentTimer.Start();
            curTimeLabel.Text = time.ToString("MM/dd(ddd) HH:mm:ss");
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.CommConnect() == 0) {
                statusBar.Items[1].Text = "로그인 성공";
                logform.Logger(LogForm.Log.송수신이벤트, logLevel.Error, "로그인 성공");
            } else
                statusBar.Items[1].Text = "로그인 실패";
        }

        private void SendConditionReal()
        {
            string condition = shortSettings.s초기매수조건식;
            int condNum = int.Parse(condition.Substring(0, condition.IndexOf('^')));
            string condName = condition.Substring(condition.IndexOf('^') + 1);
            _strRealConScrNum = GetScrNum();
            _strRealConName = condName;

            if (axKHOpenAPI.SendCondition(_strRealConScrNum, condName, condNum, 1) == 1)
                return;
            else
                return;
        }

        private void GetDefaultRealData()
        {
            serverGubunLabal.Text = (serverType == "1") ? "모의" : "실전";
            shortSettings = new Settings(serverType, "short");
            shortSettings.LoadSettings(shortSettings.s설정파일명);
            longSettings = new Settings(serverType, "long");
            longSettings.LoadSettings(shortSettings.s설정파일명);
            loginBtn.Enabled = false;
            settingBtn.Enabled = true;

            if (shortSettings.s선택계좌 != "") {
                axKHOpenAPI.SetInputValue("계좌번호", shortSettings.s선택계좌);
                axKHOpenAPI.SetInputValue("비밀번호", "");
                axKHOpenAPI.SetInputValue("상장폐지조회구분", "1");
                axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");
                axKHOpenAPI.CommRqData("단기계좌평가현황요청", "OPW00004", 0, GetScrNum());
            }

            SendConditionReal();
        }
        // ============================== 로그인 이벤트 함수 =================================================
        private void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (Error.IsError(e.nErrCode)) {
                //logform.Logger(LogForm.Log.송수신이벤트, logLevel.Info, "// [로그인 처리결과] " + Error.GetErrorMessage());
                System.Threading.Thread.Sleep(500);         //  로그인 성공후 잠시 기다려서 조건식 불러오기 자동 실행하기
                axKHOpenAPI.GetConditionLoad();
                개인정보.Text = "ID: " + axKHOpenAPI.GetLoginInfo("USER_ID");
                개인정보.Text += ", 이름: " + axKHOpenAPI.GetLoginInfo("USER_NAME");

                accountList.AddRange(axKHOpenAPI.GetLoginInfo("ACCNO").Split(';'));
                serverType = axKHOpenAPI.GetLoginInfo("GetServerGubun");
                GetDefaultRealData();

            } else {
                ;
                //Logger(Log.실시간, "로그인창 열기 실패");
                //Logger(Log.실시간, "로그인 실패로 조건식리스트 불러오기 실패");
                //logform.Logger(LogForm.Log.송수신이벤트, logLevel.Error, "로그인창 열기 실패");
                //logform.Logger(LogForm.Log.송수신이벤트, logLevel.Error, "로그인 실패로 조건식리스트 불러오기 실패");
            }
        }

        // =====================================================<<조건식 저장 및 조건식리스트 불러오기>>===========================================//
        // 자동으로 로컬에 저장된 조건식 리스트 불러오기
        // OnReceiveConditionVer ==>> GetConditionNameList()
        // =======================================================================================================================================//

        private void axKHOpenAPI_OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
            if (e.lRet == 1) {
                string[] spConList = axKHOpenAPI.GetConditionNameList().Trim().Split(';');   // 조건식 리스트 호출하기    
                // Logger(Log.실시간, strConList);
                System.Array.Sort(spConList);                             // 조건식 배열 오류로 추가 소스 삽입 
                conditionList.AddRange(spConList);
                // Logger(Log.검색코드, "[이벤트] 조건식 탑재 성공 (건당 이벤트 발생)" );
            } else {
                //Logger(Log.실시간, "[이벤트] 조건식 저장 실패로 수동버튼으로 불러오세요 : " + e.sMsg);        // 에러처리.. 
            }
        }

        // =======================================================<<실시간 f그리드업데이트 함수 최초 구현부>> ======================================//
        // 종목코드만 넣고 추가 값을 넣으면 알아서 그리드에서 종목코드 찾아서 그 위치에 넣어줌
        //==========================================================================================================================================//
        private void UpdateDataGridViewData(DataGridView 뷰, string 기준, string 기준값,
                               string 열이름, string 열값, DATATYPE 타입)
        {
            int rowCnt = 뷰.Rows.Count;
            for (int i = 0; i < rowCnt; i++) {
                if (기준값 != null && 기준값.Equals(뷰[기준, i].Value.ToString().Trim())) {
                    switch (타입) {
                    case DATATYPE.INT:
                        뷰[열이름, i].Value = 열값.Contains(".") ? float.Parse(열값) : int.Parse(열값); ;
                        break;
                    case DATATYPE.FLOAT:
                        뷰[열이름, i].Value = 열값.Contains(".") ? float.Parse(열값)/1000 : float.Parse(열값.Insert(6, "."))/1000;
                        break;
                    case DATATYPE.STR:
                        뷰[열이름, i].Value = 열값;
                        break;
                    default:
                        break;
                    }
                    return;
                }
            }
            뷰.Rows.Add();
            rowCnt = 뷰.Rows.Count;
            switch (타입) {
            case DATATYPE.INT:
                뷰[열이름, rowCnt - 1].Value = 열값.Contains(".") ? float.Parse(열값) : int.Parse(열값); ;
                break;
            case DATATYPE.FLOAT:
                뷰[열이름, rowCnt - 1].Value = 열값.Contains(".") ? float.Parse(열값)/1000 : float.Parse(열값.Insert(6, "."))/1000;
                break;
            case DATATYPE.STR:
                뷰[열이름, rowCnt - 1].Value = 열값;
                break;
            default:
                break;
            }
        }

        // ==========================================<< 2. 조회 요청한 일반 데이터(OnReceiveTrData) TR수신부(비실시간) >>==================================//
        //  일반 조회 요청한 모든 TR은 여기서 수신된다.
        // ================================================================================================================================================//
        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "단기계좌평가현황요청") {
                UpdateDataGridViewData(계좌뷰, "계좌번호", shortSettings.s선택계좌, "계좌번호", shortSettings.s선택계좌, DATATYPE.STR);
                UpdateDataGridViewData(계좌뷰, "계좌번호", shortSettings.s선택계좌, "추정자산", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim(), DATATYPE.INT);
                UpdateDataGridViewData(계좌뷰, "계좌번호", shortSettings.s선택계좌, "유가잔고액", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim(), DATATYPE.INT);

                int nCnt = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
                for (int i = 0; i < nCnt; i++) {
                    string stCode = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();

                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기종목코드", stCode, DATATYPE.STR);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기종목명", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim(), DATATYPE.STR);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기보유수량", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "보유수량").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기매입가", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평균단가").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기현재가", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기매입금액", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매입금액").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기평가금액", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평가금액").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기손익금액", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "손익금액").Trim(), DATATYPE.INT);
                    UpdateDataGridViewData(단기계좌보유현황뷰, "단기종목코드", stCode, "단기수익율", axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "손익율").Trim(), DATATYPE.FLOAT);
                }
            }
        }
        
        // ==================================================<<매수 매도주문 체결 정보(OnReceiveChejanData) 수신부>>==============================//        
        // 체결 잔고 수신 이벤트 함수
        // 매수 매도주문 체결 정보 출력부        
        // =======================================================================================================================================//
        private void axKHOpenAPI_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
        }

        // ===============================================================<< 메세지(OnReceiveMsg)  수신부>> ========================================//
        // 메세지 수신 이벤트 함수
        // 종목코드 메세지수신
        // =========================================================================================================================================//
        private void axKHOpenAPI_OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            e.sMsg.ToString();
            e.sScrNo.ToString();
            e.sRQName.ToString();
            e.sTrCode.ToString();
        }
        
        // =====================================================<< 3. 실시간 데이터(OnReceiveRealData) 수신부 >>===================================================//
        //                                           << 실시간 데이터 수신부 : 장중에만 신호 발생한다. 휴일엔 수신 불가 >>
        //                                                    실시간 주식시세 수신하여 데이터그리드뷰에 직접 출력
        // ========================================================================================================================================================//
        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식시세") {
                string stCode = e.sRealKey;

                UpdateDataGridViewData(실시간검색뷰, "종목코드", stCode, "현재가", axKHOpenAPI.GetCommRealData(e.sRealType, 10).Trim(), DATATYPE.INT);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", stCode, "전일대비", axKHOpenAPI.GetCommRealData(e.sRealType, 11).Trim(), DATATYPE.INT);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", stCode, "등락율", axKHOpenAPI.GetCommRealData(e.sRealType, 12).Trim(), DATATYPE.FLOAT);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", stCode, "거래량", axKHOpenAPI.GetCommRealData(e.sRealType, 13).Trim(), DATATYPE.INT);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", stCode, "구분", axKHOpenAPI.GetCommRealData(e.sRealType, 25).Trim(), DATATYPE.STR);
            }
        }
        
        // =================================================<<조건조회 실시간 편입/이탈 정보 업데이트>>========================================//
        // 조건조회 실시간 편입/이탈 정보 업데이트하여 데이터그리드뷰에 갱신하기
        // ====================================================================================================================================//

        private void axKHOpenAPI_OnReceiveRealCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
            if (e.strType == "I") { //종목편입
                string strCodeName = axKHOpenAPI.GetMasterCodeName(e.sTrCode); // 종목명을 가져온다.
                UpdateDataGridViewData(실시간검색뷰, "종목코드", e.sTrCode, "상태", "편입", DATATYPE.STR);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", e.sTrCode, "종목코드", e.sTrCode, DATATYPE.STR);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", e.sTrCode, "종목명", strCodeName, DATATYPE.STR);
                UpdateDataGridViewData(실시간검색뷰, "종목코드", e.sTrCode, "매수조건식", e.strConditionIndex + "^" + e.strConditionName, DATATYPE.STR);
                if (e.strConditionName.Contains("단기")) {
                    axKHOpenAPI.SendOrder("주식주문", GetScrNum(), shortSettings.s선택계좌, 1, e.sTrCode,                     
                                                1,      // 주문수량
                                                1,      // 주문가격 
                                                "03",    // 거래구분 (시장가)
                                                "0");    // 원주문 번호
                } else {

                }
                    axKHOpenAPI.SetRealReg(_strRealConScrNum, e.sTrCode, "9001;302;10;11;12;13;25", "1");// 실시간 시세등록
            } else if (e.strType == "D") { //종목이탈
                axKHOpenAPI.SetRealRemove(_strRealConScrNum, e.sTrCode);// 실시간 시세해지
                UpdateDataGridViewData(실시간검색뷰, "종목코드", e.sTrCode, "상태", "이탈", DATATYPE.STR);
            }
        }

        // =====================================================<< 조건식 TR 메세지 수신부 >> ================================================//
        // 수신된 종목코드 문자열 분리
        // 최초 조건검색후 종목코드 수신하는곳으로 이후에는 OnReceiveRealCondition 에서 실시간 수신됨 
        // ===================================================================================================================================//

        private void axKHOpenAPI_OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
        }

        // =====================================================<< Form Event Handler >> ================================================//
        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            for (int i = 0; i < view.ColumnCount; i++)
                view[i, e.RowIndex].Style.ApplyStyle(view.Columns[i].DefaultCellStyle);
        }

        private void CheckBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            if (e.ColumnIndex != 0)
                return;

            if (view[e.ColumnIndex, e.RowIndex].Value == null)
                view[e.ColumnIndex, e.RowIndex].Value = false;

            view[e.ColumnIndex, e.RowIndex].Value = !(bool.Parse(view[e.ColumnIndex, e.RowIndex].Value.ToString()));
        }

        private void 단기계좌보유현황리스트_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            string name = view.Columns[e.ColumnIndex].Name;
            if (name == "단기손익금액" || name == "단기수익율") {
                if (float.Parse(view[e.ColumnIndex, e.RowIndex].Value.ToString()) > 0)
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                else if (float.Parse(view[e.ColumnIndex, e.RowIndex].Value.ToString()) < 0)
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Blue;
                else
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
            }
        }

        private void 계좌리스트_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            object 추정자산 = view["추정자산", e.RowIndex].Value;
            object 유가잔고액 = view["유가잔고액", e.RowIndex].Value;
            if (추정자산 != null && 유가잔고액 != null)
                view["주문가능액", e.RowIndex].Value = int.Parse(추정자산.ToString()) - int.Parse(유가잔고액.ToString());
        }

        private void 실시간검색리스트_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            string name = view.Columns[e.ColumnIndex].Name;
            if (name == "전일대비" || name == "등락율" || name == "편입대비" || name == "수익율") {
                if (float.Parse(view[e.ColumnIndex, e.RowIndex].Value.ToString()) > 0)
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                else if (float.Parse(view[e.ColumnIndex, e.RowIndex].Value.ToString()) < 0)
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Blue;
                else
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
            } else if (name == "구분") {
                if (view[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("매수"))
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                else if (view[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("매도"))
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Blue;
                else if (view[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("편입"))
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
                else if (view[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("이탈"))
                    view[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Gray;
            }
        }
    }
}
