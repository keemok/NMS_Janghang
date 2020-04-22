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
    /// ucSYMainScreen에서 광중계장치을 나타내는 UserControl
    /// </summary>
    public partial class ucRu : UserControl
    {
        public ucRu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 버튼
        /// </summary>
        public Button RuButton
        {
            get
            {
                return btRU;
            }
        }

        /// <summary>
        /// 버튼이름 설정 $n은 NewLine 
        /// 
        /// </summary>
        [Description("버튼이름 설정 $n은 NewLine") ]
        public string ButtonName
        {
            set
            {
                btRU.Text = ""; 

                string ms = value;

                if( ms.Contains("$n") )
                {
                    ms  = ms.Replace("$n", "\r\n");
                    btRU.Text = ms;
                }
                else
                    btRU.Text = value;
            }
            get
            {
                return btRU.Text;
            }

        }


            
            
    }
}
