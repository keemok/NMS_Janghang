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
    /// MU에 Ru가 붙어 있는 경우, ucSYMUStatus에서 광 관련 오류를 표시하는 UserControl
    /// </summary>
    public partial class ucOpt1 : UserControl
    {
        public ucOpt1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PD와 LD를 반환한다.
        /// </summary>
        /// <returns></returns>
        public PictureBox[] GetItems()
        {
            PictureBox[] list = {
                                    pbOptLD1, pbOptLD2, pbOptPD1, pbOptPD2
                                };
            return list;
        }

        /// <summary>
        /// LD PictureBox를 반환한다.
        /// </summary>
        /// <returns></returns>
        internal PictureBox[] GetOptLDs()
        {
            PictureBox[] p =  { pbOptLD1, pbOptLD2 };
            return p;
        }

        /// <summary>
        /// PD Picture Box를 반환
        /// </summary>
        /// <returns></returns>
        internal PictureBox[] GetOptPBs()
        {
            PictureBox[] p ={  pbOptPD1, pbOptPD2 };
            return p;
        }
    }
}
