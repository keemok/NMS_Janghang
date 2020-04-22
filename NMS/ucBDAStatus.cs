using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Commmon;

namespace NMS
{

    /// <summary>
    /// BDA상태 정보
    /// </summary>
    public partial class ucBDAStatus : UserControl
    {
        private frmMain mMain;
        private int mBDA_Count;
        /// <summary>
        /// BDA 정보
        /// </summary>
        private frmMain.BDAData[,] mData;

        /// <summary>
        /// BDA에 생긴 에러 갯수를 가지고 있을 변수
        /// </summary>
        int[] mBDA_Error = new int[100];

        public ucBDAStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 제목을 설정함
        /// </summary>
        /// <param name="enable"></param>
        internal void SetTitle(string p)
        { 
            lblTitle.Text = p + "  BDA 상태 정보";
        }


        #region SetBDACount 관련 메소드들

        /// <summary>
        /// BDA의 갯수를 설정한다
        /// </summary>
        /// <param name="count"></param>
        public void SetBDACount(int count)
        {
            mBDA_Count = count;

            var items = GetBDAs();
            
            //비활성화 하고 화면에 표시
            InitBDAItemsVisiblity(items);

            //해당 개수 외의 다른 거는 화면에 표시하지 않음
            DisableBDAItemExceededCount(count, items);

            //해당 갯수만 활성화
            EnableBDAItem(count, items);

        }

        /// <summary>
        /// 아이템의 표시 상태를 초기화 한다.
        /// 화면에 표시하고 비활성화 처리
        /// </summary>
        /// <param name="items"></param>
        private void InitBDAItemsVisiblity(ucBDAItem[] items)
        {
            foreach (var i in items)
            {
                i.Enabled = false;
                i.Visible = true;
            }
        }

     
        /// <summary>
        /// 해당 개수 외의 다른 거는 화면에 표시하지 않음
        /// </summary>
        /// <param name="count"></param>
        /// <param name="items"></param>
        private void DisableBDAItemExceededCount(int count, ucBDAItem[] items)
        {
            for (int i = count; i < items.Length; i++)
            {
                items[i].Visible = false;
            }
        }

      

        /// <summary>
        /// 해당 갯수의 BDA Item만 화면에 표시한다.
        /// </summary>
        /// <param name="count">표시할 갯수</param>
        /// <param name="items">BDA Item 들</param>
        private void EnableBDAItem(int count, ucBDAItem[] items)
        {
            for (int i = 0; i < count; i++)
            {
                items[i].Enabled = true;

            }
        }

        #endregion

        /// <summary>
        /// BDA를 가져오기
        /// </summary>
        /// <returns></returns>
        private ucBDAItem[] GetBDAs()
        {
            ucBDAItem[] bdas = {
                                   ucBDAItem1,ucBDAItem2,ucBDAItem3,ucBDAItem4,ucBDAItem5,ucBDAItem6,ucBDAItem7
                               };

            return bdas;
        }


        internal void SetMain(  frmMain main)
        {
            mMain = main;

        }
        
        /// <summary>
        /// 데이터 설정
        /// </summary>
        /// <param name="BDA_Data">BDA 정보</param>
        /// <param name="frmMain">메인화면 정보</param>
        internal void SetData(frmMain.BDAData[,] BDA_Data,frmMain frmMain)
        {
            mMain = frmMain;
            mData = BDA_Data;
                
        }

        /// <summary>
        /// 데이터 표시
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="bdaID"></param>
        internal void DisplayData(byte muID, byte ruID, byte bdaID)
        {
            var bdas = GetBDAs();

            var bdaData = GetBDAData(muID, ruID, bdaID); 


            //BDA 데이터가 없는 경우 
            if (bdaData == null)
            {
                bdas[bdaID].SetDefaultImage();
                return;
            }
            
            bdaData.Mu_Id =  muID;
            
            // BDA 갯수를 가져오기 위한 작업
            var uiData = mMain.SYMain.GetBDAs();
            
            var id = muID + ruID;

            ucBDA data = FindBDAData(uiData, muID, ruID);


            if (data == null)
                return;

            
            

            //bda갯수 보다 크거나 같을 경우 종료
            if (bdaID >= data.BDA_Number )
                return;
            
            bdas[bdaID].DisplayData(bdaData, mMain);
            
        }

        /// <summary>
        /// BDA 데이터
        /// </summary>
        /// <param name="uiData"></param>
        /// <param name="mu"></param>
        /// <param name="ru"></param>
        /// <returns></returns>
        private ucBDA FindBDAData(ucBDA[] uiData, int mu, int ru)
        {
            foreach(var i in uiData)
            {
                var chMu = (char)((char)mu + 'A') + "";
                
                if (i == null)
                    continue;

                if( i.MuID == chMu &&  i.Ru == ru)
                {
                    return i;
                }
            }


            return null;

        }

        /// <summary>
        /// BDA 정보를 가져온다.
        /// </summary>
        /// <param name="muID">MU id</param>
        /// <param name="ruID">RU id</param>
        /// <param name="bdaID">BDA id</param>
        /// <returns> 해당하는 BDA 정보가 있으면 반환, 없으면 null</returns>
        private clsBDATableInfo GetBDAData(byte muID, byte ruID, byte bdaID)
        {
            //BDA 아이템을 가져옴
            var bdas = GetBDAs();

            //mu id와 ru id에 해당하는 bda 데이터를 가져옴 
            var bda = mMain.GetBDA_Data()[muID, ruID];

            //해당 mu id 와 ru id가 없으면 null 반환
            if (bda == null) 
                return null;
   
            //해당 BDA의 데이터를 가져와서 반환, 데이터가 없는 경우 null 반환됨
            return  bda.bdaData[bdaID];
        }


        /// <summary>
        /// 기본 이미지로 변경함
        /// </summary>
        internal void SetDefaultImage()
        {
            var bdas = GetBDAs();

            foreach (var i in bdas)
            {
                i.SetDefaultImage();

                
            }
            
            

        }

        /// <summary>
        /// BDA를 클릭했을 때 데이터 표시
        /// </summary>
        /// <param name="muID"></param>
        internal void ShowData(byte muID, byte ruID)
        {
            for (int i = 0; i < mBDA_Count; i++)
            {
                DisplayData(muID, ruID, (byte) i);
            }
        }

        /// <summary>
        /// 고장이 발생하였는지 검사한다
        /// </summary>
        /// <param name="muID">muID 정보</param>
        /// <param name="ruID">ruID 정보</param>
        /// <param name="bdaID">BDA ID 정보</param>
        /// <returns>고장이 있는 경우 ture </returns>
        internal bool HasError(byte muID, byte ruID, byte bdaID)
        {

            //해당 데이터를 가져온다.
            var data = GetBDAData(muID, ruID, bdaID);

            //고장이 있는지 확인
            return data.IsError();

            //return GetBDAs()[bdaID].HasError();

        }

        /// <summary>
        /// 이미 에러가 발생한 경우 체크
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="ruID"></param>
        /// <param name="bdaID"></param>
        /// <returns></returns>
        internal bool AlreadyHasError(byte muID, byte ruID, byte bdaID)
        {
            var data = GetBDAData(muID, ruID, bdaID);

            //int val = data.AlreadyHasError();

            //int err = mBDA_Error[bdaID];

            ////에러 갯수가 같은 경우  이미 해당 에러가 있는 경우
            //if (val == err)
            //{
            //    return true;
            //}
            //else
            //{

            //    //에러갯수가 다르므로 업데이트
            //    mBDA_Error[bdaID] = val;

                return false;
            //}

            
        }
    }
}
