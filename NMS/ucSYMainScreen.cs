using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace NMS
{
    /// <summary>
    /// 메인화면에 들어갔을 때 표시되는 화면이다. 
    /// 성남여주선의 전체적 구성도를 표시함 
    /// Mu와 Ru, BDA의 고장 상태가 표시된다.
    /// </summary>
    public partial class ucSYMainScreen : UserControl
    {
        /// <summary>
        /// 1번째 와 2번 째 BDA를 나눠서 표시해달라고 해서 그거 처리용도
        /// 이건 화면에서 표시를 하는 용도, 실제 적으로는  ucBDA1과 ucBDA2에 데이터가 저장된다.
        /// </summary>
        private ucBDA[,] mBDA_1_2;

        /// <summary>
        /// BDA 표시용도
        /// </summary>
        private ucBDA[] mBDAItems;


        public ucSYMainScreen()
        {
            InitializeComponent();


            //mBDA_1_2 = new ucBDA[2, 2];

            //mBDA_1_2[0, 0] = ucBDA1_1;
            //mBDA_1_2[0, 1] = ucBDA1_2;

            //mBDA_1_2[1, 0] = ucBDA2_1;
            //mBDA_1_2[1, 1] = ucBDA2_2;

            //                     // A      B       C0      C1      D1      E       F     G        H
            //ucBDA[] BDAItems = { ucBDA1, ucBDA2, ucBDA3, ucBDA4, ucBDA5, ucBDA6, null, ucBDA7 };
            //mBDAItems = BDAItems;

         
        }

        /// <summary>
        /// BDA 카운트
        /// </summary>
        private void InitBDACount()
        {
            //int cnt = 0;

            //int it = 0;
            //var item = mBDAItems[it++];
            
            ////a
            //clsNMS.BDA_Count[cnt++, 0] = item.BDA_Number;

            ////b
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[cnt++, 0] = item.BDA_Number;

            ////c 0
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[cnt, 0] = item.BDA_Number;

            ////c1
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[cnt++, 1] = item.BDA_Number;

            ////D1
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[cnt++, 1] = item.BDA_Number;

            ////E0
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[cnt++, 0] = item.BDA_Number;

            ////F
            //it++;
            //cnt++;

            ////G0
            //item = mBDAItems[it++];
            //clsNMS.BDA_Count[7, 1]= item.BDA_Number;

        }

        /// <summary>
        /// Mu 버튼을 가져옮
        /// </summary>
        /// <returns></returns>
        public Button[] GetMuButtons()
        {
            Button[] btns ={
                               ucMU1.Button,ucMU2.Button,ucMU3.Button,ucMU4.Button,//ucMU5.Button,ucMU6.Button,ucMU7.Button,ucMU8.Button,ucMU9.Button
                           };

            return btns;
        }

        /// <summary>
        /// BDA 가져오기..
        /// </summary>
        /// <returns></returns>
        public ucBDA[] GetBDAs()
        {
            return mBDAItems;

        }

        /// <summary>
        /// 1번째와 2번 째 BDA 데이터 표시용도
        /// 1번째 와 2번 째 BDA를 나눠서 표시해달라고 해서 그거 처리용도
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public ucBDA GetBDA(int pos, int id)
        {
            return mBDA_1_2[pos, id];
        }

        /// <summary>
        /// <para>1번째 와 2번 째 BDA를 나눠서 표시해달라고 해서 그거 처리용도</para>
        /// <code>GetBDA()</code>는 개별용, 이건 전체 데이터
        /// </summary>
        /// <returns>데이터</returns>
        public ucBDA[,] GetBDAsForSplit()
        {
            return mBDA_1_2;
        }

        /// <summary>
        /// Mu 목록을 가져옮
        /// </summary>
        /// <returns></returns>
        public List<ucMU> GetMuList()
        {
            List<ucMU> list = new List<ucMU>();

            list.Add(ucMU1); list.Add(ucMU2); list.Add(ucMU3);
            list.Add(ucMU4);
            //list.Add(ucMU5); list.Add(ucMU6);
            //list.Add(ucMU7); list.Add(ucMU8); list.Add(ucMU9);

            return list;
        }

        private void ucSYMainScreen_Load(object sender, EventArgs e)
        {

            if (DesignMode)
                return;


            InitBDACount();
        }

        internal Button[] GetRus()
        {
            Button[] list = { ucRu1_1.RuButton, ucRu1_2.RuButton, ucRu1_3.RuButton, ucRu2_1.RuButton,
                ucRu2_2.RuButton,ucRu2_3.RuButton, ucRu2_4.RuButton,
                ucRu3_1.RuButton,ucRu3_2.RuButton, ucRu3_3.RuButton,
                ucRu4_1.RuButton,
            };

            return list;

        }
    }
}
