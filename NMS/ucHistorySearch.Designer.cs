namespace NMS
{
    partial class ucHistorySearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHistorySearch));
            this.panelGround2 = new System.Windows.Forms.Panel();
            this.ucErrorSearch1 = new Common.ucErrorSearch();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGround2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGround2
            // 
            this.panelGround2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelGround2.BackgroundImage")));
            this.panelGround2.Controls.Add(this.ucErrorSearch1);
            this.panelGround2.Controls.Add(this.label2);
            this.panelGround2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGround2.Location = new System.Drawing.Point(0, 0);
            this.panelGround2.Name = "panelGround2";
            this.panelGround2.Size = new System.Drawing.Size(1880, 870);
            this.panelGround2.TabIndex = 398;
            // 
            // ucErrorSearch1
            // 
            this.ucErrorSearch1.BackColor = System.Drawing.Color.Black;
            this.ucErrorSearch1.Location = new System.Drawing.Point(15, 72);
            this.ucErrorSearch1.Name = "ucErrorSearch1";
            this.ucErrorSearch1.Size = new System.Drawing.Size(1850, 790);
            this.ucErrorSearch1.TabIndex = 387;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1866, 54);
            this.label2.TabIndex = 386;
            this.label2.Text = "이     력     검     색";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucHistorySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGround2);
            this.Name = "ucHistorySearch";
            this.Size = new System.Drawing.Size(1880, 870);
            this.panelGround2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGround2;
        private Common.ucErrorSearch ucErrorSearch1;
        private System.Windows.Forms.Label label2;
    }
}
