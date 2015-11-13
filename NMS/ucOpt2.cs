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
    public partial class ucOpt2 : UserControl
    {
        public ucOpt2()
        {
            InitializeComponent();
        }


        public PictureBox[] GetItems()
        {
            PictureBox[] list = {
                                    pbOpt1LD1, pbOpt1LD2, pbOpt2LD1, pbOpt2LD2
                                };

            return list;

        }

        internal PictureBox[] GetOptLDs()
        {
            PictureBox[] list = {
                                     pbOpt1LD1, pbOpt1LD2, pbOpt2LD1, pbOpt2LD2
                                };
            return list;
        }

        internal PictureBox[] GetOptPBs()
        {
            PictureBox[] list = { pbOpt1PD1, pbOpt1PD2,
                                     pbOpt2PD1, pbOpt2PD2};
            return list;
        }
    }
}
