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
    public partial class ucOpt1 : UserControl
    {
        public ucOpt1()
        {
            InitializeComponent();
        }

        public PictureBox[] GetItems()
        {
            PictureBox[] list = {
                                    pbOptLD1, pbOptLD2, pbOptPD1, pbOptPD2
                                };

            return list;
        }
    }
}
