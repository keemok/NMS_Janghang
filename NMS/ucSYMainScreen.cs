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
    public partial class ucSYMainScreen : UserControl
    {
        public ucSYMainScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mu 버튼을 가져옮
        /// </summary>
        /// <returns></returns>
        public Button[] GetMuButtons()
        {
            Button[] btns ={
                               ucMU1.Button,ucMU2.Button,ucMU3.Button,ucMU4.Button,ucMU5.Button,ucMU6.Button,ucMU7.Button,ucMU8.Button,ucMU9.Button
                           };

            return btns;
        }

        public ucBDA[] GetBDAs()
        {
            ucBDA[] bdas ={
                              ucBDA1,  ucBDA2,ucBDA3,ucBDA4,ucBDA5,ucBDA6
                          };
            return bdas;

        }



        /// <summary>
        /// Mu 목록을 가져옮
        /// </summary>
        /// <returns></returns>
        public List<ucMU> GetMuList()
        {
            List<ucMU> list = new List<ucMU>();

            list.Add(ucMU1); list.Add(ucMU2); list.Add(ucMU3);
            list.Add(ucMU4); list.Add(ucMU5); list.Add(ucMU6);
            list.Add(ucMU7); list.Add(ucMU8); list.Add(ucMU9);

            return list;
        }

        
    }
}
