namespace B2503
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.전체로그 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.송수신이벤트로그 = new System.Windows.Forms.RichTextBox();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.자동매매로그 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.조건식로그 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.디버깅로그 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 719);
            this.tabControl1.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.전체로그);
            this.tab1.Location = new System.Drawing.Point(4, 23);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(464, 692);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "전체";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // 전체로그
            // 
            this.전체로그.Dock = System.Windows.Forms.DockStyle.Fill;
            this.전체로그.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.전체로그.Location = new System.Drawing.Point(3, 3);
            this.전체로그.Name = "전체로그";
            this.전체로그.Size = new System.Drawing.Size(458, 686);
            this.전체로그.TabIndex = 1;
            this.전체로그.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.송수신이벤트로그);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "송수신이벤트";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // 송수신이벤트로그
            // 
            this.송수신이벤트로그.Dock = System.Windows.Forms.DockStyle.Fill;
            this.송수신이벤트로그.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.송수신이벤트로그.Location = new System.Drawing.Point(3, 3);
            this.송수신이벤트로그.Name = "송수신이벤트로그";
            this.송수신이벤트로그.Size = new System.Drawing.Size(458, 688);
            this.송수신이벤트로그.TabIndex = 0;
            this.송수신이벤트로그.Text = "";
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.자동매매로그);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Padding = new System.Windows.Forms.Padding(3);
            this.tab3.Size = new System.Drawing.Size(464, 693);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "자동매매로그";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // 자동매매로그
            // 
            this.자동매매로그.Dock = System.Windows.Forms.DockStyle.Fill;
            this.자동매매로그.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.자동매매로그.Location = new System.Drawing.Point(3, 3);
            this.자동매매로그.Name = "자동매매로그";
            this.자동매매로그.Size = new System.Drawing.Size(458, 687);
            this.자동매매로그.TabIndex = 1;
            this.자동매매로그.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.조건식로그);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(464, 693);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "조건식로그";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // 조건식로그
            // 
            this.조건식로그.Dock = System.Windows.Forms.DockStyle.Fill;
            this.조건식로그.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.조건식로그.Location = new System.Drawing.Point(0, 0);
            this.조건식로그.Name = "조건식로그";
            this.조건식로그.Size = new System.Drawing.Size(464, 693);
            this.조건식로그.TabIndex = 2;
            this.조건식로그.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.디버깅로그);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(464, 694);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "디버깅로그";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // 디버깅로그
            // 
            this.디버깅로그.Dock = System.Windows.Forms.DockStyle.Fill;
            this.디버깅로그.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.디버깅로그.Location = new System.Drawing.Point(0, 0);
            this.디버깅로그.Name = "디버깅로그";
            this.디버깅로그.Size = new System.Drawing.Size(464, 694);
            this.디버깅로그.TabIndex = 3;
            this.디버깅로그.Text = "";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 719);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "로그";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tab3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.RichTextBox 전체로그;
        private System.Windows.Forms.RichTextBox 송수신이벤트로그;
        private System.Windows.Forms.RichTextBox 자동매매로그;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox 조건식로그;
        private System.Windows.Forms.RichTextBox 디버깅로그;
    }
}