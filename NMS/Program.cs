using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NMS
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(){

            #region 중복 실행 검사
            string mtxName = "NMS";

            Mutex mtx = new Mutex(true, mtxName);

            TimeSpan tsWait = new TimeSpan(0, 0, 1);
            bool success = mtx.WaitOne(tsWait);

            if (!success)
            {
                MessageBox.Show("프로그램이 이미 실행 중입니다.", "중복 실행", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
