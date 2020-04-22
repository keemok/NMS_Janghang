using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commmon;

namespace NMS
{
    public partial class ucBDAItem : UserControl
    {
        /// <summary>
        /// 타이머
        /// </summary>
        //private System.Timers.Timer mTimer;

        /// <summary>
        /// 메인 
        /// </summary>
        private frmMain mMain;

        /// <summary>
        /// BDA 관련 정보
        /// </summary>
        private clsBDATableInfo mData;

        /// <summary>
        /// 고장인 경우
        /// </summary>
        private bool mError;
        
        /// <summary>
        /// 이름
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

        public ucBDAItem()
        {
            InitializeComponent();

            //mTimer = new System.Timers.Timer();

            //mTimer.Elapsed += mTimer_Elapsed;
            //mTimer.Interval = 30 * 1000;

        }

        ~ucBDAItem()
        {
            //if(mTimer != null)
            //    mTimer.Stop();
        }

        /// <summary>
        /// 1분 시간 지났을 경우에 초기화 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SetDefaultImage();

            //mMain.DisableBDA(mData.Mu_Id, mData.Ru_Id, mData.BDA_ID);

            //mTimer.Stop();
        }

        /// <summary>
        /// 기본 이미지 설정
        /// </summary>
        public void SetDefaultImage()
        {
            PictureBox[] pbs = { pbFmAlarm1, pbUHF_AC, pbUHF_AMP, pbUHF_DC,pbUHFBattery,  pbVHF_AC, pbVHF_AMP, pbVHF_DC, pbVHFBattery };

            foreach (var i in pbs)
            {
                frmMain.SetImage(i, NMS.Properties.Resources.st_OFF);
            }

            frmMain.SetText(lblFmTemperature1, "0");
            frmMain.SetText(lblFmTssi1, "0");
        }


        /// <summary>
        /// 데이터를 UI에 표시
        /// </summary>
        /// <param name="mBDA_1_2"></param>
        /// <param name="main"></param>
        internal void DisplayData(clsBDATableInfo data, frmMain main)
        {
            mData = data;
            
            mMain = main;

            //fm 
            frmMain.SetText(lblFmTemperature1, data.Temperature + "");

            frmMain.SetText(lblFmTssi1, data.Output + "");

            bool error = data.IsError();


            //FM 알람
            SetErrorIcon(data.FM_Alarm, pbFmAlarm1);

            //VHF Ac Alarm
            SetErrorIcon(data.VHF_AC_Alarm, pbVHF_AC);

            //VHF DC Alarm
            SetErrorIcon(data.VHF_DC_Alarm, pbVHF_DC);

            //VHF Battery
            SetErrorIcon(data.VHF_Battery_Alarm, pbVHFBattery);


            //UHF 

            //AC
            SetErrorIcon(data.UHF_AC_Alarm, pbUHF_AC);

            //DC
            SetErrorIcon(data.UHF_DC_Alarm, pbUHF_DC);

            //Battery
            SetErrorIcon(data.UHF_Battery_Alarm, pbUHFBattery); 


            mError = error;

           // mTimer.Start();
            
        }

        /// <summary>
        /// 오류 아이콘 설정 
        /// </summary>
        /// <param name="mBDA_1_2">고장 데이터</param>
        /// <param name="icon">고장 아이콘</param>
        private void SetErrorIcon(int data, PictureBox icon)
        {
            if (data == 0)
                frmMain.SetImage(icon, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(icon, NMS.Properties.Resources.st_Normal);
        }


    }
}
