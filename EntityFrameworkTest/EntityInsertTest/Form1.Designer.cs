
namespace EntityInsertTest
{
    partial class Form1
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
            this.btnOrderCommit1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOrderCommit2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOrderCommit3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrderCommit1
            // 
            this.btnOrderCommit1.Location = new System.Drawing.Point(117, 148);
            this.btnOrderCommit1.Name = "btnOrderCommit1";
            this.btnOrderCommit1.Size = new System.Drawing.Size(132, 69);
            this.btnOrderCommit1.TabIndex = 0;
            this.btnOrderCommit1.Text = "DB 전송";
            this.btnOrderCommit1.UseVisualStyleBackColor = true;
            this.btnOrderCommit1.Click += new System.EventHandler(this.btnOrderCommit1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "주문 1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "주문 2 : 미구현";
            // 
            // btnOrderCommit2
            // 
            this.btnOrderCommit2.Location = new System.Drawing.Point(323, 148);
            this.btnOrderCommit2.Name = "btnOrderCommit2";
            this.btnOrderCommit2.Size = new System.Drawing.Size(132, 69);
            this.btnOrderCommit2.TabIndex = 2;
            this.btnOrderCommit2.Text = "DB 전송";
            this.btnOrderCommit2.UseVisualStyleBackColor = true;
            this.btnOrderCommit2.Click += new System.EventHandler(this.btnOrderCommit2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "주문 3 : 미구현";
            // 
            // btnOrderCommit3
            // 
            this.btnOrderCommit3.Location = new System.Drawing.Point(535, 148);
            this.btnOrderCommit3.Name = "btnOrderCommit3";
            this.btnOrderCommit3.Size = new System.Drawing.Size(132, 69);
            this.btnOrderCommit3.TabIndex = 4;
            this.btnOrderCommit3.Text = "DB 전송";
            this.btnOrderCommit3.UseVisualStyleBackColor = true;
            this.btnOrderCommit3.Click += new System.EventHandler(this.btnOrderCommit3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOrderCommit3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOrderCommit2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrderCommit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrderCommit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOrderCommit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOrderCommit3;
    }
}

