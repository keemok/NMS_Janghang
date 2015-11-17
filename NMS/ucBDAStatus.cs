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
    public partial class ucBDAStatus : UserControl
    {
        public ucBDAStatus()
        {
            InitializeComponent();
        }

        internal void SetTitle(string p)
        { 
            lblTitle.Text = p + " 기지국 BDA 상태 정보";
        }
    }
}
