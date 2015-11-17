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
    public partial class ucBDAItem : UserControl
    {
        private System.Timers.Timer mTimer;
        private frmMain mMain;
        private Common.BDA_St mData;

        

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

            mTimer = new System.Timers.Timer();

            mTimer.Elapsed += mTimer_Elapsed;
            mTimer.Interval = 60 * 1000;

        }

        ~ucBDAItem()
        {
            if(mTimer != null)
                mTimer.Stop();
        }

        void mTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PictureBox[] pbs = { pbFmAlarm1, pbUHF_AC, pbUHF_AMP, pbUHF_DC, pbVHF_AC, pbVHF_AMP, pbVHF_DC };

            foreach (var i in pbs)
            {
                frmMain.SetImage(i, NMS.Properties.Resources.st_OFF);
            }

            mMain.DisableBDA(mData.mu_id);
        }

        internal void DisplayData(Common.BDA_St data, frmMain main)
        {

            mData = data;
            
            mMain = main;
            mTimer.Stop();
            mTimer.Start();

            //fm 
            frmMain.SetText(lblFmTemperature1, data.fmTemperature + "");

            frmMain.SetText(lblFmTssi1, data.fmTssi + "");


            if (data.fmAlarm == 0)
                frmMain.SetImage(pbFmAlarm1, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(pbFmAlarm1, NMS.Properties.Resources.st_Normal);


            //vhf

            if (data.vhfAcAlarm == 0)

                frmMain.SetImage(pbVHF_AC, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(pbVHF_AC, NMS.Properties.Resources.st_Normal);


            if (data.vhfDcAlarm == 0)

                frmMain.SetImage(pbVHF_DC, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(pbVHF_DC, NMS.Properties.Resources.st_Normal);


            if (data.vhfBypass == 0)

                frmMain.SetImage(pbVHF_AMP, NMS.Properties.Resources.st_OFF);
            else
                frmMain.SetImage(pbVHF_AMP, NMS.Properties.Resources.st_Normal);



            ///uhf
            if (data.uhfAcAlarm == 0)

                frmMain.SetImage(pbUHF_AC, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(pbUHF_AC, NMS.Properties.Resources.st_Normal);


            if (data.uhfDcAlarm == 0)

                frmMain.SetImage(pbUHF_DC, NMS.Properties.Resources.st_Error);
            else
                frmMain.SetImage(pbUHF_DC, NMS.Properties.Resources.st_Normal);


            if (data.uhfBypass == 0)

                frmMain.SetImage(pbUHF_AMP, NMS.Properties.Resources.st_OFF);
            else
                frmMain.SetImage(pbUHF_AMP, NMS.Properties.Resources.st_Normal);



        }


    }
}
