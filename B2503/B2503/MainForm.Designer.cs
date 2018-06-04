namespace B2503
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loginBtn = new System.Windows.Forms.ToolStripButton();
            this.settingBtn = new System.Windows.Forms.ToolStripButton();
            this.logBtn = new System.Windows.Forms.ToolStripButton();
            this.reportBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.계좌리스트 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axKHOpenAPI = new AxKHOpenAPILib.AxKHOpenAPI();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.종목리스트 = new System.Windows.Forms.ListView();
            this.체크 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.상태 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.종목코드 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.종목명 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.구분 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.전일대비 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.현재가 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.등락률 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.거래량 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.편입가 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.편입대비 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.편입시간 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.수익률 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.매수조건식 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌종목코드 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌종목명 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌보유수량 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌매입가 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌현재가 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌거래량 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌매입금액 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌평가금액 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.계좌수익률 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.curTimeLabel = new System.Windows.Forms.Label();
            this.currentTimer = new System.Windows.Forms.Timer(this.components);
            this.추정자산 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주문가능액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.유가잔고액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.당일매수액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.당일매도액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매매수수료 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매매세금 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.손익금 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.계좌리스트)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginBtn,
            this.settingBtn,
            this.logBtn,
            this.reportBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1262, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "MenuBar";
            // 
            // loginBtn
            // 
            this.loginBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginBtn.Image")));
            this.loginBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(71, 23);
            this.loginBtn.Text = "로그인";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingBtn.Image")));
            this.settingBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(113, 23);
            this.settingBtn.Text = "자동매매설정";
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // logBtn
            // 
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(57, 23);
            this.logBtn.Text = "로그";
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportBtn.Image")));
            this.reportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(99, 23);
            this.reportBtn.Text = "손익보고서";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.계좌리스트);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(13, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "::계좌정보";
            // 
            // 계좌리스트
            // 
            this.계좌리스트.BackgroundColor = System.Drawing.Color.White;
            this.계좌리스트.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.계좌리스트.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.계좌리스트.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.추정자산,
            this.주문가능액,
            this.유가잔고액,
            this.당일매수액,
            this.당일매도액,
            this.매매수수료,
            this.매매세금,
            this.손익금});
            this.계좌리스트.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.계좌리스트.Dock = System.Windows.Forms.DockStyle.Fill;
            this.계좌리스트.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.계좌리스트.Location = new System.Drawing.Point(3, 19);
            this.계좌리스트.MultiSelect = false;
            this.계좌리스트.Name = "계좌리스트";
            this.계좌리스트.ReadOnly = true;
            this.계좌리스트.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.계좌리스트.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.계좌리스트.RowTemplate.Height = 23;
            this.계좌리스트.ShowEditingIcon = false;
            this.계좌리스트.Size = new System.Drawing.Size(957, 76);
            this.계좌리스트.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axKHOpenAPI);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(981, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 614);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "::자동매매설정";
            // 
            // axKHOpenAPI
            // 
            this.axKHOpenAPI.Enabled = true;
            this.axKHOpenAPI.Location = new System.Drawing.Point(206, 593);
            this.axKHOpenAPI.Name = "axKHOpenAPI";
            this.axKHOpenAPI.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI.OcxState")));
            this.axKHOpenAPI.Size = new System.Drawing.Size(63, 21);
            this.axKHOpenAPI.TabIndex = 12;
            this.axKHOpenAPI.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(142, 376);
            this.button4.Margin = new System.Windows.Forms.Padding(10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 34);
            this.button4.TabIndex = 11;
            this.button4.Text = "자동매매중지";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(16, 376);
            this.button3.Margin = new System.Windows.Forms.Padding(10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 34);
            this.button3.TabIndex = 10;
            this.button3.Text = "자동매매시작";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.textBox8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(7, 197);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 166);
            this.panel3.TabIndex = 1;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox2.Location = new System.Drawing.Point(18, 135);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 21);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "자동매매 일시정지";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(125, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(102, 23);
            this.textBox5.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(15, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "종목당 매수금액";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(168, 74);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(59, 23);
            this.textBox6.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(15, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "최대 매수종목 갯수";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(168, 45);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(59, 23);
            this.textBox7.TabIndex = 3;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(91, 45);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(59, 23);
            this.textBox8.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(15, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "운영시간";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(13, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(232, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "장기 조건명";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(7, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 169);
            this.panel2.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(18, 135);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 21);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "자동매매 일시정지";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(125, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(102, 23);
            this.textBox4.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(15, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "종목당 매수금액";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(168, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 23);
            this.textBox3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(15, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "최대 매수종목 갯수";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 23);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(15, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "운영시간";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(13, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "단기 조건명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.종목리스트);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(13, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(963, 398);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "::실시간조건검색";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 40);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(654, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "실행";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(448, 10);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 23);
            this.comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(369, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "매도조건식";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(288, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "실행";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(82, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "매수조건식";
            // 
            // 종목리스트
            // 
            this.종목리스트.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.종목리스트.AutoArrange = false;
            this.종목리스트.BackColor = System.Drawing.SystemColors.Window;
            this.종목리스트.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.종목리스트.CheckBoxes = true;
            this.종목리스트.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.체크,
            this.상태,
            this.종목코드,
            this.종목명,
            this.구분,
            this.전일대비,
            this.현재가,
            this.등락률,
            this.거래량,
            this.편입가,
            this.편입대비,
            this.편입시간,
            this.수익률,
            this.매수조건식});
            this.종목리스트.GridLines = true;
            this.종목리스트.LabelWrap = false;
            this.종목리스트.Location = new System.Drawing.Point(7, 68);
            this.종목리스트.Name = "종목리스트";
            this.종목리스트.Size = new System.Drawing.Size(950, 324);
            this.종목리스트.TabIndex = 1;
            this.종목리스트.UseCompatibleStateImageBehavior = false;
            this.종목리스트.View = System.Windows.Forms.View.Details;
            // 
            // 체크
            // 
            this.체크.Text = "";
            this.체크.Width = 39;
            // 
            // 상태
            // 
            this.상태.Text = "상태";
            this.상태.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.상태.Width = 41;
            // 
            // 종목코드
            // 
            this.종목코드.Text = "종목코드";
            this.종목코드.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.종목코드.Width = 64;
            // 
            // 종목명
            // 
            this.종목명.Tag = "0";
            this.종목명.Text = "종목명";
            this.종목명.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.종목명.Width = 118;
            // 
            // 구분
            // 
            this.구분.Text = "구분";
            this.구분.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.구분.Width = 41;
            // 
            // 전일대비
            // 
            this.전일대비.Text = "전일대비";
            this.전일대비.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 현재가
            // 
            this.현재가.Text = "현재가";
            this.현재가.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.현재가.Width = 72;
            // 
            // 등락률
            // 
            this.등락률.Text = "등락률";
            this.등락률.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.등락률.Width = 53;
            // 
            // 거래량
            // 
            this.거래량.Text = "거래량";
            this.거래량.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.거래량.Width = 105;
            // 
            // 편입가
            // 
            this.편입가.Text = "편입가";
            this.편입가.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.편입가.Width = 58;
            // 
            // 편입대비
            // 
            this.편입대비.Text = "편입대비";
            this.편입대비.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 편입시간
            // 
            this.편입시간.DisplayIndex = 12;
            this.편입시간.Text = "편입시간";
            this.편입시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.편입시간.Width = 70;
            // 
            // 수익률
            // 
            this.수익률.DisplayIndex = 11;
            this.수익률.Text = "수익률";
            this.수익률.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.수익률.Width = 51;
            // 
            // 매수조건식
            // 
            this.매수조건식.Text = "매수조건식";
            this.매수조건식.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.매수조건식.Width = 89;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.listView2);
            this.groupBox4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(13, 535);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(963, 150);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "::계좌보유현황";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.AutoArrange = false;
            this.listView2.BackColor = System.Drawing.SystemColors.Window;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.계좌종목코드,
            this.계좌종목명,
            this.계좌보유수량,
            this.계좌매입가,
            this.계좌현재가,
            this.계좌거래량,
            this.계좌매입금액,
            this.계좌평가금액,
            this.계좌수익률});
            this.listView2.GridLines = true;
            this.listView2.LabelWrap = false;
            this.listView2.Location = new System.Drawing.Point(7, 23);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(950, 121);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 37;
            // 
            // 계좌종목코드
            // 
            this.계좌종목코드.Text = "종목코드";
            this.계좌종목코드.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌종목코드.Width = 103;
            // 
            // 계좌종목명
            // 
            this.계좌종목명.Tag = "0";
            this.계좌종목명.Text = "종목명";
            this.계좌종목명.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌종목명.Width = 106;
            // 
            // 계좌보유수량
            // 
            this.계좌보유수량.Text = "보유수량";
            this.계좌보유수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌보유수량.Width = 97;
            // 
            // 계좌매입가
            // 
            this.계좌매입가.Text = "매입가";
            this.계좌매입가.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌매입가.Width = 97;
            // 
            // 계좌현재가
            // 
            this.계좌현재가.Text = "현재가";
            this.계좌현재가.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌현재가.Width = 86;
            // 
            // 계좌거래량
            // 
            this.계좌거래량.Text = "거래량";
            this.계좌거래량.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌거래량.Width = 104;
            // 
            // 계좌매입금액
            // 
            this.계좌매입금액.Text = "매입금액";
            this.계좌매입금액.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.계좌매입금액.Width = 107;
            // 
            // 계좌평가금액
            // 
            this.계좌평가금액.Text = "평가금액";
            // 
            // 계좌수익률
            // 
            this.계좌수익률.Text = "수익률";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 697);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusBar";
            // 
            // curTimeLabel
            // 
            this.curTimeLabel.BackColor = System.Drawing.Color.Black;
            this.curTimeLabel.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.curTimeLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.curTimeLabel.Location = new System.Drawing.Point(982, 30);
            this.curTimeLabel.Name = "curTimeLabel";
            this.curTimeLabel.Size = new System.Drawing.Size(268, 38);
            this.curTimeLabel.TabIndex = 6;
            this.curTimeLabel.Text = "현재시간표시";
            this.curTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTimer
            // 
            this.currentTimer.Tick += new System.EventHandler(this.currentTimer_Tick);
            // 
            // 추정자산
            // 
            this.추정자산.Frozen = true;
            this.추정자산.HeaderText = "추정자산";
            this.추정자산.Name = "추정자산";
            this.추정자산.ReadOnly = true;
            // 
            // 주문가능액
            // 
            this.주문가능액.Frozen = true;
            this.주문가능액.HeaderText = "주문가능액";
            this.주문가능액.Name = "주문가능액";
            this.주문가능액.ReadOnly = true;
            // 
            // 유가잔고액
            // 
            this.유가잔고액.Frozen = true;
            this.유가잔고액.HeaderText = "유가잔고액";
            this.유가잔고액.Name = "유가잔고액";
            this.유가잔고액.ReadOnly = true;
            // 
            // 당일매수액
            // 
            this.당일매수액.Frozen = true;
            this.당일매수액.HeaderText = "당일매수액";
            this.당일매수액.Name = "당일매수액";
            this.당일매수액.ReadOnly = true;
            // 
            // 당일매도액
            // 
            this.당일매도액.Frozen = true;
            this.당일매도액.HeaderText = "당일매도액";
            this.당일매도액.Name = "당일매도액";
            this.당일매도액.ReadOnly = true;
            // 
            // 매매수수료
            // 
            this.매매수수료.Frozen = true;
            this.매매수수료.HeaderText = "매매수수료";
            this.매매수수료.Name = "매매수수료";
            this.매매수수료.ReadOnly = true;
            // 
            // 매매세금
            // 
            this.매매세금.Frozen = true;
            this.매매세금.HeaderText = "매매세금";
            this.매매세금.Name = "매매세금";
            this.매매세금.ReadOnly = true;
            // 
            // 손익금
            // 
            this.손익금.Frozen = true;
            this.손익금.HeaderText = "손익금";
            this.손익금.Name = "손익금";
            this.손익금.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 719);
            this.Controls.Add(this.curTimeLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Planet B2503";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.계좌리스트)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loginBtn;
        private System.Windows.Forms.ToolStripButton settingBtn;
        private System.Windows.Forms.ToolStripButton logBtn;
        private System.Windows.Forms.ToolStripButton reportBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader 계좌종목코드;
        private System.Windows.Forms.ColumnHeader 계좌종목명;
        private System.Windows.Forms.ColumnHeader 계좌보유수량;
        private System.Windows.Forms.ColumnHeader 계좌매입가;
        private System.Windows.Forms.ColumnHeader 계좌현재가;
        private System.Windows.Forms.ColumnHeader 계좌거래량;
        private System.Windows.Forms.ColumnHeader 계좌매입금액;
        private System.Windows.Forms.ColumnHeader 계좌평가금액;
        private System.Windows.Forms.ColumnHeader 계좌수익률;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label curTimeLabel;
        private System.Windows.Forms.Timer currentTimer;
        private System.Windows.Forms.DataGridView 계좌리스트;
        private System.Windows.Forms.ListView 종목리스트;
        private System.Windows.Forms.ColumnHeader 체크;
        private System.Windows.Forms.ColumnHeader 상태;
        private System.Windows.Forms.ColumnHeader 종목코드;
        private System.Windows.Forms.ColumnHeader 종목명;
        private System.Windows.Forms.ColumnHeader 구분;
        private System.Windows.Forms.ColumnHeader 전일대비;
        private System.Windows.Forms.ColumnHeader 현재가;
        private System.Windows.Forms.ColumnHeader 등락률;
        private System.Windows.Forms.ColumnHeader 거래량;
        private System.Windows.Forms.ColumnHeader 편입가;
        private System.Windows.Forms.ColumnHeader 편입대비;
        private System.Windows.Forms.ColumnHeader 편입시간;
        private System.Windows.Forms.ColumnHeader 수익률;
        private System.Windows.Forms.ColumnHeader 매수조건식;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn 추정자산;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주문가능액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 유가잔고액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 당일매수액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 당일매도액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매매수수료;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매매세금;
        private System.Windows.Forms.DataGridViewTextBoxColumn 손익금;
    }
}

