using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace NMS
{
    /// <summary>
    /// 사용자 정의 컨트롤에서의 제어 이벤트
    /// </summary>
    /// <param name="btCode">Click한 버튼 Code</param>
    /// <param name="index">주/예비, Wide/Narrow등등..</param>
    /// <param name="value">설정에 필요한 값</param>
    public delegate void UserControl_Control(byte btCode, byte index, byte value);

    public partial class ucSYMUStatus : UserControl
    {
        /// <summary>
        /// 사용자 정의 컨트롤에서의 제어 이벤트
        /// </summary>
        /// <param name="btCode">Click한 버튼 Code</param>
        public event UserControl_Control muControlClick = null;

        #region MU감시화면 컨트롤 배열
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private List<Button> btMURfMainSpare = new List<Button>();
        private List<Label> lblMURfMainSpare = new List<Label>();
        private List<Label> lblMURfMainSpareInquiry = new List<Label>();
        private List<TextBox> tbMURfMainSpare = new List<TextBox>();

        private List<Label> lblMUCHInfo = new List<Label>();
        private List<Label> lblMURXRSSI = new List<Label>();

        private List<PictureBox> pbMuOtherSt1 = new List<PictureBox>();
        private List<PictureBox> pbMuOtherSt = new List<PictureBox>();
        private List<PictureBox> pbMuOtherSt2 = new List<PictureBox>();

        private List<Label> lblRcName = new List<Label>();
		private List<PictureBox> pbMULifSt = new List<PictureBox>();

        //OPT 상태 관련
        private List<PictureBox> pbOptMonSt = new List<PictureBox>();
        private List<PictureBox> pbOptOtherSt = new List<PictureBox>();
        private List<PictureBox> pbOptAlarmSt = new List<PictureBox>();

        private List<Label> lblOptLd = new List<Label>();
        private List<Label> lblOptPd = new List<Label>();

        private List<PictureBox> pbPllLockSt = new List<PictureBox>();        
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion
        
        #region 기타 변수
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Timer tmrSendOutTest = new Timer();

        public bool flagSendOutTest = false;

        private Color colorSelect = new Color();    //선택 색
        private Color colorError = new Color();    //선택 색
        private Color colorBase = new Color();      //기본 색

        public bool flagMUEnabel = false;
        public bool flagFMEnabel = false;
        
        /// <summary>
        /// RU A 표시 상태
        /// </summary>
        private bool mRuAState = true;
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion

        public ucSYMUStatus()
        {
            switch (Common.clsNMS.nmsGUIUser)
            {
                case "과천선":
                case "분당선":
                    InitializeComponent();
                    break;

                case "과천선_Server":
                case "경의일산선":
                    //InitializeComponent_1280_1024();
                    break;

                default:
                    InitializeComponent();
                    break;
            }

            /*
            switch (clsCommon.nmsGUIUser)
            {
                case "분당선":
                    InitializeComponent_분당선();
                    break;

                case "영주댐":
                case "태백선":
                    InitializeComponent();
                    break;

                case "경의선":
                    InitializeComponent_경의선();
                    break;
            }
            */

            #region MU감시화면 컨트롤 배열
            //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //private ArrayList btMURfMainSpare = new ArrayList();
            btMURfMainSpare.Add(btMURfMainSpare1); btMURfMainSpare.Add(btMURfMainSpare2);
            //private ArrayList lblMURfMainSpare = new ArrayList();
            lblMURfMainSpare.Add(lblMURfMain); lblMURfMainSpare.Add(lblMURfSpare);
            //private List<Label> lblMURfMainSpareInquiry = new List<Label>();
            lblMURfMainSpareInquiry.Add(lblMURfMainInquiry); lblMURfMainSpareInquiry.Add(lblMURfSpareInquiry);
            //private ArrayList tbMURfMainSpare = new ArrayList();
            tbMURfMainSpare.Add(tbMURfMain); tbMURfMainSpare.Add(tbMURfSpare);

            //private ArrayList lblMUCHInfo = new ArrayList();
            lblMUCHInfo.Add(lblMUCHInfo1); lblMUCHInfo.Add(lblMUCHInfo2); lblMUCHInfo.Add(lblMUCHInfo3);
            //private ArrayList lblMURXRSSI = new ArrayList();
            lblMURXRSSI.Add(lblMURXRSSI1); lblMURXRSSI.Add(lblMURXRSSI2); lblMURXRSSI.Add(lblMURXRSSI3);

            //private List<PictureBox> pbMuOtherSt1 = new List<PictureBox>();
            pbMuOtherSt1.Add(pbMUAutoManual1); pbMuOtherSt1.Add(pbMUMainSpare1); pbMuOtherSt1.Add(pbMUWideNarrow1);
            pbMuOtherSt1.Add(pbMUAC); pbMuOtherSt1.Add(ucLif1.pbMUDC);
            pbMuOtherSt1.Add(ucLif1.pbMUModOpen);
            pbMuOtherSt1.Add(ucLif1.pbMURCSt1); pbMuOtherSt1.Add(ucLif1.pbMURCSt2);

            //private List<PictureBox> pbMuOtherSt = new List<PictureBox>();
            pbMuOtherSt.Add(pbMUAutoManual2); pbMuOtherSt.Add(pbMUMainSpare2); pbMuOtherSt.Add(pbMUWideNarrow2);

            //private List<PictureBox> pbMuOtherSt2 = new List<PictureBox>();
            pbMuOtherSt2.Add(ucLif1.pbMURCSt3); pbMuOtherSt2.Add(ucLif1.pbMURCSt4);
            pbMuOtherSt2.Add(pbMUSRSt1); pbMuOtherSt2.Add(pbMUSRSt2); pbMuOtherSt2.Add(pbMUSRSt3); pbMuOtherSt2.Add(pbMUSRSt4); pbMuOtherSt2.Add(pbMUSRSt5);

            //private List<Label> lblRcName = new List<Label>();
            lblRcName.Add(ucLif1.lblRcName1); lblRcName.Add(ucLif1.lblRcName2); lblRcName.Add(ucLif1.lblRcName3); lblRcName.Add(ucLif1.lblRcName4); lblRcName.Add(ucLif1.lblRcName5); lblRcName.Add(ucLif1.lblRcName6);

            //private List<PictureBox> pbMULifSt = new List<PictureBox>();
            pbMULifSt.Add(ucLif1.pbMULifSt1); pbMULifSt.Add(ucLif1.pbMULifSt2); pbMULifSt.Add(ucLif1.pbMULifSt3); pbMULifSt.Add(ucLif1.pbMULifSt4); pbMULifSt.Add(ucLif1.pbMULifSt5); pbMULifSt.Add(ucLif1.pbMULifSt6);

            //OPT 상태 관련
            //private List<PictureBox> pbOptMonSt = new List<PictureBox>();
            pbOptMonSt.Add(pbMUMon1); pbOptMonSt.Add(pbMUMon2); pbOptMonSt.Add(pbMUMon3);
            pbOptMonSt.Add(pbMUMon4); pbOptMonSt.Add(pbMUMon5); pbOptMonSt.Add(pbMUMon6);
            //private List<PictureBox> pbOptOtherSt = new List<PictureBox>();
            pbOptOtherSt.Add(pbMUOther1); pbOptOtherSt.Add(pbMUOther2); pbOptOtherSt.Add(pbMUOther3);
            //private List<PictureBox> pbOptAlarmSt = new List<PictureBox>();
            pbOptAlarmSt.Add(pbMUOptAlarm1); pbOptAlarmSt.Add(pbMUOptAlarm2); pbOptAlarmSt.Add(pbMUOptAlarm3); pbOptAlarmSt.Add(pbMUOptAlarm4);
            pbOptAlarmSt.Add(pbMUOptAlarm5); pbOptAlarmSt.Add(pbMUOptAlarm6); pbOptAlarmSt.Add(pbMUOptAlarm7); pbOptAlarmSt.Add(pbMUOptAlarm8);

            //private List<Label> lblOptLd = new List<Label>();
            lblOptLd.Add(lblOptLd1); lblOptLd.Add(lblOptLd2); lblOptLd.Add(lblOptLd3); lblOptLd.Add(lblOptLd4);
            //private List<Label> lblOptPd = new List<Label>();
            lblOptPd.Add(lblOptPd1); lblOptPd.Add(lblOptPd2); lblOptPd.Add(lblOptPd3); lblOptPd.Add(lblOptPd4);

            //private List<PictureBox> pbPllLockSt = new List<PictureBox>();
            pbPllLockSt.Add(pbMUPllLock1); pbPllLockSt.Add(pbMUPllLock2); pbPllLockSt.Add(pbMUPllLock3);
            //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            #endregion
        }

        private void ucMUSt_Load(object sender, EventArgs e)
        {
            colorSelect = Color.Lime;
            colorError = Color.Red;
            colorBase = SystemColors.Control;

            //MU화면의 주/예비 절체 버튼
            btMUMainSpare1.Tag = 0;
            btMUMainSpare2.Tag = 1;

            //MU화면의 자동/수동 절체 버튼
            btMUAutoManual1.Tag = 0;
            btMUAutoManual2.Tag = 1;

            //MU화면의 주/예비 RF 출력 버튼
            btMURfMainSpare1.Tag = 0;
            btMURfMainSpare2.Tag = 1;
           
            tmrSendOutTest.Interval = 10000;
            tmrSendOutTest.Tick += new EventHandler(tmrSendOutTest_Tick);
        }

        #region 컨트롤 제어(문자출력, 활성화 변경, 색변경)
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //컨트롤의 위치/크기 지정
        private void SetLocationSize(Control control, int width, int height, int left, int top)
        {
            if (control.InvokeRequired)
            {
                SetControlLocationSizeCallback d = new SetControlLocationSizeCallback(SetLocationSize);
                this.Invoke(d, new object[] { control, width, height, left, top });
            }
            else
            {
                control.Width = width;
                control.Height = height;
                control.Left = left;
                control.Top = top;
            }
        }

        //컨트롤에 문자를 출력하기 위함
        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        //컨트롤에 문자를 출력하기 위함
        private void SetTextAppend(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextAppend);
                this.Invoke(d, new object[] { control, text });
            }
            else
            {
                if (((TextBox)control).Text.Length > 2048)
                    ((TextBox)control).Text = ((TextBox)control).Text.Substring(1024);
                //if (((TextBox)control).Text.Length > 1024)
                //    ((TextBox)control).Text = ((TextBox)control).Text.Substring(512);

                ((TextBox)control).Text += text;

                ((TextBox)control).SelectionStart = ((TextBox)control).Text.Length;//맨 마지막 선택...
                ((TextBox)control).ScrollToCaret();
            }
        }

        //컨트롤의 활성화 여부를 결정하기 위함
        private void SetEnable(Control control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(SetEnable);
                this.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Enabled = flag;
            }
        }

        //컨트롤에 색을 변경하기 위함
        private void SetColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                this.Invoke(d, new object[] { control, color });
            }
            else
            {
                control.BackColor = color;
            }
        }

        //컨트롤의 글자색을 변경하기 위함
        private void SetForeColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetForeColor);
                this.Invoke(d, new object[] { control, color });
            }
            else
            {
                control.ForeColor = color;
            }
        }

        //컨트롤의 Visible값을 변경하기 위함
        private void SetVisible(Control control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(SetVisible);
                this.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Visible = flag;
            }
        }

        //컨트롤에 체크하기 위함
        private void SetChecked(CheckBox control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetCheckedCallback d = new SetCheckedCallback(SetChecked);
                this.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Checked = flag;
            }
        }

        //컨트롤에 체크하기 위함
        private void SetRdButChecked(RadioButton control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetRdButCheckedCallback d = new SetRdButCheckedCallback(SetRdButChecked);
                this.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Checked = flag;
            }
        }

        //컨트롤의 Value값을 변경하기 위함
        private void SetValue(ProgressBar control, int maxValue, int value)
        {
            if (control.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                this.Invoke(d, new object[] { control, maxValue, value });
            }
            else
            {
                control.Maximum = maxValue;
                control.Value = value;
            }
        }

        //TrackBar 컨트롤에 value값을 변경하기 위함
        private void SetValue(TrackBar control, int value)
        {
            if (control.InvokeRequired)
            {
                SetTBValueCallback d = new SetTBValueCallback(SetValue);
                this.Invoke(d, new object[] { control, value });
            }
            else
            {
                control.Value = value;
            }
        }

        //PictureBox에 그림을 변경하기 위함
        private void SetImage(PictureBox control, Bitmap bitmap)
        {
            if (control.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                this.Invoke(d, new object[] { control, bitmap });
            }
            else
            {
                control.Image = bitmap;
            }
        }

        //ListView 컨트롤의 Item을 삭제하기 위함
        private void SetListViewItemClear(ListView lvControl)
        {
            if (lvControl.InvokeRequired)
            {
                SetListViewItemClearCallback d = new SetListViewItemClearCallback(SetListViewItemClear);
                this.Invoke(d, new object[] { lvControl });
            }
            else
            {
                lvControl.Items.Clear();
            }
        }

        //ListView 컨트롤의 Item을 추가하기 위함
        private void SetListViewItemInster(ListView lvControl, int index, ListViewItem lvItem)
        {
            if (lvControl.InvokeRequired)
            {
                SetListViewItemInsertCallback d = new SetListViewItemInsertCallback(SetListViewItemInster);
                this.Invoke(d, new object[] { lvControl, index, lvItem });
            }
            else
            {
                lvControl.Items.Insert(index, lvItem);
            }
        }

        //DataGridView의 모든 Row를 삭제하기 위함
        private void SetdataGridViewClear(DataGridView dgvControl)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewClearCallback d = new SetdataGridViewClearCallback(SetdataGridViewClear);
                this.Invoke(d, new object[] { dgvControl });
            }
            else
            {
                dgvControl.Rows.Clear();
            }
        }

        private void SetdataGridViewMuErrorStValue(DataGridView dgvControl, int index, string dateTime, string content)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuErrorStValueCallback d = new SetdataGridViewMuErrorStValueCallback(SetdataGridViewMuErrorStValue);
                this.Invoke(d, new object[] { dgvControl, index, dateTime, content });
            }
            else
            {
                dgvControl.Rows.Add();
                //dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
                dgvControl.Rows[index].Cells[1].Value = dateTime;       //날자/시간
                dgvControl.Rows[index].Cells[2].Value = content;    //내용
            }
        }

        private void SetdataGridViewMuErrorStIndex(DataGridView dgvControl, int index, string dateTime, string content)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuErrorStValueCallback d = new SetdataGridViewMuErrorStValueCallback(SetdataGridViewMuErrorStIndex);
                this.Invoke(d, new object[] { dgvControl, index, dateTime, content });
            }
            else
            {
                dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
            }
        }

        private void SetdataGridViewMuTxRxErxStValue(DataGridView dgvControl, int index, string content, string ch, string startDateTime, string stopDateTime)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuTxRxErxStValueCallback d = new SetdataGridViewMuTxRxErxStValueCallback(SetdataGridViewMuTxRxErxStValue);
                this.Invoke(d, new object[] { dgvControl, index, content, ch, startDateTime, stopDateTime });
            }
            else
            {
                dgvControl.Rows.Add();
                dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
                dgvControl.Rows[index].Cells[1].Value = content;    //내용
                dgvControl.Rows[index].Cells[2].Value = ch;         //채널
                dgvControl.Rows[index].Cells[3].Value = startDateTime;  //시작시간
                dgvControl.Rows[index].Cells[4].Value = stopDateTime;   //중지시간
            }
        }
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion

        /// <summary>
        /// MU의 Title을 설정한다.
        /// </summary>
        /// <param name="title">title</param>
        public void SetTitle(string title)
        {
            SetText(lblMainTitle, title);                
        }

        /// <summary>
        /// RuA 상태를 표시함
        /// </summary>
        /// <param name="visible"></param>
        public void SetVisibleRuAState(bool visible)
        {
            //RuA 상태를 표시하지 않을 때
            if (!visible)
            {
                pbMUACU.Location = new Point(76, 99);
                lblMUACU.Location = new Point(104, 103);

                mRuAState = visible;
                

            }

            pbMURUASt.Visible = visible;
            lblMURUASt.Visible = visible;
        }

        public void SetMode(byte mode)
        {
            switch (mode)
            {
                case 0:     //과천선 Server(1280X1024 화면)
                    panelMuAntennaMatchungUnit.Left = 9;
                    panelMu무선송수신기.Left = 194;
                    panelMu무선송수신기예비.Left = 594;
                    panelMu무선수신기.Left = 994;
                    panelMu무전기형식.Left = 9;
                    panelMuPowerSupply.Left = 9;
                    panelMu기타상태.Left = 9;
                    panelMu유무선부감시장치.Left = 194;
                    panelMuVer.Left = 594;
                    panelMu채널복귀.Left = 994;
                    break;

                case 1:     //경의선 MU 화면(1280X1024 화면에 감청무선수신기, Ver등 안보이게 처리)
                    panelMuAntennaMatchungUnit.Left = 89;
                    panelMu무선송수신기.Left = 304;
                    panelMu무선송수신기예비.Left = 734;
                    SetVisible(panelMu무선수신기, false); panelMu무선수신기.Left = 1211;
                    panelMu무전기형식.Left = 89;
                    panelMuPowerSupply.Left = 89;
                    panelMu기타상태.Left = 89;
                    panelMu유무선부감시장치.Left = 304;
                    SetVisible(panelMuVer, false); panelMuVer.Left = 1211;
                    panelMu채널복귀.Left = 734;

                    panelMu채널복귀.Width = 394;
                    panel채널복귀내부.Width = 390;
                    lbl채널복귀시간제목.Width = 390;
                    lbl채널복귀시간1.Left = 114; lbl채널복귀시간1.Top = 88;
                    lblMUChReturnTime.Left = 221; lblMUChReturnTime.Top = 81;
                    lbl채널복귀시간2.Left = 124; lbl채널복귀시간2.Top = 165;
                    tbMUChReturnTime.Left = 212; tbMUChReturnTime.Top = 161;
                    btMUChReturnTime.Left = 147; btMUChReturnTime.Top = 241;
                    break;

                case 2:     //과천선, 분당선 6번 MU부터..(1920X1080 화면)
                    panelMuAntennaMatchungUnit.Left = 35;
                    panelMu무선송수신기.Left = 331;
                    panelMu무선송수신기예비.Left = 841;
                    SetVisible(panelMu무선수신기, true); panelMu무선수신기.Left = 1351;
                    panelMu무전기형식.Left = 35;
                    panelMuPowerSupply.Left = 35;
                    panelMu기타상태.Left = 35;
                    panelMu유무선부감시장치.Left = 331;
                    SetVisible(panelMuVer, true); panelMuVer.Left = 841;
                    panelMu채널복귀.Left = 1351;

                    panelMu채널복귀.Width     = 450;
                    panel채널복귀내부.Width   = 446;
                    lbl채널복귀시간제목.Width = 446;
                    lbl채널복귀시간1.Left  = 123; lbl채널복귀시간1.Top  = 110;
                    lblMUChReturnTime.Left = 269; lblMUChReturnTime.Top = 109;
                    lbl채널복귀시간2.Left  = 126; lbl채널복귀시간2.Top  = 157;
                    tbMUChReturnTime.Left  = 275; tbMUChReturnTime.Top  = 147;
                    btMUChReturnTime.Left  = 125; btMUChReturnTime.Top  = 203;
                    break;

                case 3:     //분당선 1번 ~ 5번 MU까지..(1920X1080 화면에 감청무선수신기, Ver등 안보이게 처리)
                    panelMuAntennaMatchungUnit.Left = 218;
                    panelMu무선송수신기.Left = 564;
                    panelMu무선송수신기예비.Left = 1124;
                    SetVisible(panelMu무선수신기, false); panelMu무선수신기.Left = 1829;
                    panelMu무전기형식.Left = 218;
                    panelMuPowerSupply.Left = 218;
                    panelMu기타상태.Left = 218;
                    panelMu유무선부감시장치.Left = 564;
                    SetVisible(panelMuVer, false); panelMuVer.Left = 1829;
                    panelMu채널복귀.Left = 1124;

                    panelMu채널복귀.Width = 494;
                    panel채널복귀내부.Width = 490;
                    lbl채널복귀시간제목.Width = 490;
                    lbl채널복귀시간1.Left = 145; lbl채널복귀시간1.Top = 110;
                    lblMUChReturnTime.Left = 291; lblMUChReturnTime.Top = 109;
                    lbl채널복귀시간2.Left = 148; lbl채널복귀시간2.Top = 157;
                    tbMUChReturnTime.Left = 297; tbMUChReturnTime.Top = 147;
                    btMUChReturnTime.Left = 147; btMUChReturnTime.Top = 203;
                    break;

                    ///성남 여주선
                case 4:
                         panelMuAntennaMatchungUnit.Left = 35;
                    panelMu무선송수신기.Left = 331;
                    panelMu무선송수신기예비.Left = 841;
                    SetVisible(panelMu무선수신기, true); panelMu무선수신기.Left = 1351;
                    panelMu무전기형식.Left = 35;
                    panelMuPowerSupply.Left = 35;
                    panelMu기타상태.Left = 35;
                    panelMu유무선부감시장치.Left = 331;
                    SetVisible(panelMuVer, true); panelMuVer.Left = 841;
                    panelMu채널복귀.Left = 1351;

                    panelMu채널복귀.Width     = 450;
                    panel채널복귀내부.Width   = 446;
                    lbl채널복귀시간제목.Width = 446;
                    lbl채널복귀시간1.Left  = 123; lbl채널복귀시간1.Top  = 110;
                    lblMUChReturnTime.Left = 269; lblMUChReturnTime.Top = 109;
                    lbl채널복귀시간2.Left  = 126; lbl채널복귀시간2.Top  = 157;
                    tbMUChReturnTime.Left  = 275; tbMUChReturnTime.Top  = 147;
                    btMUChReturnTime.Left  = 125; btMUChReturnTime.Top  = 203;

                    //SetVisibleRuAState(false);

                    break;
            }
        }

        /// <summary>
        /// 유/무선부 감시장치중 RC의 이름을 설정한다.
        /// </summary>
        /// <param name="rcName">RC 이름</param>
        public void RCNameSet(string[] rcName)
        {
            for (int i = 1; i < 4; i++)
                SetText(lblRcName[i], rcName[i]);
        }

        /// <summary>
        /// MU 상태를 초기화(활성화/비활성화)한다.
        /// </summary>
        /// <param name="flagAction">활성화/비활성화</param>
        public void MuStInit(bool flagAction)
        {
            int i = 0;

            flagMUEnabel = flagAction;

            SetEnable(ucLif1, flagAction);

            //SetEnable(panelMuAntennaMatchungUnit, flagAction);
            SetColor(btMUMainSpare1, SystemColors.Control);
            SetColor(btMUMainSpare2, SystemColors.Control);
            SetColor(btMUAutoManual1, SystemColors.Control);
            SetColor(btMUAutoManual2, SystemColors.Control);
            SetEnable(btMUMainSpare1, flagAction);
            SetEnable(btMUMainSpare2, flagAction);
            SetEnable(btMUAutoManual1, flagAction);
            SetEnable(btMUAutoManual2, flagAction);

            //SetEnable(panelMu무선송수신기, flagAction);
            SetEnable(gbMu주_송수신기채널정보, flagAction);
            SetEnable(gbMu주_송수신동작상태, flagAction);
            SetEnable(gbMu주_송수신장애상태, flagAction);
            SetEnable(gbMu주_송신출력설정, flagAction);
            SetEnable(btMUSendOutTest, flagAction);
			SetEnable(btMUSendOutTest1, flagAction);
			SetImage(pbMUSRSt1, Common.Properties.Resources.st_OFF);
            SetImage(pbMUSRSt2, Common.Properties.Resources.st_OFF);
            SetImage(pbMUPllLock1, Common.Properties.Resources.st_OFF);
            SetImage(pbMUMon1, Common.Properties.Resources.st_OFF);
            SetEnable(pbMUSRSt1, flagAction);
            SetEnable(pbMUSRSt2, flagAction);
            SetEnable(pbMUPllLock1, flagAction);
            SetEnable(pbMUMon1, flagAction);
            
            //SetEnable(panelMu무선송수신기예비, flagAction);
            SetEnable(gbMu예비_송수신기채널정보, flagAction);
            SetEnable(gbMu예비_송수신동작상태, flagAction);
            SetEnable(gbMu예비_송수신장애상태, flagAction);
            SetEnable(gbMu예비_송신출력설정, flagAction);
            SetImage(pbMUSRSt3, Common.Properties.Resources.st_OFF);
            SetImage(pbMUSRSt4, Common.Properties.Resources.st_OFF);
            SetImage(pbMUPllLock2, Common.Properties.Resources.st_OFF);
            SetImage(pbMUMon2, Common.Properties.Resources.st_OFF);

            //SetEnable(panelMu무선수신기, flagAction);
            SetEnable(gbMu감청수신기_채널정보, flagAction);
            SetEnable(gbMu감청수신기_동작상태, flagAction);
            SetEnable(gbMu감청수신기_장애상태, flagAction);
            SetImage(pbMUSRSt5, Common.Properties.Resources.st_OFF);
            SetImage(pbMUPllLock3, Common.Properties.Resources.st_OFF);
            SetImage(pbMUMon3, Common.Properties.Resources.st_OFF);
            SetEnable(pbMUSRSt5, flagAction);
            SetEnable(pbMUPllLock3, flagAction);
            SetEnable(pbMUMon3, flagAction);

            //SetEnable(panelMu광전송부감시상태, flagAction);
            SetEnable(ucLif1.lbl통신상태, flagAction);
            SetEnable(ucLif1.lblPtt, flagAction);
			SetEnable(lbl광전송부감시상태1, flagAction);
            SetEnable(lbl광전송부감시상태2, flagAction);
            SetEnable(lbl광전송부감시상태3, flagAction);
            SetEnable(lblMUOPTDCValue, flagAction);
            for (i = 0; i < 4; i++)
            {
                SetEnable(lblOptLd[i], flagAction);
                SetEnable(lblOptPd[i], flagAction);
            }
            for (i = 0; i < 3; i++)
            {
                SetImage(pbOptOtherSt[i], Common.Properties.Resources.st_OFF);
                SetEnable(pbOptOtherSt[i], flagAction);
            }
            for (i = 0; i < 8; i++)
            {
                SetImage(pbOptAlarmSt[i], Common.Properties.Resources.st_OFF);
                SetEnable(pbOptAlarmSt[i], flagAction);
            }

            //SetEnable(panelMu채널복귀, flagAction);
            SetEnable(lbl채널복귀시간1, flagAction);
            SetEnable(lbl채널복귀시간2, flagAction);
            SetEnable(lblMUChReturnTime, flagAction);
            SetEnable(tbMUChReturnTime, flagAction);
            SetEnable(btMUChReturnTime, flagAction);

            //SetEnable(panelMu무전기형식, flagAction);
            SetEnable(lblMUWideNarrowChange1, flagAction);
            SetEnable(lblMUWideNarrowChange2, flagAction);
            SetEnable(pbMUWideNarrow2, flagAction);
            SetImage(pbMUWideNarrow1, Common.Properties.Resources.st_OFF);
            SetImage(pbMUWideNarrow2, Common.Properties.Resources.st_OFF);
            SetEnable(pbMUWideNarrow1, flagAction);
            SetEnable(pbMUWideNarrow2, flagAction);
            SetEnable(btMUWideNarrowChange, flagAction);

            //SetEnable(panelMuPowerSupply, flagAction);
            SetEnable(lblPowerSupply, flagAction);
            SetImage(pbMUAC, Common.Properties.Resources.st_OFF);
            SetEnable(pbMUAC, flagAction);
			SetImage(pbMUPowerMain, Common.Properties.Resources.st_OFF);
			SetEnable(pbMUPowerMain, flagAction);
			SetImage(pbMUPowerStby, Common.Properties.Resources.st_OFF);
			SetEnable(pbMUPowerStby, flagAction);
            SetEnable(lblMUPowerMain, flagAction);
            SetEnable(lblMUPowerStby, flagAction);

            //SetEnable(panelMu유무선부감시장치, flagAction);
            SetEnable(ucLif1.lbl유무선감시장치1, flagAction);
            SetEnable(ucLif1.lbl유무선감시장치2, flagAction);
            SetEnable(ucLif1.lblRcName1, flagAction);
            SetEnable(ucLif1.lblRcName2, flagAction);
            SetEnable(ucLif1.lblRcName3, flagAction);
            SetEnable(ucLif1.lblRcName4, flagAction);
            SetEnable(ucLif1.lblRcName5, flagAction);
            SetEnable(ucLif1.lblRcName6, flagAction);
            SetEnable(ucLif1.lblMUDCValue, flagAction);
            SetImage(ucLif1.pbMUDC, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMUModOpen, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt1, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt2, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt3, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt4, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt5, Common.Properties.Resources.st_OFF);
            SetImage(ucLif1.pbMURCSt6, Common.Properties.Resources.st_OFF);

			for (i = 0; i < 6; i++)
				SetImage(pbMULifSt[i], Common.Properties.Resources.st_OFF);

            SetEnable(ucLif1.pbMUDC, flagAction);
            SetEnable(ucLif1.pbMUModOpen, flagAction);
            SetEnable(ucLif1.pbMURCSt1, flagAction);
            SetEnable(ucLif1.pbMURCSt2, flagAction);
            SetEnable(ucLif1.pbMURCSt3, flagAction);
            SetEnable(ucLif1.pbMURCSt4, flagAction);
            SetEnable(ucLif1.pbMURCSt5, flagAction);

            SetEnable(ucLif1.lblRepeat, flagAction);
            SetImage(ucLif1.pbMURepeatPttSt, Common.Properties.Resources.st_OFF);

            //SetEnable(panelMu기타상태, flagAction);
            SetEnable(lblMUMon4, flagAction);
            SetEnable(lblMUMon5, flagAction);
            SetEnable(lblMUMon6, flagAction);
            for (i = 3; i < 6; i++)
            {
                SetImage(pbOptMonSt[i], Common.Properties.Resources.st_OFF);
                SetEnable(pbOptMonSt[i], flagAction);
            }
			SetEnable(lblMUACU, flagAction);
			SetImage(pbMUACU, Common.Properties.Resources.st_OFF);
			SetEnable(pbMUACU, flagAction);

            SetEnable(lblMURUASt, flagAction);
            SetImage(pbMURUASt, Common.Properties.Resources.st_OFF);
            SetEnable(pbMURUASt, flagAction);

            //SetEnable(panelMUVer, flagAction);
            SetEnable(gbMainVer, flagAction);
            SetEnable(gbStbyVer, flagAction);
            SetEnable(gbMonVer, flagAction);
            SetEnable(gbAcuVer, flagAction);
            SetEnable(gbWN, flagAction);
            SetEnable(gbDC, flagAction);

            SetImage(pbDC, Common.Properties.Resources.st_OFF);

            /*
            switch (Common.clsNMS.nmsGUIUser)
            {
                case "분당선":
                    if (flagAction)
                    {
                        if (Common.clsNMS.presentMUID <= 5)
                        {
                            //SetEnable(panelMu무선수신기, flagAction);
                            SetEnable(gbMu감청수신기_채널정보, false);
                            SetEnable(gbMu감청수신기_동작상태, false);
                            SetEnable(gbMu감청수신기_장애상태, false);
                            SetImage(pbMUSRSt5, Common.Properties.Resources.st_OFF);
                            SetImage(pbMUPllLock3, Common.Properties.Resources.st_OFF);
                            SetImage(pbMUMon3, Common.Properties.Resources.st_OFF);
                            SetEnable(pbMUSRSt5, false);
                            SetEnable(pbMUPllLock3, false);
                            SetEnable(pbMUMon3, false);

                            //SetEnable(panelMUVer, flagAction);
                            SetEnable(gbMainVer, false);
                            SetEnable(gbStbyVer, false);
                            SetEnable(gbMonVer, false);
                            SetEnable(gbAcuVer, false);
                            SetEnable(gbWN, false);
                            SetEnable(gbDC, false);
                            SetImage(pbDC, Common.Properties.Resources.st_OFF);
                        }
                    }
                    break;            
            }
            */
        }

        /// <summary>
        /// FM 상태를 초기화(활성화/비활성화)한다.
        /// </summary>
        /// <param name="flagAction">활성화/비활성화</param>
        public void FmStInit(bool flagAction)
        {
            flagFMEnabel = flagAction;

            //SetEnable(panelMuFM, flagAction);
            SetImage(pbAcInputFail, Common.Properties.Resources.st_OFF);
            SetImage(pbDCOutputFail, Common.Properties.Resources.st_OFF);
            SetImage(pbLDAlarm, Common.Properties.Resources.st_OFF);
            SetImage(pbPDAlarm, Common.Properties.Resources.st_OFF);
            SetEnable(gbPower, flagAction);
            SetEnable(gbBettery, flagAction);
            SetEnable(gbOther, flagAction);

        }

        /// <summary>
        /// MU 상태를 표시한다.
        /// </summary>
        /// <param name="muID">muID</param>
        /// <param name="muData">MU의 상태 Data</param>
        /// <param name="baseSt">주장치의 Base I/F의 상태</param>
        /// <param name="ruName">RU 이름</param>
        //public void nmsMUSt_Display(byte muID, MUData muData, BaseSt[,] baseSt, RuBdaName[] ruName)
        public void nmsMUSt_Display(byte muID, MUData muData)
        {
            int i = 0;

            if (!flagMUEnabel) MuStInit(true);

            if (!gbMu주_송수신기채널정보.Enabled) MuStInit(true);

            //SetEnable(panelMuAntennaMatchungUnit, true);
            SetEnable(btMUMainSpare1, true);
            SetEnable(btMUMainSpare2, true);
            SetEnable(btMUAutoManual1, true);
            SetEnable(btMUAutoManual2, true);

            //SetEnable(panelMu무선송수신기예비, true);
            SetEnable(gbMu예비_송수신기채널정보, true);
            SetEnable(gbMu예비_송수신동작상태, true);
            SetEnable(gbMu예비_송수신장애상태, true);
            SetEnable(gbMu예비_송신출력설정, true);
            
            // MU의 기타 상태(0:자동/수동절체방법상태, 1:주예비동작상태, 2:Wide/Narrow 상태,
            //               3:AC 전원상태, 4:DC 전원상태, 5:MONOPEN 상태, 6:CCE PTT 상태, 7: RC1 PTT 상태)
            for (i = 0; i < 3; i++)
            {
                if (muData.otherSt1[i] == 0)
                {
                    SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_ON);
                    SetImage(pbMuOtherSt[i], Common.Properties.Resources.st_OFF);
                }
                else
                {
                    SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_OFF);
                    SetImage(pbMuOtherSt[i], Common.Properties.Resources.st_ON);
                }
            }

            //자동/수동절체상태 표시할 컨트롤을 버튼으로 변경
            if (muData.otherSt1[0] == 0)
            {
                SetColor(btMUAutoManual1, colorSelect);
                SetColor(btMUAutoManual2, colorBase);
            }
            else
            {
                SetColor(btMUAutoManual1, colorBase);
                SetColor(btMUAutoManual2, colorSelect);
            }

            //주/예비동작상태 표시할 컨트롤을 버튼으로 변경
            if (muData.otherSt1[1] == 0)
            {
                SetColor(btMUMainSpare1, colorSelect);
                SetColor(btMUMainSpare2, colorBase);
            }
            else
            {
                SetColor(btMUMainSpare1, colorBase);

                //자동인데 예비이면 Error 표시
                if (muData.otherSt1[0] == 0) SetColor(btMUMainSpare2, colorError);
                else SetColor(btMUMainSpare2, colorSelect);
            }

            for (i = 3; i < 6; i++)
            {
                if (muData.otherSt1[i] == 0) SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_Normal);
                else SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_Error);
            }

			for (i = 6; i < 8; i++)
			{
				if (muData.otherSt1[i] == 0) SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_OFF);
				else SetImage(pbMuOtherSt1[i], Common.Properties.Resources.st_ON);
			}

            // MU의 기타 상태(8: RC2 PTT 상태, 9: RC3 PTT 상태, 10:역용 주 PTT, 11:역용 주 BUSY, 12:역용 예비 PTT, 13:역용 예비 BUSY, 14:역용 감청 BUSY, 15:ACU 카드상태)
			for (i = 0; i < 7; i++)
			{
				if (muData.otherSt2[i] == 0) SetImage(pbMuOtherSt2[i], Common.Properties.Resources.st_OFF);
				else SetImage(pbMuOtherSt2[i], Common.Properties.Resources.st_ON);
			}

                //ACU 카드 상태
                if (muData.otherSt2[7] == 0) SetImage(pbMUACU, Common.Properties.Resources.st_Normal);
                else SetImage(pbMUACU, Common.Properties.Resources.st_Error);
                
                

            //MU의 DC전원값
            double tmpDcValue = muData.dcValue / 10.0;
            SetText(ucLif1.lblMUDCValue, tmpDcValue.ToString("0.0") + " V");

            //MU의 주/예비 RF 출력값
            double tmpRfValue = 0;
            for (i = 0; i < 2; i++)
            {
                tmpRfValue = muData.rfValue[i] / 10.0;
                SetText(lblMURfMainSpare[i], tmpRfValue.ToString("0.0"));
            }

            //MU의 주/예비/감청용 RX RSSI 값
            for (i = 0; i < 3; i++)
            {
                int tmpValue = muData.rxRssiValue[i];

                //if (tmpValue >= 0x80) tmpValue = (tmpValue - 0x80) * -1;
                tmpValue *= -1;
                SetText(lblMURXRSSI[i], tmpValue.ToString() + " dBm");
            }

            //MU의 주/예비 RF 출력조회값
            for (i = 0; i < 2; i++)
            {
                int tmpRfOutValue = muData.rfValueInquiry[i];
                SetText(lblMURfMainSpareInquiry[i], tmpRfOutValue.ToString());
            }

            //MU의 주/예비/감청용 채널정보(0:Scan, 1:1CH, 2:2CH, 3:3CH, 4:4CH)
            string tmpCh = null;
            for (i = 0; i < 2; i++)
            {
                switch (muData.chInfo[i])
                {
                    //case 0: tmpCh = "REMOTE"; break;
                    case 1: tmpCh = "리모트 1 채널"; break;
                    case 2: tmpCh = "리모트 2 채널"; break;
                    case 3: tmpCh = "리모트 3 채널"; break;
                    case 4: tmpCh = "리모트 4 채널"; break;
                    case 5: tmpCh = "로컬 1 채널"; break;
                    case 6: tmpCh = "로컬 2 채널"; break;
                    case 7: tmpCh = "로컬 3 채널"; break;
                    case 8: tmpCh = "로컬 4 채널"; break;
                    case 10: tmpCh = "스캔중..."; break;
                    case 11: tmpCh = "스캔 1 채널 수신"; break;
                    case 12: tmpCh = "스캔 2 채널 수신"; break;
                    case 13: tmpCh = "스캔 3 채널 수신"; break;
                    case 14: tmpCh = "스캔 4 채널 수신"; break;
                    default: tmpCh = "리모트 1 채널"; break;
                }

                SetText(lblMUCHInfo[i], tmpCh);
            }

            //감청용 채널정보(0:Scan, 1:1CH, 2:2CH, 3:3CH, 4:4CH)
            tmpCh = null;
            switch (muData.chInfo[2])
            {
                case 0: tmpCh = "SCAN"; break;
                case 1: tmpCh = "1 채널 수신"; break;
                case 2: tmpCh = "2 채널 수신"; break;
                case 3: tmpCh = "3 채널 수신"; break;
                case 4: tmpCh = "4 채널 수신"; break;
                default: tmpCh = "1 채널 수신"; break;
            }
            SetText(lblMUCHInfo[2], tmpCh);

		    //OPT의 통신 감시 상태(0:주 통신 감시, 1:예비 통신 감시, 2:감청 통신 감시), 각 CPU카드 연결상태(3:MU TRX CPU 장착 상태, 4:MU OPT CPU 장착 상태, 5:UPS 연결 상태) 
            for (i = 0; i < 6; i++)
            {
                if (muData.optMonSt[i] == 0) SetImage(pbOptMonSt[i], Common.Properties.Resources.st_Normal);
                else SetImage(pbOptMonSt[i], Common.Properties.Resources.st_Error);
            }

            //채널 복귀 시간 상태
            if (muData.chReturn == 0) SetText(lblMUChReturnTime, "OFF");
            else SetText(lblMUChReturnTime, muData.chReturn.ToString());

			//PLL LOCK 장애 상태(0:역용 주 PLL LOCK 장애 상태, 1:역용 예비 PLL LOCK 장애 상태, 2:감청용 PLL LOCK 장애 상태)
            for (i = 0; i < 3; i++)
            {
                if (muData.pllLockErrorSt[i] == 0) SetImage(pbPllLockSt[i], Common.Properties.Resources.st_Normal);
                else SetImage(pbPllLockSt[i], Common.Properties.Resources.st_Error);
            }
            

            //RUA 장애 상태(2015년 09월 10일 추가)
             if (muData.pllLockErrorSt[3] == 0) SetImage(pbMURUASt, Common.Properties.Resources.st_Normal);
             else SetImage(pbMURUASt, Common.Properties.Resources.st_Error);
            

            //각 PTT 상태 : 0:CCE2 PTT, 1:RC4 PTT, 2:REPEAT PTT
             if (muData.pttSt[0] == 0) SetImage(ucLif1.pbMURCSt5, Common.Properties.Resources.st_OFF);
             else SetImage(ucLif1.pbMURCSt5, Common.Properties.Resources.st_ON);

             if (muData.pttSt[1] == 0) SetImage(ucLif1.pbMURCSt6, Common.Properties.Resources.st_OFF);
             else SetImage(ucLif1.pbMURCSt6, Common.Properties.Resources.st_ON);

             if (muData.pttSt[2] == 0) SetImage(ucLif1.pbMURepeatPttSt, Common.Properties.Resources.st_OFF);
             else SetImage(ucLif1.pbMURepeatPttSt, Common.Properties.Resources.st_ON);

			//LIF 통신 상태
			for (i = 0; i < 6; i++)
			{
                if (clsNMS.muLifExist[muID - 1].flagLif[i])
                {
                    SetEnable(lblRcName[i], true);

                    if (muData.lifSt[i] == 0) SetImage(pbMULifSt[i], Common.Properties.Resources.st_Normal);
                    else SetImage(pbMULifSt[i], Common.Properties.Resources.st_Error);
                }
                else
                {
                    SetEnable(lblRcName[i], false);
                    SetImage(pbMULifSt[i], Common.Properties.Resources.st_OFF);
                }
			}

			//주/예비 전원 상태
			if (muData.powerSt[0] == 0) SetImage(pbMUPowerMain, Common.Properties.Resources.st_Normal);
			else SetImage(pbMUPowerMain, Common.Properties.Resources.st_Error);
			if (muData.powerSt[1] == 0) SetImage(pbMUPowerStby, Common.Properties.Resources.st_Normal);
			else SetImage(pbMUPowerStby, Common.Properties.Resources.st_Error);

            /*
            tmpMuData.mainVer = buffer[j++];    //역용 주 버젼정보
            tmpMuData.stbyVer = buffer[j++];    //역용 예비 버젼정보
            tmpMuData.acuVer = buffer[j++];     //ACU 버젼정보
            tmpMuData.wnSt = Common.clsCommon.BitInfoToByte(buffer[j++]);   //무전기별 상태(Wide/Narrow)
            tmpMuData.monVer = buffer[j++];     //감청용 버젼정보
            */

            double tmpVerValue = muData.mainVer / 1.0;
            SetText(lblMainVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.stbyVer / 1.0;
            SetText(lblStbyVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.acuVer / 1.0;
            SetText(lblAcuVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.monVer / 1.0;
            SetText(lblMonVer, tmpVerValue.ToString("0.0"));

            if (muData.wnSt[0] == 0) SetText(lblMainWN, "WIDE");
            else SetText(lblMainWN, "NARROW");
            if (muData.wnSt[1] == 0) SetText(lblStbyWN, "WIDE");
            else SetText(lblStbyWN, "NARROW");
            if (muData.wnSt[2] == 0) SetText(lblMonWN, "WIDE");
            else SetText(lblMonWN, "NARROW");

            //DC 고장 및 전원값
            if (muData.wnSt[3] == 0) SetImage(pbDC, Common.Properties.Resources.st_Normal);
            else SetImage(pbDC, Common.Properties.Resources.st_Error);
            tmpVerValue = muData.optDcValue / 10.0;
            SetText(lblDcValue, tmpVerValue.ToString("0.0") + " V");

            switch (Common.clsNMS.nmsGUIUser)
            {
                case "분당선":
                    if (Common.clsNMS.presentMUID <= 5)
                    {
                        SetImage(pbMUSRSt5, Common.Properties.Resources.st_OFF);
                        SetImage(pbMUPllLock3, Common.Properties.Resources.st_OFF);
                        SetImage(pbMUMon3, Common.Properties.Resources.st_OFF);

                        SetImage(pbDC, Common.Properties.Resources.st_OFF);
                    }
                    break;

                
                    
            }

            SetOptData(muData);

        }

        private void SetOptData(MUData muData)
        {
            if (clsNMS.nmsGUIUser == "성남여주선")
            {
                var pbs = GetOptPictureBoxs();
                var optData = muData.optData;

                for (int i = 0; i < pbs.Length; i++)
                {
                    if (optData[i] == 0)
                        SetImage(pbs[i], Common.Properties.Resources.st_Normal);
                    if (optData[i] == 1)
                        SetImage(pbs[i], Common.Properties.Resources.st_Error);
                }
            }
        }

        public void nmsFMSt_Display(FM_Info fmInfo)
        {
            if (!flagFMEnabel) FmStInit(true);

            if (fmInfo.acInputFail == 1) SetImage(pbAcInputFail, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbAcInputFail, Common.Properties.Resources.st_Error);	//장애
            if (fmInfo.dcOutputFail == 1) SetImage(pbDCOutputFail, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbDCOutputFail, Common.Properties.Resources.st_Error);	//장애

            SetText(lblBetteryVoltage, fmInfo.betteryVoltage.ToString());
            SetText(lblBetteryChangeCurrent, fmInfo.betteryChangeCurrent.ToString());
            if (fmInfo.ldAlarm == 1) SetImage(pbLDAlarm, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbLDAlarm, Common.Properties.Resources.st_Error);	//장애
            if (fmInfo.pdAlarm == 1) SetImage(pbPDAlarm, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbPDAlarm, Common.Properties.Resources.st_Error);	//장애

            SetText(lblLDPower, fmInfo.ldPower.ToString());
            SetText(lblPDPower, fmInfo.pdPower.ToString());
            SetText(lblRssi, fmInfo.rssi.ToString());
            SetText(lblTssiFwd, fmInfo.tssiFwd.ToString());
            SetText(lblTssiRev, fmInfo.tssiRev.ToString());
            SetText(lblTemperature, fmInfo.temperature.ToString());
        }

        private void btMUMainSpareChange_Click(object sender, EventArgs e)
        {
            byte index = Convert.ToByte(((Button)sender).Tag);

            try
            {
                this.muControlClick(0, index, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btMUAutoManualChange_Click(object sender, EventArgs e)
        {
            byte index = Convert.ToByte(((Button)sender).Tag);

            try
            {
                this.muControlClick(1, index, 0);
            }
            catch
            {
            }
        }

        private void btMURfMainSpare_Click(object sender, EventArgs e)
        {
            byte index = Convert.ToByte(((Button)sender).Tag);

            byte rfValue = 0;

            try
            {
                rfValue = Convert.ToByte(tbMURfMainSpare[index].Text);
            }
            catch
            {
            }

            try
            {
                this.muControlClick(2, index, rfValue);
            }
            catch
            {
            }
        }

        private void btMUWideNarrowChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.muControlClick(3, 0, 0);
            }
            catch
            {
            }
        }

        private void btMUChReturnTime_Click(object sender, EventArgs e)
        {
            byte tmpChReturnTime = 0;

            try
            {
                tmpChReturnTime = Convert.ToByte(tbMUChReturnTime.Text);
            }
            catch
            {
            }

            try
            {
                this.muControlClick(4, 0, tmpChReturnTime);
            }
            catch
            {
            }
        }

        private void btMUSendOutTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.muControlClick(5, 0, 0);
            }
            catch
            {
            }
        }

        public void btMuSendOutTest_ColorSet()
        {
            if (flagSendOutTest)
            {
                tmrSendOutTest.Start();

                SetColor(btMUSendOutTest, colorSelect);
                SetColor(btMUSendOutTest1, colorSelect);
			}
            else
            {
                tmrSendOutTest.Stop();

                SetColor(btMUSendOutTest, colorBase);
                SetColor(btMUSendOutTest1, colorBase);
			}
        }

        private void tmrSendOutTest_Tick(object sender, EventArgs e)
        {
            tmrSendOutTest.Stop();

            try
            {
                this.muControlClick(5, 0, 0);
                return;
            }
            catch
            {
            }

            tmrSendOutTest.Start();
        }

        /// <summary>
        /// LIF에 Opt를 추가함. 성남여주에서 사용함
        /// </summary>
        /// <param name="count"></param>
        internal void SetLIF(int count)
        {
            ucLif1.AddOpt(count);

            
        }

        /// <summary>
        /// Opt용 PictureBox를 가져옮
        /// </summary>
        /// <returns></returns>
        internal PictureBox[] GetOptPictureBoxs()
        {
            return ucLif1.GetOptPictureBoxs();
        }
    }
}
