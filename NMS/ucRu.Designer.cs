namespace NMS
{
    partial class ucRu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btRU = new System.Windows.Forms.Button();
            this.btFM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.CadetBlue;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 4);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "역 명";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btRU
            // 
            this.btRU.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btRU.Location = new System.Drawing.Point(3, 50);
            this.btRU.Name = "btRU";
            this.btRU.Size = new System.Drawing.Size(110, 87);
            this.btRU.TabIndex = 2;
            this.btRU.Text = "RU";
            this.btRU.UseVisualStyleBackColor = true;
            // 
            // btFM
            // 
            this.btFM.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btFM.Location = new System.Drawing.Point(117, 50);
            this.btFM.Name = "btFM";
            this.btFM.Size = new System.Drawing.Size(110, 87);
            this.btFM.TabIndex = 3;
            this.btFM.Text = "FM";
            this.btFM.UseVisualStyleBackColor = true;
            // 
            // ucRu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btFM);
            this.Controls.Add(this.btRU);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucRu";
            this.Size = new System.Drawing.Size(230, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btRU;
        private System.Windows.Forms.Button btFM;
    }
}
