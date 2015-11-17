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
        private frmMain.BDAData[] mData;
        private frmMain mMain;
        public ucBDAStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 제목을 설정함
        /// </summary>
        /// <param name="p"></param>
        internal void SetTitle(string p)
        { 
            lblTitle.Text = p + " 기지국 BDA 상태 정보";
        }
        
        /// <summary>
        /// BDA의 갯수를 설정한다
        /// </summary>
        /// <param name="count"></param>
        public void SetBDACount(int count)
        {

            var items = GetBDAs();

            foreach(var i in items)
            {
                i.Enabled = false;
            }


            for(int i=0; i<count;i++)
            {
                items[i].Enabled = true;    
                
            }
        }

        private ucBDAItem[] GetBDAs()
        {
            ucBDAItem[] bdas = {
                                   ucBDAItem1,ucBDAItem2,ucBDAItem3,ucBDAItem4,ucBDAItem5,ucBDAItem6
                               };

            return bdas;
        }

        internal void SetData(frmMain.BDAData[] BDA_Data, frmMain main)
        {
            mMain = main;
            mData = BDA_Data;
        }

        internal void DisplayData(byte muID, byte bdaID)
        {
            var bdas = GetBDAs();

            mData[muID].muID = muID;
            mData[muID].bdaData[bdaID].mu_id = muID;

            bdas[bdaID].DisplayData(mData[muID].bdaData[bdaID], mMain);

            
            
            
        }
    }
}
