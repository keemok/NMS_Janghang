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
    }
}
