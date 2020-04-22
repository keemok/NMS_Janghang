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
    /// Opt1과 다른 점은 광이 2개 불어 있는 경우 표시용
    /// </summary>
    public partial class ucOpt2 : UserControl
    {
        public ucOpt2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// LD, PD 반환
        /// </summary>
        /// <returns></returns>
        public PictureBox[] GetItems()
        {
            PictureBox[] list = {
                                    pbOpt1LD1, pbOpt1LD2, pbOpt2LD1, pbOpt2LD2
                                };

            return list;

        }

        /// <summary>
        /// LD 반환
        /// </summary>
        /// <returns></returns>
        internal PictureBox[] GetOptLDs()
        {
            PictureBox[] list = {
                                     pbOpt1LD1, pbOpt1LD2, pbOpt2LD1, pbOpt2LD2
                                };
            return list;
        }

        /// <summary>
        /// PD 반환
        /// </summary>
        /// <returns></returns>
        internal PictureBox[] GetOptPBs()
        {
            PictureBox[] list = { pbOpt1PD1, pbOpt1PD2,
                                     pbOpt2PD1, pbOpt2PD2};
            return list;
        }
    }
}
