using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using NMS.Utils;

namespace NMS
{
    /// <summary>
    /// 사용자 정의 컨트롤에서의 제어 이벤트
    /// </summary>
    /// <param name="btCode">Click한 버튼 Code</param>
    /// <param name="index">주/예비, Wide/Narrow등등..</param>
    /// <param name="value">설정에 필요한 값</param>
    public delegate void UserControl_Control(byte btCode, byte index, byte value);

    /// <summary>
    /// 기지국의 상태를 표시하는 UserControl
    /// </summary>
    public partial class ucSYMUStatus : UserControl
    {
        /// <summary>
        /// 사용자 정의 컨트롤에서의 제어 이벤트
        /// </summary>
        /// <param name="btCode">Click한 버튼 Code</param>
        public event UserControl_Control muControlClick = null;

        #region MU감시화면 컨트롤 배열
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        internal List<Button> btMURfMainSpare = new List<Button>();
        internal List<Label> lblMURfMainSpare = new List<Label>();
        internal List<Label> lblMURfMainSpareInquiry = new List<Label>();
        internal List<TextBox> tbMURfMainSpare = new List<TextBox>();

        internal List<Label> lblMUCHInfo = new List<Label>();
        internal List<Label> lblMURXRSSI = new List<Label>();

        internal List<PictureBox> pbMuOtherSt1 = new List<PictureBox>();
        internal List<PictureBox> pbMuOtherSt = new List<PictureBox>();
        internal List<PictureBox> pbMuOtherSt2 = new List<PictureBox>();

        internal List<Label> lblRcName = new List<Label>();
		internal List<PictureBox> pbMULifSt = new List<PictureBox>();

        //OPT 상태 관련
        internal List<PictureBox> pbOptMonSt = new List<PictureBox>();
        internal List<PictureBox> pbOptOtherSt = new List<PictureBox>();
        internal List<PictureBox> pbOptAlarmSt = new List<PictureBox>();

        internal List<Label> lblOptLd = new List<Label>();
        internal List<Label> lblOptPd = new List<Label>();

        internal List<PictureBox> pbPllLockSt = new List<PictureBox>();        
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion
        
        #region 기타 변수
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Timer tmrSendOutTest = new Timer();

        public bool flagSendOutTest = false;

        internal Color colorSelect = new Color();    //선택 색
        internal Color colorError = new Color();    //선택 색
        internal Color colorBase = new Color();      //기본 색

        public bool flagMUEnable = false;
        public bool flagFMEnabel = false;
        
        /// <summary>
        /// RU A 표시 상태
        /// </summary>
        internal bool mRuAState = true;

        /// <summary>
        /// 메인화면 인스턴스
        /// </summary>
        private ucSYMainScreen mMainScreen;
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion

        public ucSYMUStatus()
        {
            InitializeComponent();


            if (DesignMode)
            {
                return;
            }

            #region MU감시화면 컨트롤 배열 초기화
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

        /// <summary>
        /// 화면이 로드되었을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (DesignMode)
                return;
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
            else
            {
                pbMUACU.Location = new Point(76, 74);
                lblMUACU.Location = new Point(104, 78);
                mRuAState = visible;
            }

            pbMURUASt.Visible = visible;
            lblMURUASt.Visible = visible;
        }

        /// <summary>
        /// 노선별 화면 설정하는건데, 어차피 이 프로젝트는 성남여주 전용 프로젝트임..
        /// </summary>
        /// <param name="mode"></param>
        public void SetMode(byte mode)
        {
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

            panelMu채널복귀.Width = 450;
            panel채널복귀내부.Width = 446;
            lbl채널복귀시간제목.Width = 446;
            lbl채널복귀시간1.Left = 123; lbl채널복귀시간1.Top = 110;
            lblMUChReturnTime.Left = 269; lblMUChReturnTime.Top = 109;
            lbl채널복귀시간2.Left = 126; lbl채널복귀시간2.Top = 157;
            tbMUChReturnTime.Left = 275; tbMUChReturnTime.Top = 147;
            btMUChReturnTime.Left = 125; btMUChReturnTime.Top = 203;

            SetVisibleRuAState(false);
            
        }
        
        #region MuStInit 관련 메소드

        /// <summary>
        /// MU 상태를 초기화(활성화/비활성화)한다.
        /// </summary>
        /// <param name="flagAction">활성화/비활성화</param>
        public void MuStInit(bool flagAction)
        {
            int i = 0;

            flagMUEnable = flagAction;

            SetEnable(ucLif1, flagAction);

            //SetEnable(panelMuAntennaMatchungUnit, flagAction);
            //주/예비 절체 버튼 관련 비활성화
            DisableDeviceSwitch(flagAction);

            //주 송수신기 비활성화
            DisableMainTranceiver(flagAction);
            
            //예비 송수신기 비활성화
            DisableStbyTranceiver(flagAction);

            //감청 수신기 비활성화
            DisableMonitorTrainceiver(flagAction);

            ///광 전송부 비활성화
            DisableOPT(flagAction);

            //채널 복귀 시간 비활성화
            DisableChannelReturnTime(flagAction);

            ///무전기 타입 비활성화 
            DisableTrainceiverTye(flagAction);

            //전원부 비활성화
            DisablePowerSupply(flagAction);

            //LIF 관련 비활성화
            DisableLIF(flagAction);

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

            if (mRuAState)
            {
                SetImage(pbMURUASt, Common.Properties.Resources.st_OFF);
                SetEnable(pbMURUASt, flagAction);
            }

            //SetEnable(panelMUVer, flagAction);
            SetEnable(gbMainVer, flagAction);
            SetEnable(gbStbyVer, flagAction);
            SetEnable(gbMonVer, flagAction);
            SetEnable(gbAcuVer, flagAction);
            SetEnable(gbWN, flagAction);
            SetEnable(gbDC, flagAction);

            SetImage(pbDC, Common.Properties.Resources.st_OFF);

            SetEnableOpt(flagAction);

        }

        private int DisableLIF(bool flagAction)
        {
            int i;

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

            ucLif1.InitOptImage();

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
            return i;
        }

        private void DisablePowerSupply(bool flagAction)
        {
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
        }

        private void DisableTrainceiverTye(bool flagAction)
        {

            //SetEnable(panelMu무전기형식, flagAction);
            SetEnable(lblMUWideNarrowChange1, flagAction);
            SetEnable(lblMUWideNarrowChange2, flagAction);
            SetEnable(pbMUWideNarrow2, flagAction);
            SetImage(pbMUWideNarrow1, Common.Properties.Resources.st_OFF);
            SetImage(pbMUWideNarrow2, Common.Properties.Resources.st_OFF);
            SetEnable(pbMUWideNarrow1, flagAction);
            SetEnable(pbMUWideNarrow2, flagAction);
            SetEnable(btMUWideNarrowChange, flagAction);
        }

        private void DisableChannelReturnTime(bool flagAction)
        {
            //SetEnable(panelMu채널복귀, flagAction);
            SetEnable(lbl채널복귀시간1, flagAction);
            SetEnable(lbl채널복귀시간2, flagAction);
            SetEnable(lblMUChReturnTime, flagAction);
            SetEnable(tbMUChReturnTime, flagAction);
            SetEnable(btMUChReturnTime, flagAction);
        }

        private int DisableOPT(bool flagAction)
        {
            int i = 0;
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
            return i;
        }

        private void DisableMonitorTrainceiver(bool flagAction)
        {
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
        }

        private void DisableStbyTranceiver(bool flagAction)
        {
            //SetEnable(panelMu무선송수신기예비, flagAction);
            SetEnableStbyTrainceiver(flagAction);
            SetImage(pbMUSRSt3, Common.Properties.Resources.st_OFF);
            SetImage(pbMUSRSt4, Common.Properties.Resources.st_OFF);
            SetImage(pbMUPllLock2, Common.Properties.Resources.st_OFF);
            SetImage(pbMUMon2, Common.Properties.Resources.st_OFF);
        }

        private void SetEnableStbyTrainceiver(bool flagAction)
        {
            SetEnable(gbMu예비_송수신기채널정보, flagAction);
            SetEnable(gbMu예비_송수신동작상태, flagAction);
            SetEnable(gbMu예비_송수신장애상태, flagAction);
            SetEnable(gbMu예비_송신출력설정, flagAction);
        }

        private void DisableMainTranceiver(bool flagAction)
        {
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
        }

        private void DisableDeviceSwitch(bool flagAction)
        {
            SetColor(btMUMainSpare1, SystemColors.Control);
            SetColor(btMUMainSpare2, SystemColors.Control);
            SetColor(btMUAutoManual1, SystemColors.Control);
            SetColor(btMUAutoManual2, SystemColors.Control);
            SetEnableDeviceSwitch(flagAction);
        }

        /// <summary>
        /// 절체 관련 버튼 활성화
        /// </summary>
        /// <param name="flagAction"></param>
        private void SetEnableDeviceSwitch(bool flagAction)
        {
            SetEnable(btMUMainSpare1, flagAction);
            SetEnable(btMUMainSpare2, flagAction);
            SetEnable(btMUAutoManual1, flagAction);
            SetEnable(btMUAutoManual2, flagAction);
        }

        private void SetEnableOpt(bool flagAction)
        {
            var lds = ucLif1.GetOptLDs();
            var pds = ucLif1.GetOptPBs();


            if (pds == null || lds == null)
                return;
            
            foreach (var i in lds)
                SetEnable(i, flagAction);

            foreach (var i in pds)
                SetEnable(i, flagAction);


        }

        #endregion

        #region FM 초기화
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
        #endregion

        #region Mu 상태 표시 관련 메소드

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

            if (!flagMUEnable)
                MuStInit(true);

            if (!gbMu주_송수신기채널정보.Enabled) MuStInit(true);

            SetEnableDeviceSwitch(true);

            SetEnableStbyTrainceiver(true);


            MuStateDisplay display = new MuStateDisplay(muID, muData, this);
            display.Show();
           

            var t = mMainScreen.GetMuList()[muID-1];
            SetOptData(t.GetOptData());

        }

   


        /// <summary>
        /// 광 장치 값
        /// </summary>
        /// <param name="muData"></param>
        private void SetOptData(byte[] data)
        {

            if (data == null)
                return;

            if (clsNMS.nmsGUIUser == "성남여주선")
            {
                var lds = ucLif1.GetOptLDs();
                var pds = ucLif1.GetOptPBs();


                if (pds == null || lds == null)
                    return;


                ///비활성화 상태일 경우 데이터가 수신되더라도 표시하지 않음.
                if (!lds[0].Enabled)
                    return;


                var optData = data;

                for (int i = 0; i < 4; i++)
                {
                    if (i >= lds.Length)
                        break;

                    if (optData[i] == 0)
                        SetImage(lds[i], Common.Properties.Resources.st_Normal);
                    if (optData[i] == 1)
                        SetImage(lds[i], Common.Properties.Resources.st_Error);
                }

                int j = 0;
                for (int i = 4; i < 8; i++)
                {
                    if (j >= pds.Length)
                        break;

                    if (optData[i] == 0)
                        SetImage(pds[j], Common.Properties.Resources.st_Normal);
                    if (optData[i] == 1)
                        SetImage(pds[j], Common.Properties.Resources.st_Error);

                    j++;
                }
            }
        }

        #endregion

        #region FM 상태 표시
        /// <summary>
        /// Fm 정보 표시
        /// </summary>
        /// <param name="fmInfo"></param>
        public void nmsFMSt_Display(FM_Info fmInfo)
        {
            if (!flagFMEnabel) FmStInit(true);

            ///AC
            if (fmInfo.acInputFail == 1) SetImage(pbAcInputFail, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbAcInputFail, Common.Properties.Resources.st_Error);	//장애

            //DC
            if (fmInfo.dcOutputFail == 1) SetImage(pbDCOutputFail, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbDCOutputFail, Common.Properties.Resources.st_Error);	//장애

            //Battery
            SetText(lblBetteryVoltage, fmInfo.betteryVoltage.ToString());
            SetText(lblBetteryChangeCurrent, fmInfo.betteryChangeCurrent.ToString());

            //LD
            if (fmInfo.ldAlarm == 1) SetImage(pbLDAlarm, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbLDAlarm, Common.Properties.Resources.st_Error);	//장애

            //PD
            if (fmInfo.pdAlarm == 1) SetImage(pbPDAlarm, Common.Properties.Resources.st_Normal);	//정상
            else SetImage(pbPDAlarm, Common.Properties.Resources.st_Error);	//장애

            //LD Power
            SetText(lblLDPower, fmInfo.ldPower.ToString());

            //PD Power
            SetText(lblPDPower, fmInfo.pdPower.ToString());

            //RSSI
            SetText(lblRssi, fmInfo.rssi.ToString());
            //TSSI fwd
            SetText(lblTssiFwd, fmInfo.tssiFwd.ToString());
            //TSSI rew
            SetText(lblTssiRev, fmInfo.tssiRev.ToString());

            //온도
            SetText(lblTemperature, fmInfo.temperature.ToString());
        }
        #endregion
        
        #region 버튼 클릭 처리 부분
        /// <summary>
        /// 주예비 절체 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMUMainSpareChange_Click(object sender, EventArgs e)
        {
            byte index = Convert.ToByte(((Button)sender).Tag);
            try
            {
                this.muControlClick(0, index, 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Auto Mannual 클릭 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 주 무전기 RF 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 협대역 광대역 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// 채널 복귀 설정 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region 송신 출력 관련
        /// <summary>
        /// 송신 출력 시험
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///  송신 출력 시 색변경
        /// </summary>
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

        #endregion

        #endregion

        /// <summary>
        /// LIF에 Opt를 추가함. 성남여주에서 사용함
        /// </summary>
        /// <param name="count"></param>
        internal void SetLIF(int count)
        {
            ucLif1.AddOpt(count);
            
        }

        /// <summary>
        /// OPT LD 와 PD 고장 정보를 화면에 표시한다.
        /// </summary>
        /// <param name="muId"></param>
        /// <param name="enable"></param>
        internal void SetOptValue(int muId, byte[] p)
        {

            SetOptData(p);
        }

        internal void SetMainScreen(ucSYMainScreen SYMain)
        {
            mMainScreen = SYMain;
        }
    }
}
