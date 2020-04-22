namespace NMS
{
    partial class ucSYMainScreen
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.ucMU1 = new NMS.ucMU();
            this.ucRu1_1 = new NMS.ucRu();
            this.ucRu1_2 = new NMS.ucRu();
            this.ucRu1_3 = new NMS.ucRu();
            this.ucMU2 = new NMS.ucMU();
            this.ucMU3 = new NMS.ucMU();
            this.ucMU4 = new NMS.ucMU();
            this.ucRu2_1 = new NMS.ucRu();
            this.ucRu2_2 = new NMS.ucRu();
            this.ucRu2_3 = new NMS.ucRu();
            this.ucRu2_4 = new NMS.ucRu();
            this.ucRu3_1 = new NMS.ucRu();
            this.ucRu3_2 = new NMS.ucRu();
            this.ucRu3_3 = new NMS.ucRu();
            this.ucRu4_1 = new NMS.ucRu();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label24, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label25, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label26, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label27, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label30, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1620, 619);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 146);
            this.tableLayoutPanel1.TabIndex = 87;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(1, 1);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 35);
            this.label23.TabIndex = 0;
            this.label23.Text = "상태명";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(102, 1);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 35);
            this.label24.TabIndex = 0;
            this.label24.Text = "색상";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(1, 37);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 35);
            this.label25.TabIndex = 0;
            this.label25.Text = "정상";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Red;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Location = new System.Drawing.Point(127, 75);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.MaximumSize = new System.Drawing.Size(50, 30);
            this.label26.MinimumSize = new System.Drawing.Size(50, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 30);
            this.label26.TabIndex = 0;
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.YellowGreen;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.ForeColor = System.Drawing.Color.GreenYellow;
            this.label27.Location = new System.Drawing.Point(127, 39);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.MinimumSize = new System.Drawing.Size(50, 30);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 30);
            this.label27.TabIndex = 0;
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.Location = new System.Drawing.Point(1, 73);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 35);
            this.label28.TabIndex = 0;
            this.label28.Text = "장애";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(1, 109);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 36);
            this.label29.TabIndex = 0;
            this.label29.Text = "미수신";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Location = new System.Drawing.Point(127, 112);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.MaximumSize = new System.Drawing.Size(50, 30);
            this.label30.MinimumSize = new System.Drawing.Size(50, 30);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 30);
            this.label30.TabIndex = 0;
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMU1
            // 
            this.ucMU1.BackColor = System.Drawing.Color.Black;
            this.ucMU1.HasRuA = false;
            this.ucMU1.Location = new System.Drawing.Point(86, 139);
            this.ucMU1.MaximumSize = new System.Drawing.Size(230, 140);
            this.ucMU1.Name = "ucMU1";
            this.ucMU1.Size = new System.Drawing.Size(200, 140);
            this.ucMU1.TabIndex = 88;
            this.ucMU1.Title = "기지국명";
            // 
            // ucRu1_1
            // 
            this.ucRu1_1.BackColor = System.Drawing.Color.Black;
            this.ucRu1_1.ButtonName = "광 중계장치";
            this.ucRu1_1.Location = new System.Drawing.Point(348, 139);
            this.ucRu1_1.Name = "ucRu1_1";
            this.ucRu1_1.Size = new System.Drawing.Size(140, 140);
            this.ucRu1_1.TabIndex = 89;
            // 
            // ucRu1_2
            // 
            this.ucRu1_2.BackColor = System.Drawing.Color.Black;
            this.ucRu1_2.ButtonName = "광 중계장치";
            this.ucRu1_2.Location = new System.Drawing.Point(546, 139);
            this.ucRu1_2.Name = "ucRu1_2";
            this.ucRu1_2.Size = new System.Drawing.Size(140, 140);
            this.ucRu1_2.TabIndex = 90;
            // 
            // ucRu1_3
            // 
            this.ucRu1_3.BackColor = System.Drawing.Color.Black;
            this.ucRu1_3.ButtonName = "광 중계장치";
            this.ucRu1_3.Location = new System.Drawing.Point(746, 139);
            this.ucRu1_3.Name = "ucRu1_3";
            this.ucRu1_3.Size = new System.Drawing.Size(140, 140);
            this.ucRu1_3.TabIndex = 91;
            // 
            // ucMU2
            // 
            this.ucMU2.BackColor = System.Drawing.Color.Black;
            this.ucMU2.HasRuA = false;
            this.ucMU2.Location = new System.Drawing.Point(960, 139);
            this.ucMU2.MaximumSize = new System.Drawing.Size(230, 140);
            this.ucMU2.Name = "ucMU2";
            this.ucMU2.Size = new System.Drawing.Size(200, 140);
            this.ucMU2.TabIndex = 92;
            this.ucMU2.Title = "기지국명";
            // 
            // ucMU3
            // 
            this.ucMU3.BackColor = System.Drawing.Color.Black;
            this.ucMU3.HasRuA = false;
            this.ucMU3.Location = new System.Drawing.Point(1297, 397);
            this.ucMU3.MaximumSize = new System.Drawing.Size(230, 140);
            this.ucMU3.Name = "ucMU3";
            this.ucMU3.Size = new System.Drawing.Size(200, 140);
            this.ucMU3.TabIndex = 93;
            this.ucMU3.Title = "기지국명";
            // 
            // ucMU4
            // 
            this.ucMU4.BackColor = System.Drawing.Color.Black;
            this.ucMU4.HasRuA = false;
            this.ucMU4.Location = new System.Drawing.Point(351, 397);
            this.ucMU4.MaximumSize = new System.Drawing.Size(230, 140);
            this.ucMU4.Name = "ucMU4";
            this.ucMU4.Size = new System.Drawing.Size(200, 140);
            this.ucMU4.TabIndex = 94;
            this.ucMU4.Title = "기지국명";
            // 
            // ucRu2_1
            // 
            this.ucRu2_1.BackColor = System.Drawing.Color.Black;
            this.ucRu2_1.ButtonName = "광 중계장치";
            this.ucRu2_1.Location = new System.Drawing.Point(1205, 139);
            this.ucRu2_1.Name = "ucRu2_1";
            this.ucRu2_1.Size = new System.Drawing.Size(140, 140);
            this.ucRu2_1.TabIndex = 95;
            // 
            // ucRu2_2
            // 
            this.ucRu2_2.BackColor = System.Drawing.Color.Black;
            this.ucRu2_2.ButtonName = "광 중계장치";
            this.ucRu2_2.Location = new System.Drawing.Point(1395, 139);
            this.ucRu2_2.Name = "ucRu2_2";
            this.ucRu2_2.Size = new System.Drawing.Size(140, 140);
            this.ucRu2_2.TabIndex = 96;
            // 
            // ucRu2_3
            // 
            this.ucRu2_3.BackColor = System.Drawing.Color.Black;
            this.ucRu2_3.ButtonName = "광 중계장치";
            this.ucRu2_3.Location = new System.Drawing.Point(1574, 139);
            this.ucRu2_3.Name = "ucRu2_3";
            this.ucRu2_3.Size = new System.Drawing.Size(147, 140);
            this.ucRu2_3.TabIndex = 97;
            // 
            // ucRu2_4
            // 
            this.ucRu2_4.BackColor = System.Drawing.Color.Black;
            this.ucRu2_4.ButtonName = "광 중계장치";
            this.ucRu2_4.Location = new System.Drawing.Point(1574, 397);
            this.ucRu2_4.Name = "ucRu2_4";
            this.ucRu2_4.Size = new System.Drawing.Size(140, 140);
            this.ucRu2_4.TabIndex = 98;
            // 
            // ucRu3_1
            // 
            this.ucRu3_1.BackColor = System.Drawing.Color.Black;
            this.ucRu3_1.ButtonName = "광 중계장치";
            this.ucRu3_1.Location = new System.Drawing.Point(1077, 397);
            this.ucRu3_1.Name = "ucRu3_1";
            this.ucRu3_1.Size = new System.Drawing.Size(140, 140);
            this.ucRu3_1.TabIndex = 99;
            // 
            // ucRu3_2
            // 
            this.ucRu3_2.BackColor = System.Drawing.Color.Black;
            this.ucRu3_2.ButtonName = "광 중계장치";
            this.ucRu3_2.Location = new System.Drawing.Point(854, 397);
            this.ucRu3_2.Name = "ucRu3_2";
            this.ucRu3_2.Size = new System.Drawing.Size(140, 140);
            this.ucRu3_2.TabIndex = 100;
            // 
            // ucRu3_3
            // 
            this.ucRu3_3.BackColor = System.Drawing.Color.Black;
            this.ucRu3_3.ButtonName = "광 중계장치";
            this.ucRu3_3.Location = new System.Drawing.Point(641, 397);
            this.ucRu3_3.Name = "ucRu3_3";
            this.ucRu3_3.Size = new System.Drawing.Size(140, 140);
            this.ucRu3_3.TabIndex = 101;
            // 
            // ucRu4_1
            // 
            this.ucRu4_1.BackColor = System.Drawing.Color.Black;
            this.ucRu4_1.ButtonName = "광 중계장치";
            this.ucRu4_1.Location = new System.Drawing.Point(147, 397);
            this.ucRu4_1.Name = "ucRu4_1";
            this.ucRu4_1.Size = new System.Drawing.Size(140, 140);
            this.ucRu4_1.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1741, 10);
            this.label1.TabIndex = 103;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1741, 10);
            this.label2.TabIndex = 104;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1765, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 261);
            this.label3.TabIndex = 105;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(918, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 207);
            this.label4.TabIndex = 106;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1532, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 207);
            this.label5.TabIndex = 107;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(591, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 207);
            this.label6.TabIndex = 108;
            this.label6.Text = "label6";
            // 
            // ucSYMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucRu4_1);
            this.Controls.Add(this.ucRu3_3);
            this.Controls.Add(this.ucRu3_2);
            this.Controls.Add(this.ucRu3_1);
            this.Controls.Add(this.ucRu2_4);
            this.Controls.Add(this.ucRu2_3);
            this.Controls.Add(this.ucRu2_2);
            this.Controls.Add(this.ucRu2_1);
            this.Controls.Add(this.ucMU4);
            this.Controls.Add(this.ucMU3);
            this.Controls.Add(this.ucMU2);
            this.Controls.Add(this.ucRu1_3);
            this.Controls.Add(this.ucRu1_2);
            this.Controls.Add(this.ucRu1_1);
            this.Controls.Add(this.ucMU1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ucSYMainScreen";
            this.Size = new System.Drawing.Size(1840, 780);
            this.Load += new System.EventHandler(this.ucSYMainScreen_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        public ucMU ucMU1;
        public ucRu ucRu1_1;
        public ucRu ucRu1_2;
        public ucRu ucRu1_3;
        public ucMU ucMU2;
        public ucMU ucMU3;
        public ucMU ucMU4;
        public ucRu ucRu2_1;
        public ucRu ucRu2_2;
        public ucRu ucRu2_3;
        public ucRu ucRu2_4;
        public ucRu ucRu3_1;
        public ucRu ucRu3_2;
        public ucRu ucRu3_3;
        public ucRu ucRu4_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
