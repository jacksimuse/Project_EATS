
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
            this.BtnSend3 = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnConnect.Location = new System.Drawing.Point(151, 231);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(124, 29);
            this.BtnConnect.TabIndex = 6;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnDisconnect.Location = new System.Drawing.Point(281, 231);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(124, 29);
            this.BtnDisconnect.TabIndex = 7;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnSend1
            // 
            this.BtnSend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnSend1.Location = new System.Drawing.Point(56, 76);
            this.BtnSend1.Name = "BtnSend1";
            this.BtnSend1.Size = new System.Drawing.Size(142, 47);
            this.BtnSend1.TabIndex = 8;
            this.BtnSend1.Text = "Left";
            this.BtnSend1.UseVisualStyleBackColor = true;
            this.BtnSend1.Click += new System.EventHandler(this.BtnSend1_Click);
            // 
            // LblAlert
            // 
            this.LblAlert.AutoSize = true;
            this.LblAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LblAlert.Location = new System.Drawing.Point(236, 9);
            this.LblAlert.Name = "LblAlert";
            this.LblAlert.Size = new System.Drawing.Size(92, 25);
            this.LblAlert.TabIndex = 10;
            this.LblAlert.Text = "message";
            // 
            // BtnSend3
            // 
            this.BtnSend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnSend3.Location = new System.Drawing.Point(352, 76);
            this.BtnSend3.Name = "BtnSend3";
            this.BtnSend3.Size = new System.Drawing.Size(142, 47);
            this.BtnSend3.TabIndex = 12;
            this.BtnSend3.Text = "Right";
            this.BtnSend3.UseVisualStyleBackColor = true;
            this.BtnSend3.Click += new System.EventHandler(this.BtnSend3_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnBack.Location = new System.Drawing.Point(204, 107);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(142, 47);
            this.BtnBack.TabIndex = 13;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnStart.Location = new System.Drawing.Point(204, 54);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(142, 47);
            this.BtnStart.TabIndex = 14;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnStop.Location = new System.Drawing.Point(135, 169);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(142, 47);
            this.BtnStop.TabIndex = 15;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnPause.Location = new System.Drawing.Point(283, 169);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(142, 47);
            this.BtnPause.TabIndex = 15;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 272);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnSend3);
            this.Controls.Add(this.LblAlert);
            this.Controls.Add(this.BtnSend1);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "TestPublisher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnSend1;
        private System.Windows.Forms.Label LblAlert;
        private System.Windows.Forms.Button BtnSend3;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnPause;
    }
}

