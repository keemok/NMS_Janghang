using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMS
{
    /// <summary>
    /// ucSYMUStatus의 nmsMUSt_Display 메소드가 너무 길어서  따로 빼낸 클래스
    /// 이 메소드는 ucSYMUStatus
    /// </summary>
    class MuStateDisplay
    {
        /// <summary>
        /// Mu ID
        /// </summary>
        private byte muID;

        /// <summary>
        /// Mu 데이터 수신 시 
        /// </summary>
        private Common.MUData muData;

        /// <summary>
        /// 이 클래스를 호출한 인스턴스 
        /// View 데이터 가져올 용도
        /// </summary>
        private ucSYMUStatus ucSYMUStatus;


        /// <summary>
        /// MU 상태 표시용 생성자
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="muData"></param>
        /// <param name="ucSYMUStatus"></param>
        public MuStateDisplay(byte muID, Common.MUData muData, ucSYMUStatus ucSYMUStatus)
        {
            this.muID = muID;
            this.muData = muData;
            this.ucSYMUStatus = ucSYMUStatus;
        }


        /// <summary>
        /// MU 상태 정보를 표시하단.
        /// </summary>
        internal void Show()
        {

            // MU의 기타 상태(0:자동/수동절체방법상태, 1:주예비동작상태, 2:Wide/Narrow 상태,
            //               3:AC 전원상태, 4:DC 전원상태, 5:MONOPEN 상태, 6:CCE PTT 상태, 7: RC1 PTT 상태)
            SetETCData(muData);

            //Auto/Manual 설정
            SetAutoManuelButtonData(muData);

            //주/예비 표시
            SetMainStbyData(muData);

            //ac dc modopen ptt rc1 ptt
            SetETC2Data(muData);

            // MU의 기타 상태(8: RC2 PTT 상태, 9: RC3 PTT 상태, 10:역용 주 PTT, 11:역용 주 BUSY, 12:역용 예비 PTT, 13:역용 예비 BUSY, 14:역용 감청 BUSY, 15:ACU 카드상태)
            SetETC3Data(muData);

            //MU의 DC전원값
            SetDCValue(muData);

            //주/예비 RF 값 설정
            SetRFValue(muData);

            //주/예비 RSSI 값 설정
            SetRSSIValue(muData);

            //송신 출력 설정 값
            SetRFSettingValue(muData);

            //MU의 주/예비/감청용 채널정보(0:Scan, 1:1CH, 2:2CH, 3:3CH, 4:4CH)
            SetTrainceiverChannelInfo(muData);

            //감청용 채널정보(0:Scan, 1:1CH, 2:2CH, 3:3CH, 4:4CH)
            SetMonitorChannel(muData);

            //주/예비 통신 김시
            SetTrainceiverCommunication(muData);

            //채널 복귀 시간 설정
            SetChannelReturnData(muData);

            //PLL Lock, RuA 정보
            SetPLLLock_RuAData(muData);

            //각 PTT 상태 : 0:CCE2 PTT, 1:RC4 PTT, 2:REPEAT PTT
            SetPTTData(muData);

            //LIF 통신 상태
            SetLIFData(muID, muData);

            //주/예비 전원 상태
            SetPowerState(muData);

            /*
            tmpMuData.mainVer = buffer[ru++];    //역용 주 버젼정보
            tmpMuData.stbyVer = buffer[ru++];    //역용 예비 버젼정보
            tmpMuData.acuVer = buffer[ru++];     //ACU 버젼정보
            tmpMuData.wnSt = Common.clsCommon.BitInfoToByte(buffer[ru++]);   //무전기별 상태(Wide/Narrow)
            tmpMuData.monVer = buffer[ru++];     //감청용 버젼정보
            */

            SetVersionInfo(muData);

            SetWideNarrowData(muData);

            //DC 고장 및 전원값
            SetDCData(muData);


        }

        private void SetDCData(MUData muData)
        {
            double tmpVerValue = 0;

            if (muData.wnSt[3] == 0) SetImage(ucSYMUStatus.pbDC, Common.Properties.Resources.st_Normal);
            else SetImage(ucSYMUStatus.pbDC, Common.Properties.Resources.st_Error);
            tmpVerValue = muData.optDcValue / 10.0;
            SetText(ucSYMUStatus.lblDcValue, tmpVerValue.ToString("0.0") + " V");
        }

        private void SetWideNarrowData(MUData muData)
        {
            if (muData.wnSt[0] == 0) SetText(ucSYMUStatus.lblMainWN, "WIDE");
            else SetText(ucSYMUStatus.lblMainWN, "NARROW");
            if (muData.wnSt[1] == 0) SetText(ucSYMUStatus.lblStbyWN, "WIDE");
            else SetText(ucSYMUStatus.lblStbyWN, "NARROW");
            if (muData.wnSt[2] == 0) SetText(ucSYMUStatus.lblMonWN, "WIDE");
            else SetText(ucSYMUStatus.lblMonWN, "NARROW");
        }

        private double SetVersionInfo(MUData muData)
        {
            double tmpVerValue = muData.mainVer / 1.0;
            SetText(ucSYMUStatus.lblMainVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.stbyVer / 1.0;
            SetText(ucSYMUStatus.lblStbyVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.acuVer / 1.0;
            SetText(ucSYMUStatus.lblAcuVer, tmpVerValue.ToString("0.0"));
            tmpVerValue = muData.monVer / 1.0;
            SetText(ucSYMUStatus.lblMonVer, tmpVerValue.ToString("0.0"));
            return tmpVerValue;
        }

        private void SetPowerState(MUData muData)
        {
            if (muData.powerSt[0] == 0) SetImage(ucSYMUStatus.pbMUPowerMain, Common.Properties.Resources.st_Normal);
            else SetImage(ucSYMUStatus.pbMUPowerMain, Common.Properties.Resources.st_Error);
            if (muData.powerSt[1] == 0) SetImage(ucSYMUStatus.pbMUPowerStby, Common.Properties.Resources.st_Normal);
            else SetImage(ucSYMUStatus.pbMUPowerStby, Common.Properties.Resources.st_Error);
        }

        /// <summary>
        /// LIF 정보 설정
        /// </summary>
        /// <param name="muID"></param>
        /// <param name="muData"></param>
        private void SetLIFData(byte muID, MUData muData)
        {
            for (int i = 0; i < 6; i++)
            {
                if (clsNMS.muLifExist[muID - 1].flagLif[i])
                {
                    SetEnable(ucSYMUStatus.lblRcName[i], true);

                    if (muData.lifSt[i] == 0) SetImage(ucSYMUStatus.pbMULifSt[i], Common.Properties.Resources.st_Normal);
                    else SetImage(ucSYMUStatus.pbMULifSt[i], Common.Properties.Resources.st_Error);
                }
                else
                {
                    SetEnable(ucSYMUStatus.lblRcName[i], false);
                    SetImage(ucSYMUStatus.pbMULifSt[i], Common.Properties.Resources.st_OFF);
                }
            }
        }

        /// <summary>
        /// CCE2 PTT, RC4 PTT, REPEAT PTT
        /// </summary>
        /// <param name="muData"></param>
        private void SetPTTData(MUData muData)
        {
            if (muData.pttSt[0] == 0) SetImage( ucSYMUStatus.ucLif1.pbMURCSt5, Common.Properties.Resources.st_OFF);
            else SetImage(ucSYMUStatus.ucLif1.pbMURCSt5, Common.Properties.Resources.st_ON);

            if (muData.pttSt[1] == 0) SetImage(ucSYMUStatus.ucLif1.pbMURCSt6, Common.Properties.Resources.st_OFF);
            else SetImage(ucSYMUStatus.ucLif1.pbMURCSt6, Common.Properties.Resources.st_ON);

            if (muData.pttSt[2] == 0) SetImage(ucSYMUStatus.ucLif1.pbMURepeatPttSt, Common.Properties.Resources.st_OFF);
            else SetImage(ucSYMUStatus.ucLif1.pbMURepeatPttSt, Common.Properties.Resources.st_ON);
        }

        /// <summary>
        /// PLL LOCK 장애 상태(0:역용 주 PLL LOCK 장애 상태, 1:역용 예비 PLL LOCK 장애 상태, 2:감청용 PLL LOCK 장애 상태)
        /// </summary>
        /// <param name="muData"></param>
        private void SetPLLLock_RuAData(MUData muData)
        {
            //PLL LOCK 장애 상태(0:역용 주 PLL LOCK 장애 상태, 1:역용 예비 PLL LOCK 장애 상태, 2:감청용 PLL LOCK 장애 상태)
            for (int i = 0; i < 3; i++)
            {
                if (muData.pllLockErrorSt[i] == 0) SetImage(ucSYMUStatus.pbPllLockSt[i], Common.Properties.Resources.st_Normal);
                else SetImage(ucSYMUStatus.pbPllLockSt[i], Common.Properties.Resources.st_Error);
            }

            if (ucSYMUStatus.mRuAState)
            {
                //RUA 장애 상태(2015년 09월 10일 추가)
                if (muData.pllLockErrorSt[3] == 0) SetImage(ucSYMUStatus.pbMURUASt, Common.Properties.Resources.st_Normal);

                else SetImage(ucSYMUStatus.pbMURUASt, Common.Properties.Resources.st_Error);
            }
        }

        /// <summary>
        /// 채널 복귀 시간 설정
        /// </summary>
        /// <param name="muData"></param>
        private void SetChannelReturnData(MUData muData)
        {
            //채널 복귀 시간 상태
            if (muData.chReturn == 0) SetText(ucSYMUStatus.lblMUChReturnTime, "OFF");
            else SetText(ucSYMUStatus.lblMUChReturnTime, muData.chReturn.ToString());
        }

        /// <summary>
        /// 주/예비 감청 통신 감시 성남여주에서는 안씀..
        /// </summary>
        /// <param name="muData"></param>
        private void SetTrainceiverCommunication(MUData muData)
        {
            //OPT의 통신 감시 상태(0:주 통신 감시, 1:예비 통신 감시, 2:감청 통신 감시), 각 CPU카드 연결상태(3:MU TRX CPU 장착 상태, 4:MU OPT CPU 장착 상태, 5:UPS 연결 상태) 
            for (int i = 0; i < 6; i++)
            {
                if (muData.optMonSt[i] == 0) SetImage(ucSYMUStatus.pbOptMonSt[i], Common.Properties.Resources.st_Normal);
                else SetImage(ucSYMUStatus.pbOptMonSt[i], Common.Properties.Resources.st_Error);
            }
        }

        private void SetMonitorChannel(MUData muData)
        {
            String tmpCh = null;
            switch (muData.chInfo[2])
            {
                case 0: tmpCh = "SCAN"; break;
                case 1: tmpCh = "1 채널 수신"; break;
                case 2: tmpCh = "2 채널 수신"; break;
                case 3: tmpCh = "3 채널 수신"; break;
                case 4: tmpCh = "4 채널 수신"; break;
                default: tmpCh = "1 채널 수신"; break;
            }
            SetText(ucSYMUStatus.lblMUCHInfo[2], tmpCh);
        }

        private string SetTrainceiverChannelInfo(MUData muData)
        {
            string tmpCh = null;
            for (int i = 0; i < 2; i++)
            {
                switch (muData.chInfo[i])
                {
                    //case 0: tmpCh = "REMOTE"; break;
                    case 1: tmpCh = "리모트 1 채널"; break;
                    case 2: tmpCh = "리모트 2 채널"; break;
                    case 3: tmpCh = "리모트 3 채널"; break;
                    case 4: tmpCh = "리모트 4 채널"; break;
                    case 5: tmpCh = "로컬 1 채널"; break;
                    case 6: tmpCh = "로컬 2 채널"; break;
                    case 7: tmpCh = "로컬 3 채널"; break;
                    case 8: tmpCh = "로컬 4 채널"; break;
                    case 10: tmpCh = "스캔중..."; break;
                    case 11: tmpCh = "스캔 1 채널 수신"; break;
                    case 12: tmpCh = "스캔 2 채널 수신"; break;
                    case 13: tmpCh = "스캔 3 채널 수신"; break;
                    case 14: tmpCh = "스캔 4 채널 수신"; break;
                    default: tmpCh = "리모트 1 채널"; break;
                }

                SetText(ucSYMUStatus.lblMUCHInfo[i], tmpCh);
            }
            return tmpCh;
        }

        /// <summary>
        /// 송신 출력 설정 값 설정
        /// </summary>
        /// <param name="muData"></param>
        private void SetRFSettingValue(MUData muData)
        {
            for (int i = 0; i < 2; i++)
            {
                int tmpRfOutValue = muData.rfValueInquiry[i];
                SetText(ucSYMUStatus.lblMURfMainSpareInquiry[i], tmpRfOutValue.ToString());
            }
        }

        private void SetRSSIValue(MUData muData)
        {
            //MU의 주/예비/감청용 RX RSSI 값
            for (int i = 0; i < 3; i++)
            {
                int tmpValue = muData.rxRssiValue[i];

                //if (tmpValue >= 0x80) tmpValue = (tmpValue - 0x80) * -1;
                tmpValue *= -1;
                SetText(ucSYMUStatus.lblMURXRSSI[i], tmpValue.ToString() + " dBm");
            }
        }

        /// <summary>
        /// 주/예비 RF 값 설정
        /// </summary>
        /// <param name="muData"></param>
        private void SetRFValue(MUData muData)
        {
            //MU의 주/예비 RF 출력값
            double tmpRfValue = 0;
            for (int i = 0; i < 2; i++)
            {
                tmpRfValue = muData.rfValue[i] / 10.0;
                SetText(ucSYMUStatus.lblMURfMainSpare[i], tmpRfValue.ToString("0.0"));
            }
        }

        /// <summary>
        /// Mu 상태 데이터 중 4번째 데이터 
        /// DC값 설정
        /// </summary>
        /// <param name="muData"></param>
        private void SetDCValue(MUData muData)
        {
            double tmpDcValue = muData.dcValue / 10.0;
            SetText(ucSYMUStatus.ucLif1.lblMUDCValue, tmpDcValue.ToString("0.0") + " V");
        }

        /// <summary>
        /// Mu 상태 데이터 중 3번째 데이터
        /// MU의 기타 상태(8: RC2 PTT 상태, 9: RC3 PTT 상태, 10:역용 주 PTT, 11:역용 주 BUSY, 12:역용 예비 PTT, 13:역용 예비 BUSY, 14:역용 감청 BUSY, 15:ACU 카드상태)
        /// </summary>
        /// <param name="muData"></param>
        private void SetETC3Data(MUData muData)
        {
            // MU의 기타 상태(8: RC2 PTT 상태, 9: RC3 PTT 상태, 10:역용 주 PTT, 11:역용 주 BUSY, 12:역용 예비 PTT, 13:역용 예비 BUSY, 14:역용 감청 BUSY, 15:ACU 카드상태)
            for (int i = 0; i < 7; i++)
            {
                if (muData.otherSt2[i] == 0)
                    SetImage(ucSYMUStatus.pbMuOtherSt2[i], Common.Properties.Resources.st_OFF);
                else
                    SetImage(ucSYMUStatus.pbMuOtherSt2[i], Common.Properties.Resources.st_ON);
            }

            if (muData.otherSt2[7] == 0) SetImage(ucSYMUStatus.pbMUACU, Common.Properties.Resources.st_Normal);
            else SetImage(ucSYMUStatus.pbMUACU, Common.Properties.Resources.st_Error);
        }

        /// <summary>
        /// Mu 상태 데이터 중 2번째 데이터 중 3 ~ 8비트까지
        /// 
        /// ac, dc, modopen, ptt. rc1 ptt 표시
        /// </summary>
        /// <param name="muData">Mu Data</param>
        private void SetETC2Data(MUData muData)
        {
            for (int i = 3; i < 6; i++)
            {
                if (muData.otherSt1[i] == 0) SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_Normal);
                else SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_Error);
            }

            for (int i = 6; i < 8; i++)
            {
                if (muData.otherSt1[i] == 0) SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_OFF);
                else SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_ON);
            }
        }

        /// <summary>
        /// 주/예비 표시
        /// </summary>
        /// <param name="muData"></param>
        private void SetMainStbyData(MUData muData)
        {
            //주/예비동작상태 표시할 컨트롤을 버튼으로 변경
            if (muData.otherSt1[1] == 0)
            {
                SetColor(ucSYMUStatus.btMUMainSpare1, ucSYMUStatus.colorSelect);
                SetColor(ucSYMUStatus.btMUMainSpare2, ucSYMUStatus.colorBase);
            }
            else
            {
                SetColor(ucSYMUStatus.btMUMainSpare1, ucSYMUStatus.colorBase);

                //자동인데 예비이면 Error 표시
                if (muData.otherSt1[0] == 0)
                    SetColor(ucSYMUStatus.btMUMainSpare2, ucSYMUStatus.colorError);
                else
                    SetColor(ucSYMUStatus.btMUMainSpare2, ucSYMUStatus.colorSelect);
            }
        }

        /// <summary>
        /// 자동/수동절체상태 표시
        /// </summary>
        /// <param name="muData">mu 정보</param>
        private void SetAutoManuelButtonData(MUData muData)
        {
            //자동/수동절체상태 표시할 컨트롤을 버튼으로 변경
            if (muData.otherSt1[0] == 0)
            {
                SetColor(ucSYMUStatus.btMUAutoManual1, ucSYMUStatus.colorSelect);
                SetColor(ucSYMUStatus.btMUAutoManual2, ucSYMUStatus.colorBase);
            }
            else
            {
                SetColor(ucSYMUStatus.btMUAutoManual1, ucSYMUStatus.colorBase);
                SetColor(ucSYMUStatus.btMUAutoManual2, ucSYMUStatus.colorSelect);
            }
        }

        /// <summary>
        /// MU의 기타 상태(0:자동/수동절체방법상태, 1:주예비동작상태, 2:Wide/Narrow 상태,
        //  3:AC 전원상태, 4:DC 전원상태, 5:MONOPEN 상태, 6:CCE PTT 상태, 7: RC1 PTT 상태)
        /// </summary>
        /// <param name="muData"></param>
        private void SetETCData(MUData muData)
        {
            // MU의 기타 상태(0:자동/수동절체방법상태, 1:주예비동작상태, 2:Wide/Narrow 상태,
            //               3:AC 전원상태, 4:DC 전원상태, 5:MONOPEN 상태, 6:CCE PTT 상태, 7: RC1 PTT 상태)
            for (int i = 0; i < 3; i++)
            {
                if (muData.otherSt1[i] == 0)
                {
                    SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_ON);
                    SetImage(ucSYMUStatus.pbMuOtherSt[i], Common.Properties.Resources.st_OFF);
                }
                else
                {
                    SetImage(ucSYMUStatus.pbMuOtherSt1[i], Common.Properties.Resources.st_OFF);
                    SetImage(ucSYMUStatus.pbMuOtherSt[i], Common.Properties.Resources.st_ON);
                }
            }
        }




        #region 컨트롤 제어(문자출력, 활성화 변경, 색변경)
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //컨트롤의 위치/크기 지정
        private void SetLocationSize(Control control, int width, int height, int left, int top)
        {
            if (control.InvokeRequired)
            {
                SetControlLocationSizeCallback d = new SetControlLocationSizeCallback(SetLocationSize);
                control.Invoke(d, new object[] { control, width, height, left, top });
            }
            else
            {
                control.Width = width;
                control.Height = height;
                control.Left = left;
                control.Top = top;
            }
        }

        //컨트롤에 문자를 출력하기 위함
        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                control.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        //컨트롤에 문자를 출력하기 위함
        private void SetTextAppend(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextAppend);
                control.Invoke(d, new object[] { control, text });
            }
            else
            {
                if (((TextBox)control).Text.Length > 2048)
                    ((TextBox)control).Text = ((TextBox)control).Text.Substring(1024);
                //if (((TextBox)control).Text.Length > 1024)
                //    ((TextBox)control).Text = ((TextBox)control).Text.Substring(512);

                ((TextBox)control).Text += text;

                ((TextBox)control).SelectionStart = ((TextBox)control).Text.Length;//맨 마지막 선택...
                ((TextBox)control).ScrollToCaret();
            }
        }

        //컨트롤의 활성화 여부를 결정하기 위함
        private void SetEnable(Control control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(SetEnable);
                control.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Enabled = flag;
            }
        }

        //컨트롤에 색을 변경하기 위함
        private void SetColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                control.Invoke(d, new object[] { control, color });
            }
            else
            {
                control.BackColor = color;
            }
        }

        //컨트롤의 글자색을 변경하기 위함
        private void SetForeColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetForeColor);
                control.Invoke(d, new object[] { control, color });
            }
            else
            {
                control.ForeColor = color;
            }
        }

        //컨트롤의 Visible값을 변경하기 위함
        private void SetVisible(Control control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(SetVisible);
                control.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Visible = flag;
            }
        }

        //컨트롤에 체크하기 위함
        private void SetChecked(CheckBox control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetCheckedCallback d = new SetCheckedCallback(SetChecked);
                control.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Checked = flag;
            }
        }

        //컨트롤에 체크하기 위함
        private void SetRdButChecked(RadioButton control, bool flag)
        {
            if (control.InvokeRequired)
            {
                SetRdButCheckedCallback d = new SetRdButCheckedCallback(SetRdButChecked);
                control.Invoke(d, new object[] { control, flag });
            }
            else
            {
                control.Checked = flag;
            }
        }

        //컨트롤의 Value값을 변경하기 위함
        private void SetValue(ProgressBar control, int maxValue, int value)
        {
            if (control.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                control.Invoke(d, new object[] { control, maxValue, value });
            }
            else
            {
                control.Maximum = maxValue;
                control.Value = value;
            }
        }

        //TrackBar 컨트롤에 value값을 변경하기 위함
        private void SetValue(TrackBar control, int value)
        {
            if (control.InvokeRequired)
            {
                SetTBValueCallback d = new SetTBValueCallback(SetValue);
                control.Invoke(d, new object[] { control, value });
            }
            else
            {
                control.Value = value;
            }
        }

        //PictureBox에 그림을 변경하기 위함
        private void SetImage(PictureBox control, Bitmap bitmap)
        {
            if (control.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                control.Invoke(d, new object[] { control, bitmap });
            }
            else
            {
                control.Image = bitmap;
            }
        }

        //ListView 컨트롤의 Item을 삭제하기 위함
        private void SetListViewItemClear(ListView Control)
        {
            if (Control.InvokeRequired)
            {
                SetListViewItemClearCallback d = new SetListViewItemClearCallback(SetListViewItemClear);
                Control.Invoke(d, new object[] { Control });
            }
            else
            {
                Control.Items.Clear();
            }
        }

        //ListView 컨트롤의 Item을 추가하기 위함
        private void SetListViewItemInster(ListView control, int index, ListViewItem lvItem)
        {
            if (control.InvokeRequired)
            {
                SetListViewItemInsertCallback d = new SetListViewItemInsertCallback(SetListViewItemInster);
                control.Invoke(d, new object[] { control, index, lvItem });
            }
            else
            {
                control.Items.Insert(index, lvItem);
            }
        }

        //DataGridView의 모든 Row를 삭제하기 위함
        private void SetdataGridViewClear(DataGridView dgvControl)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewClearCallback d = new SetdataGridViewClearCallback(SetdataGridViewClear);
                dgvControl.Invoke(d, new object[] { dgvControl });
            }
            else
            {
                dgvControl.Rows.Clear();
            }
        }

        private void SetdataGridViewMuErrorStValue(DataGridView dgvControl, int index, string dateTime, string content)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuErrorStValueCallback d = new SetdataGridViewMuErrorStValueCallback(SetdataGridViewMuErrorStValue);
                dgvControl.Invoke(d, new object[] { dgvControl, index, dateTime, content });
            }
            else
            {
                dgvControl.Rows.Add();
                //dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
                dgvControl.Rows[index].Cells[1].Value = dateTime;       //날자/시간
                dgvControl.Rows[index].Cells[2].Value = content;    //내용
            }
        }

        private void SetdataGridViewMuErrorStIndex(DataGridView dgvControl, int index, string dateTime, string content)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuErrorStValueCallback d = new SetdataGridViewMuErrorStValueCallback(SetdataGridViewMuErrorStIndex);
                dgvControl.Invoke(d, new object[] { dgvControl, index, dateTime, content });
            }
            else
            {
                dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
            }
        }

        private void SetdataGridViewMuTxRxErxStValue(DataGridView dgvControl, int index, string content, string ch, string startDateTime, string stopDateTime)
        {
            if (dgvControl.InvokeRequired)
            {
                SetdataGridViewMuTxRxErxStValueCallback d = new SetdataGridViewMuTxRxErxStValueCallback(SetdataGridViewMuTxRxErxStValue);
                dgvControl.Invoke(d, new object[] { dgvControl, index, content, ch, startDateTime, stopDateTime });
            }
            else
            {
                dgvControl.Rows.Add();
                dgvControl.Rows[index].Cells[0].Value = (index + 1).ToString();    //순번
                dgvControl.Rows[index].Cells[1].Value = content;    //내용
                dgvControl.Rows[index].Cells[2].Value = ch;         //채널
                dgvControl.Rows[index].Cells[3].Value = startDateTime;  //시작시간
                dgvControl.Rows[index].Cells[4].Value = stopDateTime;   //중지시간
            }
        }
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        #endregion



    }
}
