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
    /// <summary>
    /// ucSYMainScreen에서 기지국을 나타내는 UserControl을 담당
    /// </summary>
    public partial class ucMU : UserControl
    {

        /// <summary>
        /// MU 이름 설정
        /// </summary>
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

        /// <summary>
        /// Ru A를 가지고 있는지 설정함
        /// </summary>
        [Description ("해당 Mu에 Ru A가 있는지 설정한다.")]
        public bool HasRuA
        {
            set
            {
                RuA = value;
            }

            get
            {
                return RuA;
            }
        }

        /// <summary>
        /// Ru A가 있는지 여부
        /// </summary>
        private bool RuA = false;

        /// <summary>
        /// 광과련 데이터
        /// </summary>
        private byte[] mOptData;

    
        public ucMU()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 기지국 버튼
        /// </summary>
        public Button Button
        {
            get
            {
                return btMu;
            }
         }

        /// <summary>
        /// 광에 대한 데이터를 설정
        /// </summary>
        /// <param name="mBDA_1_2"></param>
        internal void SetOptData(byte[] data)
        {
            mOptData = data;
        }

        /// <summary>
        /// 설정된 OPT 데이터를 반환
        /// </summary>
        /// <returns></returns>
        public byte[] GetOptData()
        {
            return mOptData;
        }
    }
}
