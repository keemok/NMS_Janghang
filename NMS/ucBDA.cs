using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMS
{
    public partial class ucBDA : UserControl
    {

        /// <summary>
        /// BDA 클릭했을 때 처리
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="BDA_Count"></param>
        public delegate void ClickItem(byte muID, int BDA_Count);

        public event ClickItem ClickBDA;


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

        [Description("MU ID를 설정한다.")]
        public char MuID {

            set
            {
                MuIDData = (byte)(value - 'A');
            }

            get
            {
                return (char)(MuIDData + 'A');
            }
        }

        private byte MuIDData = (byte)'A';


        int BDA_Count = 1;
        private List<Button> mButtons;



        public ucBDA()
        {
            InitializeComponent();

            SetBDANumber();
        }

        /// <summary>
        /// BDA의 갯수를 설정한다
        /// </summary>
        private void SetBDANumber()
        {
            if (BDA_Count > 7)
                return;

            tlpContent.Controls.Clear();

            mButtons = new List<Button>();

            if (BDA_Count == 1)
            {
                Button bt = new Button();
                bt.Text = "1";
                bt.Dock = DockStyle.Fill;
                bt.Click += Click;

                mButtons.Add(bt);

                tlpContent.ColumnCount = 1;
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

                tlpContent.RowCount = 1;
                tlpContent.Controls.Add(bt, 0, 0);
                tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            else if( BDA_Count == 2)
            {
                tlpContent.Controls.Clear();
                
                tlpContent.ColumnCount = 2;
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

                tlpContent.RowCount = 1;
                tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50));

                for (int i = 0; i < BDA_Count; i++)
                {
                    Button bt = new Button();
                    bt.Text = (i+1) +"";
                    bt.Dock = DockStyle.Fill;
                    bt.Click += Click;
                    tlpContent.Controls.Add(bt, i, 0);
                    mButtons.Add(bt);
                }


            }
            else if (BDA_Count == 3)
            {
                tlpContent.Controls.Clear();

                tlpContent.ColumnCount = 3;
                tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

                tlpContent.RowCount = 1;
                tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50));

                for (int i = 0; i < BDA_Count; i++)
                {
                    Button bt = new Button();
                    bt.Text = (i + 1) + "";
                    bt.Dock = DockStyle.Fill;
                    bt.Click += Click;
                    tlpContent.Controls.Add(bt, i, 0);
                    mButtons.Add(bt);
                }
            }

            else if (BDA_Count == 4)
            {
                tlpContent.Controls.Clear();

                tlpContent.ColumnCount = 2;
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

                this.tlpContent.RowCount = 2;
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

                int count = 1;
                for (int i = 0; i<2; i++)
                {
                    for(int j=0; j<2; j++)
                    {
                        Button bt = new Button();
                        bt.Text = count + "";
                        bt.Dock = DockStyle.Fill;
                        bt.Click += Click;
                        tlpContent.Controls.Add(bt,j,i);
                        count++;
                        mButtons.Add(bt);
                    }
                }
            }


            else if (BDA_Count == 5)
            {
                tlpContent.Controls.Clear();

                this.tlpContent.ColumnCount = 3;
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

                this.tlpContent.RowCount = 2;
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

                int count = 1;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (count == 6)
                            break;

                        Button bt = new Button();
                        bt.Text = count + "";
                        bt.Click += Click;
                        bt.Dock = DockStyle.Fill;
                        tlpContent.Controls.Add(bt, j, i);
                        count++;

                        mButtons.Add(bt);
                    }
                }
            }
            else if (BDA_Count == 6)
            {
                tlpContent.Controls.Clear();

                this.tlpContent.ColumnCount = 3;
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

                this.tlpContent.RowCount = 2;
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

                int count = 1;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Button bt = new Button();
                        bt.Text = count + "";

                        bt.Click += Click;
                        bt.Dock = DockStyle.Fill;
                        tlpContent.Controls.Add(bt, j, i);
                        count++;

                        mButtons.Add(bt);
                    }
                }
            }
        }

        private new void Click(object sender, EventArgs e)
        {
            ClickBDA(MuIDData, BDA_Count);
        }

        internal void SetEnable(byte bdaID)
        {
            mButtons[bdaID].BackColor = Color.LimeGreen;

        }


        internal void SetEnable(int id, bool p)
        {
            if (p)
                mButtons[id].BackColor = Color.LimeGreen;
            else
                mButtons[id].BackColor = Control.DefaultBackColor;
            
        }
    }
}
