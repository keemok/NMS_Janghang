using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NMS
{
    public partial class ucBDA : UserControl
    {
        /// <summary>
        /// BDA 클릭했을 때 처리
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="count"></param>
        public delegate void ClickItem(byte muID, byte ruID, int BDA_Count);

        /// <summary>
        /// 클릭 이벤트
        /// </summary>
        public event ClickItem ClickBDA;


        #region Properties
        /// <summary>
        /// BDA의 갯수를 설정한다.
        /// </summary>
        [Description("BDA 갯수를 설정한다.")]
        public int BDA_Number
        {
            set
            {
                BDA_Count = value;
                SetBDANumber();
            }

            get
            {
                return BDA_Count;
            }
        }

         

        [Description("시작 번호를 설정한다.")]
        public int StartNumber
        {
            set
            {
                StartNum = value;

                SetBDANumber();
            }

            get
            {
                return StartNum;
            }
        }


        [Description("MU ID를 설정한다.")]
        public string MuID
        {
            set
            {
                MuIDData = (byte)(value[0] - 'A');
            }

            get
            {
                return Convert.ToChar((MuIDData + 'A')) + "";
            }
        }

        public byte Ru
        {
            set
            {
                RuID = value;
            }
            get
            {
                return RuID;
            }
        }

        public string Title
        {
            set
            {
                lblTitle.Text = value;
            }
            get
            {
                return lblTitle.Text;
            }
        }

        #endregion

        #region 필드 

        /// <summary>
        /// RU ID
        /// </summary>
        private byte RuID = 0;

        /// <summary>
        /// Mu ID
        /// </summary>
        private byte MuIDData = (byte)'A';

        /// <summary>
        /// BDA 갯수 
        /// </summary>
        private int BDA_Count = 1;
        private List<Button> mButtons;
        private int StartNum = 1;
        private ucBDA EventData;

        #endregion


        public ucBDA()
        {
            InitializeComponent();

            SetBDANumber();
        }


        #region SetBDANumber 와 관련된 메소드 
        /// <summary>
        /// BDA의 갯수를 설정한다
        /// </summary>
        private void SetBDANumber()
        {
            if (BDA_Count > 8)
                return;

            DataNotReceiveFlag = new bool[BDA_Count];

            tlpContent.Controls.Clear();

            mButtons = new List<Button>();

            if (BDA_Count == 1)
            {
                SetTLPContentColumStyle(1, 50F);

                SetTLPContentRowStyle(1, 50F);

                
                Button bt = GetButtonInstance();

                bt.Text = StartNum.ToString();

                mButtons.Add(bt);

                tlpContent.Controls.Add(bt, 0, 0);

            }
            else if (BDA_Count == 2)
            {
                SetTLPContentColumStyle(2, 50F);

                SetTLPContentRowStyle(1, 50F);

                SetButtonText();

            }
            else if (BDA_Count == 3)
            {
                SetTLPContentColumStyle(3, 50F);

                SetTLPContentRowStyle(1, 50F);

                SetButtonText();
       
            }
            else if (BDA_Count == 4)
            {
                SetTLPContentColumStyle(3, 50F);
                SetTLPContentRowStyle(2, 50F);

                SetButtonText();

              
            }
            else if (BDA_Count == 5)
            {
                SetTLPContentColumStyle(3, 50F);
                SetTLPContentRowStyle(2, 50F);
                SetButtonText();

            }
            else if (BDA_Count == 6)
            {
                SetTLPContentColumStyle(3, 50F);
                SetTLPContentRowStyle(2, 50F);
                SetButtonText();

         
            }

            else if (BDA_Count == 7)
            {
                SetTLPContentColumStyle(4, 50F);
                SetTLPContentRowStyle(2, 50F);
                SetButtonText();

     
            }
        }




        /// <summary>
        /// Table Layout Panel의 Column Style을 설정한다.
        /// </summary>
        /// <param name="count">BDA 갯수</param>
        private void SetTLPContentColumStyle(int count, float size)
        {
            tlpContent.ColumnCount = count;

            for (int i = 0; i < count; i++)
            {
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, size ));
            }
            
        }

        /// <summary>
        /// Row Style을 설정한다.
        /// </summary>
        /// <param name="count">Row의 갯수</param>
        private void SetTLPContentRowStyle(int count, float size)
        {
            tlpContent.RowCount = count;
            

            for (int i = 0; i < count; i++ )
                tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, size ));
        }


        /// <summary>
        /// 버튼 인스턴스를 생성
        /// </summary>
        /// <returns></returns>
        private Button GetButtonInstance()
        {
            Button bt = new Button();

            bt.Dock = DockStyle.Fill;
            bt.Click += Click;
            bt.FlatStyle = FlatStyle.Flat;
            bt.BackColor = Color.White;

            return bt;
        }

        /// <summary>
        /// 버튼 이름 설정
        /// </summary>
        private void SetButtonText()
        {
            for (int i = 0; i < BDA_Count; i++)
            {
                Button bt = GetButtonInstance();
                bt.Text = (StartNum + i) + "";

                tlpContent.Controls.Add(bt);
                mButtons.Add(bt);
            }
        }

        #endregion


        /// <summary>
        /// 클릭시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void Click(object sender, EventArgs e)
        {
            if(EventData != null)
            {
                EventData.ClickBDA(EventData.MuIDData, EventData.RuID, EventData.BDA_Count);
            }
            else
                ClickBDA(MuIDData, RuID, BDA_Count);
        }

        /// <summary>
        /// 고장 표시
        /// </summary>
        /// <param name="bdaID"></param>
        /// <param name="error"></param>
        internal void SetError(int bdaID, bool error)
        {

            if (bdaID >= mButtons.Count)
                return;

            try
            {
                Invoke(new MethodInvoker(delegate()
                {
                    if (error)
                    {
                        mButtons[bdaID].BackColor = Color.Red;
                    }
                    else

                        mButtons[bdaID].BackColor = Color.LimeGreen;
                }));

            }
            catch
            {

            }
        }

        /// <summary>
        /// 버튼 활성화 비활성화 표시
        /// </summary>
        /// <param name="index"></param>
        /// <param name="enable"></param>
        internal void SetEnable(int index, bool enable)
        {
            if (mButtons.Count <= index)
                return;

            //invoke가 필요한 경우
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    EnableButton(index, enable);
                }));
            }
            else
            {
                EnableButton(index, enable);
            }      
        }

        /// <summary>
        /// 버튼을 할성화 또는 비활성화 한다.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="enable"></param>
        private void EnableButton(int index, bool enable)
        {
            if (enable)
                mButtons[index].BackColor = Color.LimeGreen;
            else
                mButtons[index].BackColor = Color.White;
        }
        

        /// <summary>
        /// 데이터 미수신 처리
        /// </summary>
        public bool[] DataNotReceiveFlag { get; set; }


        internal void SetEvent(ucBDA evt)
        {
            EventData = evt;
        }
    }
}
