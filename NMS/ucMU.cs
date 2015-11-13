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

        private bool RuA = false;
        private byte[] mOptData;

    

        public ucMU()
        {
            InitializeComponent();
        }

        public Button Button
        {
            get
            {
                return btMu;
            }
                
         }

        internal void SetOptData(byte[] data)
        {
            mOptData = data;
        }

        public byte[] GetOptData()
        {
            return mOptData;
        }
    }
}
