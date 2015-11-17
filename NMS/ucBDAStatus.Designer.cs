namespace NMS
{
    partial class ucBDAStatus
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucBDAItem5 = new NMS.ucBDAItem();
            this.ucBDAItem6 = new NMS.ucBDAItem();
            this.ucBDAItem3 = new NMS.ucBDAItem();
            this.ucBDAItem4 = new NMS.ucBDAItem();
            this.ucBDAItem2 = new NMS.ucBDAItem();
            this.ucBDAItem1 = new NMS.ucBDAItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Blue;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1836, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BDA 상태정보";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.ucBDAItem5);
            this.panel1.Controls.Add(this.ucBDAItem6);
            this.panel1.Controls.Add(this.ucBDAItem3);
            this.panel1.Controls.Add(this.ucBDAItem4);
            this.panel1.Controls.Add(this.ucBDAItem2);
            this.panel1.Controls.Add(this.ucBDAItem1);
            this.panel1.Location = new System.Drawing.Point(3, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1834, 719);
            this.panel1.TabIndex = 1;
            // 
            // ucBDAItem5
            // 
            this.ucBDAItem5.Enabled = false;
            this.ucBDAItem5.Location = new System.Drawing.Point(706, 416);
            this.ucBDAItem5.Name = "ucBDAItem5";
            this.ucBDAItem5.Size = new System.Drawing.Size(395, 185);
            this.ucBDAItem5.TabIndex = 10;
            this.ucBDAItem5.Title = "BDA 5";
            // 
            // ucBDAItem6
            // 
            this.ucBDAItem6.Enabled = false;
            this.ucBDAItem6.Location = new System.Drawing.Point(1235, 416);
            this.ucBDAItem6.Name = "ucBDAItem6";
            this.ucBDAItem6.Size = new System.Drawing.Size(392, 185);
            this.ucBDAItem6.TabIndex = 11;
            this.ucBDAItem6.Title = "BDA 6";
            // 
            // ucBDAItem3
            // 
            this.ucBDAItem3.Enabled = false;
            this.ucBDAItem3.Location = new System.Drawing.Point(1235, 117);
            this.ucBDAItem3.Name = "ucBDAItem3";
            this.ucBDAItem3.Size = new System.Drawing.Size(392, 185);
            this.ucBDAItem3.TabIndex = 8;
            this.ucBDAItem3.Title = "BDA 3";
            // 
            // ucBDAItem4
            // 
            this.ucBDAItem4.Enabled = false;
            this.ucBDAItem4.Location = new System.Drawing.Point(207, 416);
            this.ucBDAItem4.Name = "ucBDAItem4";
            this.ucBDAItem4.Size = new System.Drawing.Size(393, 185);
            this.ucBDAItem4.TabIndex = 9;
            this.ucBDAItem4.Title = "BDA 4";
            // 
            // ucBDAItem2
            // 
            this.ucBDAItem2.Enabled = false;
            this.ucBDAItem2.Location = new System.Drawing.Point(706, 117);
            this.ucBDAItem2.Name = "ucBDAItem2";
            this.ucBDAItem2.Size = new System.Drawing.Size(395, 185);
            this.ucBDAItem2.TabIndex = 6;
            this.ucBDAItem2.Title = "BDA 2";
            // 
            // ucBDAItem1
            // 
            this.ucBDAItem1.Enabled = false;
            this.ucBDAItem1.Location = new System.Drawing.Point(207, 117);
            this.ucBDAItem1.Name = "ucBDAItem1";
            this.ucBDAItem1.Size = new System.Drawing.Size(393, 185);
            this.ucBDAItem1.TabIndex = 7;
            this.ucBDAItem1.Title = "BDA 1";
            // 
            // ucBDAStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucBDAStatus";
            this.Size = new System.Drawing.Size(1840, 780);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private ucBDAItem ucBDAItem5;
        private ucBDAItem ucBDAItem6;
        private ucBDAItem ucBDAItem3;
        private ucBDAItem ucBDAItem4;
        private ucBDAItem ucBDAItem2;
        private ucBDAItem ucBDAItem1;
    }
}
