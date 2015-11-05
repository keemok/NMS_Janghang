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
    public partial class ucRu : UserControl
    {


        public ucRu()
        {
            InitializeComponent();
        }


        public Button RuButton
        {
            get
            {
                return btRU;
            }
        }

        public string ButtonName
        {
            set
            {
                btRU.Text = value;
            }
            get
            {
                return btRU.Text;
            }

        }


            
            
    }
}
