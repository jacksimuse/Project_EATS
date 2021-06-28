
namespace DeviceSubApp
{
    partial class FrmMain
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.BtnSend1 = new System.Windows.Forms.Button();
            this.LblAlert = new System.Windows.Forms.Label();
            this.BtnSend2 = new System.Windows.Forms.Button();
            this.BtnSend3 = new System.Windows.Forms.Button();
            this.BtnRotate = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnConnect.Location = new System.Drawing.Point(154, 221);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(124, 29);
            this.BtnConnect.TabIndex = 6;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnDisconnect.Location = new System.Drawing.Point(284, 221);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(124, 29);
            this.BtnDisconnect.TabIndex = 7;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnSend1
            // 
            this.BtnSend1.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnSend1.Location = new System.Drawing.Point(59, 64);
            this.BtnSend1.Name = "BtnSend1";
            this.BtnSend1.Size = new System.Drawing.Size(142, 47);
            this.BtnSend1.TabIndex = 8;
            this.BtnSend1.Text = "0";
            this.BtnSend1.UseVisualStyleBackColor = true;
            this.BtnSend1.Click += new System.EventHandler(this.BtnSend1_Click);
            // 
            // LblAlert
            // 
            this.LblAlert.AutoSize = true;
            this.LblAlert.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.LblAlert.Location = new System.Drawing.Point(239, 19);
            this.LblAlert.Name = "LblAlert";
            this.LblAlert.Size = new System.Drawing.Size(89, 23);
            this.LblAlert.TabIndex = 10;
            this.LblAlert.Text = "message";
            // 
            // BtnSend2
            // 
            this.BtnSend2.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnSend2.Location = new System.Drawing.Point(212, 64);
            this.BtnSend2.Name = "BtnSend2";
            this.BtnSend2.Size = new System.Drawing.Size(142, 47);
            this.BtnSend2.TabIndex = 11;
            this.BtnSend2.Text = "90";
            this.BtnSend2.UseVisualStyleBackColor = true;
            this.BtnSend2.Click += new System.EventHandler(this.BtnSend2_Click);
            // 
            // BtnSend3
            // 
            this.BtnSend3.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnSend3.Location = new System.Drawing.Point(365, 64);
            this.BtnSend3.Name = "BtnSend3";
            this.BtnSend3.Size = new System.Drawing.Size(142, 47);
            this.BtnSend3.TabIndex = 12;
            this.BtnSend3.Text = "180";
            this.BtnSend3.UseVisualStyleBackColor = true;
            this.BtnSend3.Click += new System.EventHandler(this.BtnSend3_Click);
            // 
            // BtnRotate
            // 
            this.BtnRotate.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnRotate.Location = new System.Drawing.Point(59, 117);
            this.BtnRotate.Name = "BtnRotate";
            this.BtnRotate.Size = new System.Drawing.Size(142, 47);
            this.BtnRotate.TabIndex = 13;
            this.BtnRotate.Text = "Rotate";
            this.BtnRotate.UseVisualStyleBackColor = true;
            this.BtnRotate.Click += new System.EventHandler(this.BtnRotate_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnStart.Location = new System.Drawing.Point(212, 117);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(142, 47);
            this.BtnStart.TabIndex = 14;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.BtnStop.Location = new System.Drawing.Point(365, 117);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(142, 47);
            this.BtnStop.TabIndex = 15;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 272);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnRotate);
            this.Controls.Add(this.BtnSend3);
            this.Controls.Add(this.BtnSend2);
            this.Controls.Add(this.LblAlert);
            this.Controls.Add(this.BtnSend1);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "TestPublisher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnSend1;
        private System.Windows.Forms.Label LblAlert;
        private System.Windows.Forms.Button BtnSend2;
        private System.Windows.Forms.Button BtnSend3;
        private System.Windows.Forms.Button BtnRotate;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
    }
}

