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
    public partial class ucLif : UserControl
    {
        ucOpt1 opt1;
        ucOpt2 opt2;
        private List<Point> InitLocation;

        public ucLif()
        {
            InitializeComponent();

            BackupOriginalLocation();
        }

        private void BackupOriginalLocation()
        {   
            InitLocation = new List<Point>();

            InitLocation.Add(panelComponent.Location);

            foreach(Control ctrl in panelComponent.Controls )
            {
                InitLocation.Add(ctrl.Location);
            }
        }

        /// <summary>
        /// Opt 상태를 추가 함 
        /// </summary>
        /// <param name="i">1이면 Opt1, 2면 Opt2</param>
        public void AddOpt(int i)
        {
            panelOpt.Controls.Clear();

            if( i == 0 && panelOpt.Visible )
            {
                panelOpt.SendToBack();
               
                panelOpt.Visible = false;


                RestoreLocation();
                return;
            }
            else if( i == 0)
            {
                return;
            }

            else if( i == 1)
            {
                opt1 = new ucOpt1();

                opt1.Dock = DockStyle.Fill;
                panelOpt.Controls.Add(opt1);
                
            }
            else
            {
                opt2 = new ucOpt2();
                opt2.Dock = DockStyle.Fill;
                panelOpt.Controls.Add(opt2);

            }
            panelOpt.Visible = true;
            
            ResizeComponent();
        }

        private void RestoreLocation()
        {
            labelTitle.Width = 490;

            panelComponent.Location =  InitLocation[0];
            panelComponent.Width += 20;


            int i =1;
            foreach (Control ctrl in panelComponent.Controls)
            {
                ctrl.Location = InitLocation[i++];
            }
        }


        /// <summary>
        /// 컴포넌트 크기 변경
        /// </summary>
        private void ResizeComponent()
        {
            panelComponent.Width = panelComponent.Width - 20;
            
            int pcLocY = panelComponent.Location.Y;


            panelComponent.Location = new Point(0, pcLocY);
            
            MoveX(lbl통신상태, 20);
            MoveX(lblPtt, 20);
            MoveX(pbMULifSt1, 20);
            MoveX(pbMULifSt2, 20);
            MoveX(pbMULifSt3, 20);
            MoveX(pbMULifSt4, 20);
            MoveX(pbMULifSt5, 20);
            MoveX(pbMULifSt6, 20);

            MoveX(pbMURCSt1, 20);
            MoveX(pbMURCSt2, 20);
            MoveX(pbMURCSt3, 20);
            MoveX(pbMURCSt4, 20);
            MoveX(pbMURCSt5, 20);
            MoveX(pbMURCSt6, 20);

            MoveX(pbMURepeatPttSt, 20);

            labelTitle.Width = 300;

        }

        /// <summary>
        /// 원래 위치에서 -x 만큼 이동한다.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="x"></param>
        private void MoveX(Control ctrl,  int x)
        {
            int xpos = ctrl.Location.X;
            ctrl.Location = new Point(xpos - x, ctrl.Location.Y);

        }




    }
}
