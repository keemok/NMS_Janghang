﻿namespace NMS
{
    partial class ucMU
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btMu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btMu);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 140);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "기지국명";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btMu
            // 
            this.btMu.BackColor = System.Drawing.SystemColors.Control;
            this.btMu.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btMu.Location = new System.Drawing.Point(2, 45);
            this.btMu.Name = "btMu";
            this.btMu.Size = new System.Drawing.Size(225, 92);
            this.btMu.TabIndex = 1;
            this.btMu.Text = "MU";
            this.btMu.UseVisualStyleBackColor = false;
            // 
            // ucMU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(230, 140);
            this.Name = "ucMU";
            this.Size = new System.Drawing.Size(230, 140);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btMu;
    }
}