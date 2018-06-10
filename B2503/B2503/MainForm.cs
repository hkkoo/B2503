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
using B2503;

namespace B2503
{
    public partial class MainForm : Form
    {
        LogForm logform = null;
        SettingForm settingform = null;
        Settings ShortSettings;
        Settings LongSettings;

        public MainForm()
        {
            InitializeComponent();
            currentTimer.Start();
            axKHOpenAPI.CommConnect();
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
                settingform = new SettingForm();
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
                //Logger(Log.전체, "로그인 성공");
            }
            else
                statusBar.Items[1].Text = "로그인 실패";
        }

        // =================================================
        //  로그인 이벤트 함수
        // =================================================
        private void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (Error.IsError(e.nErrCode)) {
                //Logger(Log.실시간, "// [로그인 처리결과] " + Error.GetErrorMessage());
           
                // 조건식 로컬저장 자동으로 진행하기
                System.Threading.Thread.Sleep(1000);         //  로그인 성공후 잠시 기다려서 조건식 불러오기 자동 실행하기
                axKHOpenAPI.GetConditionLoad();
                개인정보.Text = "ID: " + axKHOpenAPI.GetLoginInfo("USER_ID");
                개인정보.Text += ", 이름: " + axKHOpenAPI.GetLoginInfo("USER_NAME");
                개인정보.Text += ", 계좌: ";
                string[] arr계좌 = axKHOpenAPI.GetLoginInfo("ACCNO").Split(';');
                

                // 계좌번호 불러오기
                계좌번호리스트.Items.AddRange(arr계좌);
                계좌번호리스트.SelectedIndex = 0;
            } else {
                //Logger(Log.실시간, "로그인창 열기 실패");
                //Logger(Log.실시간, "로그인 실패로 조건식리스트 불러오기 실패");
            }
        }
        // ==========================================<< 2. 조회 요청한 일반 데이터(OnReceiveTrData) TR수신부(비실시간) >>==================================//
        //  일반 조회 요청한 모든 TR은 여기서 수신된다.
        // ================================================================================================================================================//

        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {

        }

       

        // ==================================================<<매수 매도주문 체결 정보(OnReceiveChejanData) 수신부>>==============================//        
        // 체결 잔고 수신 이벤트 함수
        // 매수 매도주문 체결 정보 출력부        
        // =======================================================================================================================================//
        int int현재가;
        int int거래량;
        int int매입가;
        int int보유수량;
        int int평가금액;

        Single f등락률;
        Single f수익률;
        //string str수익률;
        string str수익률old;
        //string str등락률;
        string str등락률old;
        //string str거래량;
        //string str전일대비기호;
        //string str보유수량;
        //string str매입가;
        //string str평가금액;

        private void axKHOpenAPI_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
        }

        // ===============================================================<< 메세지(OnReceiveMsg)  수신부>> ========================================//
        //
        // 메세지 수신 이벤트 함수
        // 종목코드 메세지수신
        // 
        // =========================================================================================================================================//

        private void axKHOpenAPI_OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {            
        }

        // =======================================================<<실시간 f그리드업데이트 함수 최초 구현부>> ======================================//
        // 종목코드만 넣고 추가 값을 넣으면 알아서 그리드에서 종목코드 찾아서 그 위치에 넣어줌
        //==========================================================================================================================================//
        private void f그리드업데이트(string str종목코드, string str현재가, string str등락률, string str거래량,
                                     string str전일대비기호, string str보유수량, string str매입가, string str평가금액, string str수익률)
        {
        }

        // =====================================================<< 3. 실시간 데이터(OnReceiveRealData) 수신부 >>===================================================//
        //
        //                                           << 실시간 데이터 수신부 : 장중에만 신호 발생한다. 휴일엔 수신 불가 >>
        //                                                    실시간 주식시세 수신하여 데이터그리드뷰에 직접 출력
        // ========================================================================================================================================================//
        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
        }

        // =====================================================<<조건식 저장 및 조건식리스트 불러오기>>===========================================//
        // 자동으로 로컬에 저장된 조건식 리스트 불러오기
        // OnReceiveConditionVer ==>> GetConditionNameList()
        // =======================================================================================================================================//

        private void axKHOpenAPI_OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
        }

        // =================================================<<조건조회 실시간 편입/이탈 정보 업데이트>>========================================//
        // * 자동주문 로직**
        // 조건조회 실시간 편입/이탈 정보 업데이트하여 데이터그리드뷰에 갱신하기
        //  
        // ====================================================================================================================================//

        private void axKHOpenAPI_OnReceiveRealCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
        }

        // =====================================================<< 조건식 TR 메세지 수신부 >> ================================================//
        // 수신된 종목코드 문자열 분리
        // 최초 조건검색후 종목코드 수신하는곳으로 이후에는 OnReceiveRealCondition 에서 실시간 수신됨 
        // ===================================================================================================================================//

        private void axKHOpenAPI_OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
        }
    }
}
