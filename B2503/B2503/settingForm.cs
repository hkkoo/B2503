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
    public partial class SettingForm : Form
    {
        Settings shortSettings;
        Settings longSettings;
        bool valueChanged = false;

        public SettingForm(Settings Short, Settings Long)
        {
            InitializeComponent();
            this.shortSettings = Short;
            this.longSettings = Long;
            this.shortSettings.LoadSettings();
        }

        public void UpdateConditionList(List<string> conditionList)
        {
            this.단기초기매수조건식combo.Items.AddRange(conditionList.ToArray());
            this.단기추가매수조건식1combo.Items.AddRange(conditionList.ToArray());
            this.단기추가매수조건식2combo.Items.AddRange(conditionList.ToArray());
            this.단기추가매수조건식3combo.Items.AddRange(conditionList.ToArray());
            this.단기초기매도조건식combo.Items.AddRange(conditionList.ToArray());
            this.단기분할매도조건식1combo.Items.AddRange(conditionList.ToArray());
            this.단기분할매도조건식2combo.Items.AddRange(conditionList.ToArray());
            this.단기분할매도조건식3combo.Items.AddRange(conditionList.ToArray());
        }

        public void UpdateAccountList(List<string> accountList)
        {
            this.단기계좌combo.Items.AddRange(accountList.ToArray());
        }

        private void SetAllShortSettingsValues()
        {
            //매수조건설정 저장
            shortSettings.t매수운영시작시간 = 단기매수운영시작시간time.Value;
            shortSettings.t매수운영종료시간 = 단기매수운영종료시간time.Value;
            shortSettings.s초기매수조건식 = 단기초기매수조건식combo.SelectedText;
            shortSettings.s매수방식 = 단기매수방식combo.SelectedText;
            shortSettings.s매수호가 = 단기매수호가combo.SelectedText;

            shortSettings.b추가매수조건식arr[0] = 단기추가매수조건식1check.Checked;
            shortSettings.b추가매수조건식arr[1] = 단기추가매수조건식2check.Checked;
            shortSettings.b추가매수조건식arr[2] = 단기추가매수조건식3check.Checked;
            shortSettings.s추가매수조건식arr[0] = 단기추가매수조건식1combo.SelectedText;
            shortSettings.s추가매수조건식arr[1] = 단기추가매수조건식2combo.SelectedText;
            shortSettings.s추가매수조건식arr[2] = 단기추가매수조건식3combo.SelectedText;
            shortSettings.i추가매수조건식수량arr[0] = Decimal.ToInt32(단기추가매수조건식1num.Value);
            shortSettings.i추가매수조건식수량arr[1] = Decimal.ToInt32(단기추가매수조건식2num.Value);
            shortSettings.i추가매수조건식수량arr[2] = Decimal.ToInt32(단기추가매수조건식3num.Value);

            shortSettings.b추가매수수익률arr[0] = 단기추가매수수익률1check.Checked;
            shortSettings.b추가매수수익률arr[1] = 단기추가매수수익률2check.Checked;
            shortSettings.b추가매수수익률arr[2] = 단기추가매수수익률3check.Checked;
            shortSettings.i추가매수수익률수익arr[0] = Decimal.ToInt32(단기추가매수수익률1수익률num.Value);
            shortSettings.i추가매수수익률수익arr[1] = Decimal.ToInt32(단기추가매수수익률2수익률num.Value);
            shortSettings.i추가매수수익률수익arr[2] = Decimal.ToInt32(단기추가매수수익률3수익률num.Value);
            shortSettings.s추가매수수익률범위arr[0] = 단기추가매수수익률1updown.SelectedText;
            shortSettings.s추가매수수익률범위arr[1] = 단기추가매수수익률2updown.SelectedText;
            shortSettings.s추가매수수익률범위arr[2] = 단기추가매수수익률3updown.SelectedText;
            shortSettings.i추가매수수익률수량arr[0] = Decimal.ToInt32(단기추가매수수익률1수량num.Value);
            shortSettings.i추가매수수익률수량arr[1] = Decimal.ToInt32(단기추가매수수익률2수량num.Value);
            shortSettings.i추가매수수익률수량arr[2] = Decimal.ToInt32(단기추가매수수익률3수량num.Value);

            //매도조건설정 저장
            shortSettings.b일괄청산시간check = 단기일괄청산시간check.Checked;
            shortSettings.t일괄청산시간 = 단기매수운영종료시간time.Value;
            shortSettings.b초기매도조건식check = 단기초기매도조건식check.Checked;
            shortSettings.s초기매도조건식 = 단기초기매도조건식combo.SelectedText;
            shortSettings.s매도방식 = 단기매도방식combo.SelectedText;
            shortSettings.s매도호가 = 단기매도호가combo.SelectedText;

            shortSettings.b분할매도조건식arr[0] = 단기분할매도조건식1check.Checked;
            shortSettings.b분할매도조건식arr[1] = 단기분할매도조건식2check.Checked;
            shortSettings.b분할매도조건식arr[2] = 단기분할매도조건식3check.Checked;
            shortSettings.s분할매도조건식arr[0] = 단기분할매도조건식1combo.SelectedText;
            shortSettings.s분할매도조건식arr[1] = 단기분할매도조건식2combo.SelectedText;
            shortSettings.s분할매도조건식arr[2] = 단기분할매도조건식3combo.SelectedText;
            shortSettings.i분할매도조건식수량arr[0] = Decimal.ToInt32(단기분할매도조건식1num.Value);
            shortSettings.i분할매도조건식수량arr[1] = Decimal.ToInt32(단기분할매도조건식2num.Value);
            shortSettings.i분할매도조건식수량arr[2] = Decimal.ToInt32(단기분할매도조건식3num.Value);

            shortSettings.b분할매도수익률arr[0] = 단기분할매도수익률1check.Checked;
            shortSettings.b분할매도수익률arr[1] = 단기분할매도수익률2check.Checked;
            shortSettings.b분할매도수익률arr[2] = 단기분할매도수익률3check.Checked;
            shortSettings.i분할매도수익률수익arr[0] = Decimal.ToInt32(단기분할매도수익률1수익률num.Value);
            shortSettings.i분할매도수익률수익arr[1] = Decimal.ToInt32(단기분할매도수익률2수익률num.Value);
            shortSettings.i분할매도수익률수익arr[2] = Decimal.ToInt32(단기분할매도수익률3수익률num.Value);
            shortSettings.s분할매도수익률범위arr[0] = 단기분할매도수익률1updown.SelectedText;
            shortSettings.s분할매도수익률범위arr[1] = 단기분할매도수익률2updown.SelectedText;
            shortSettings.s분할매도수익률범위arr[2] = 단기분할매도수익률3updown.SelectedText;
            shortSettings.i분할매도수익률수량arr[0] = Decimal.ToInt32(단기분할매도수익률1수량num.Value);
            shortSettings.i분할매도수익률수량arr[1] = Decimal.ToInt32(단기분할매도수익률2수량num.Value);
            shortSettings.i분할매도수익률수량arr[2] = Decimal.ToInt32(단기분할매도수익률3수량num.Value);

            shortSettings.b미체결취소check = 단기미체결취소check.Checked;
            shortSettings.i미체결취소시간 = Decimal.ToInt32(단기미체결시간.Value);
            shortSettings.b매수시간종료후익절손절 = 단기매수종료익절손절진행check.Checked;
            shortSettings.b전체익절률 = 단기전체익절률check.Checked;
            shortSettings.i전체익절률 = Decimal.ToInt32(단기전체익절률num.Value);
            shortSettings.b전체손절률 = 단기전체손절률check.Checked;
            shortSettings.i전체손절률 = Decimal.ToInt32(단기전체손절률num.Value);
            shortSettings.b전체청산종료 = 단기청산후정료check.Checked;

            shortSettings.s전략명 = 단기전략명text.Text;
            shortSettings.s선택계좌 = 단기계좌combo.SelectedText;
            shortSettings.l총매수가능금액 = Decimal.ToInt64(단기총매수가능금액num.Value);
            shortSettings.l종목별초기매수금액 = Decimal.ToInt64(단기종목별초기매수금액num.Value);
            shortSettings.l종목별최대매수금액 = Decimal.ToInt64(단기종목별최대매수금액num.Value);
            shortSettings.l최대매수종목수 = Decimal.ToInt64(단기최대매수종목수num.Value);
            shortSettings.l블랙리스트.Clear();
            foreach(string str in 단기블랙리스트list.Items) {
                shortSettings.l블랙리스트.Add(str);
            }
        }

        private void GetAllShortSettingsValues()
        {
            //매수조건설정 저장
            단기매수운영시작시간time.Value = shortSettings.t매수운영시작시간;
            단기매수운영종료시간time.Value = shortSettings.t매수운영종료시간;
            단기초기매수조건식combo.SelectedText = shortSettings.s초기매수조건식;
            단기매수방식combo.SelectedText = shortSettings.s매수방식;
            단기매수호가combo.SelectedText = shortSettings.s매수호가;

            단기추가매수조건식1check.Checked = shortSettings.b추가매수조건식arr[0];
            단기추가매수조건식2check.Checked = shortSettings.b추가매수조건식arr[1] ;
            단기추가매수조건식3check.Checked = shortSettings.b추가매수조건식arr[2];
            단기추가매수조건식1combo.SelectedText = shortSettings.s추가매수조건식arr[0];
            단기추가매수조건식2combo.SelectedText = shortSettings.s추가매수조건식arr[1];
            단기추가매수조건식3combo.SelectedText = shortSettings.s추가매수조건식arr[2];
            단기추가매수조건식1num.Value = shortSettings.i추가매수조건식수량arr[0];
            단기추가매수조건식2num.Value = shortSettings.i추가매수조건식수량arr[1];
            단기추가매수조건식3num.Value = shortSettings.i추가매수조건식수량arr[2];

            단기추가매수수익률1check.Checked = shortSettings.b추가매수수익률arr[0];
            단기추가매수수익률2check.Checked = shortSettings.b추가매수수익률arr[1];
            단기추가매수수익률3check.Checked = shortSettings.b추가매수수익률arr[2];
            단기추가매수수익률1수익률num.Value = shortSettings.i추가매수수익률수익arr[0];
            단기추가매수수익률2수익률num.Value = shortSettings.i추가매수수익률수익arr[1];
            단기추가매수수익률3수익률num.Value = shortSettings.i추가매수수익률수익arr[2];
            단기추가매수수익률1updown.SelectedText = shortSettings.s추가매수수익률범위arr[0];
            단기추가매수수익률2updown.SelectedText = shortSettings.s추가매수수익률범위arr[1];
            단기추가매수수익률3updown.SelectedText = shortSettings.s추가매수수익률범위arr[2];
            단기추가매수수익률1수량num.Value = shortSettings.i추가매수수익률수량arr[0];
            단기추가매수수익률2수량num.Value = shortSettings.i추가매수수익률수량arr[1];
            단기추가매수수익률3수량num.Value = shortSettings.i추가매수수익률수량arr[2];

            //매도조건설정 저장
            단기일괄청산시간check.Checked = shortSettings.b일괄청산시간check;
            단기매수운영종료시간time.Value = shortSettings.t일괄청산시간;
            단기초기매도조건식check.Checked = shortSettings.b초기매도조건식check;
            단기초기매도조건식combo.SelectedText = shortSettings.s초기매도조건식;
            단기매도방식combo.SelectedText = shortSettings.s매도방식;
            단기매도호가combo.SelectedText = shortSettings.s매도호가;

            단기분할매도조건식1check.Checked = shortSettings.b분할매도조건식arr[0];
            단기분할매도조건식2check.Checked = shortSettings.b분할매도조건식arr[1];
            단기분할매도조건식3check.Checked = shortSettings.b분할매도조건식arr[2];
            단기분할매도조건식1combo.SelectedText = shortSettings.s분할매도조건식arr[0];
            단기분할매도조건식2combo.SelectedText = shortSettings.s분할매도조건식arr[1];
            단기분할매도조건식3combo.SelectedText = shortSettings.s분할매도조건식arr[2];
            단기분할매도조건식1num.Value = shortSettings.i분할매도조건식수량arr[0];
            단기분할매도조건식2num.Value = shortSettings.i분할매도조건식수량arr[1];
            단기분할매도조건식3num.Value = shortSettings.i분할매도조건식수량arr[2];

            단기분할매도수익률1check.Checked = shortSettings.b분할매도수익률arr[0];
            단기분할매도수익률2check.Checked = shortSettings.b분할매도수익률arr[1];
            단기분할매도수익률3check.Checked = shortSettings.b분할매도수익률arr[2];
            단기분할매도수익률1수익률num.Value = shortSettings.i분할매도수익률수익arr[0];
            단기분할매도수익률2수익률num.Value = shortSettings.i분할매도수익률수익arr[1];
            단기분할매도수익률3수익률num.Value = shortSettings.i분할매도수익률수익arr[2];
            단기분할매도수익률1updown.SelectedText = shortSettings.s분할매도수익률범위arr[0];
            단기분할매도수익률2updown.SelectedText = shortSettings.s분할매도수익률범위arr[1];
            단기분할매도수익률3updown.SelectedText = shortSettings.s분할매도수익률범위arr[2]; 
            단기분할매도수익률1수량num.Value = shortSettings.i분할매도수익률수량arr[0]; 
            단기분할매도수익률2수량num.Value = shortSettings.i분할매도수익률수량arr[1];
            단기분할매도수익률3수량num.Value = shortSettings.i분할매도수익률수량arr[2];

            단기미체결취소check.Checked = shortSettings.b미체결취소check;
            단기미체결시간.Value = shortSettings.i미체결취소시간;
            단기매수종료익절손절진행check.Checked = shortSettings.b매수시간종료후익절손절;
            단기전체익절률check.Checked = shortSettings.b전체익절률;
            단기전체익절률num.Value = shortSettings.i전체익절률;
            단기전체손절률check.Checked = shortSettings.b전체손절률;
            단기전체손절률num.Value = shortSettings.i전체손절률;
            단기청산후정료check.Checked = shortSettings.b전체청산종료;

            단기전략명text.Text = shortSettings.s전략명;
            단기계좌combo.SelectedText = shortSettings.s선택계좌;
            단기총매수가능금액num.Value = shortSettings.l총매수가능금액;
            단기종목별초기매수금액num.Value = shortSettings.l종목별초기매수금액;
            단기종목별최대매수금액num.Value = shortSettings.l종목별최대매수금액;
            단기최대매수종목수num.Value = shortSettings.l최대매수종목수;
            단기블랙리스트list.Items.Clear();
            foreach (string str in shortSettings.l블랙리스트) {
                단기블랙리스트list.Items.Add(str);
            }
        }


        /* ==================== event functions ==================== */
        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.settingformEnabled = false;
        }

        private void 단기설정적용btn_Click(object sender, EventArgs e)
        {
            this.shortSettings.SaveSettings();
            MessageBox.Show("설정적용하고 자동매매를 다시 시작하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
