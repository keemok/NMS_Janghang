using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NMS.Utils
{
    /// <summary>
    /// 콘솔로 출력하는 정보를 출력하고 저장하는 용도의 클래스
    /// </summary>
    public sealed class Debug
    {
        /// <summary>
        /// 데이터 베이스 경로
        /// </summary>
        public static string DATABASE_FOLDER_PATH = Application.StartupPath + "\\Database";

        /// <summary>
        /// 디버그 폴더
        /// </summary>
        public readonly static string DebugFolder = Application.StartupPath + "\\Log";

        /// <summary>
        /// 오늘 디버그
        /// </summary>
        private static string DebugLogPath;

        private static string TxLogPath;
        private static string RxLogPath;

        /// <summary>
        /// 디버그를 저장하는 용도의 쓰레드
        /// </summary>
        private static SaveThread mSaveThread;

        private static SaveThread mTxLogThread;
        private static SaveThread mRxLogThread;

        /// <summary>
        /// 생성자
        /// </summary>
        private Debug()
        {
            mState = false;
        }

        /// <summary>
        /// 디버그 저장 쓰레드 정지
        /// 프로그램이 종료 될 때 실행하면된다.
        /// </summary>
        public static void StopThread()
        {
            if (mSaveThread != null)
                mSaveThread.Stop();
            if (mTxLogThread != null)
                mTxLogThread.Stop();

            if (mRxLogThread != null)
                mRxLogThread.Stop();
        }

        /// <summary>
        /// 디버그를 저장하는 쓰레드 시작
        /// 프로그램이 시작될 때 사용하면 된다.
        /// </summary>
        public static void StartThread()
        {
            var today = DateTime.Today;

            #region 폴더 생성
            //DebugFolder = DebugFolder+ "\\Log";

            Directory.CreateDirectory(DebugFolder);
            string folder = DebugFolder + "\\" + today.Year;
            Directory.CreateDirectory(folder);
            folder = folder + "\\" + today.Month;
            Directory.CreateDirectory(folder);
            mCurrentFolder = folder;



            DebugLogPath = String.Format("{0}\\{1}.txt", mCurrentFolder, DateTime.Today.ToShortDateString());
            TxLogPath = String.Format("{0}\\{1}_TX.txt", mCurrentFolder, DateTime.Today.ToShortDateString());
            RxLogPath = String.Format("{0}\\{1}_RX.txt", mCurrentFolder, DateTime.Today.ToShortDateString());

            #endregion 폴더 생성

            #region 쓰레드 초기화

            mSaveThread = new SaveThread(DebugLogPath);
            mTxLogThread = new SaveThread(TxLogPath);
            mRxLogThread = new SaveThread(RxLogPath);

            #endregion 쓰레드 초기화

            mSaveThread.Start();
            mTxLogThread.Start();
            mRxLogThread.Start();
        }

        /// <summary>
        /// 디버그 모드일 경우 true
        /// </summary>
        private static bool mState = true;
        private static string mCurrentFolder;

        /// <summary>
        /// 디버그를 할 지 안 할지 변경함
        /// </summary>
        /// <param bsName="state"> true or false</param>
        public static void SetDebug(bool state)
        {
            mState = state;
        }


        #region WriteLine
        /// <summary>
        /// Console.WriteLine()과 동일한 동작
        /// </summary>
        /// <param bsName="format">string.Format과 동일하게 쓰면됨</param>
        /// <param bsName="param">포멧에 들어갈 파라메터</param>
        public static void WriteLine(string format, params object[] param)
        {
            string mes = String.Format(format, param);


            if (mState)
            {
                Console.WriteLine(mes);
            }


            WriteDebug(mes);
        }

   

        /// <summary>
        ///  Console.WriteLine()과 동일한 동작
        /// </summary>
        /// <param bsName="o"></param>
        public static void WriteLine(object o)
        {
#if DEBUG
            if (mState)
            {
                Console.WriteLine(o);
            }
#endif

            String mes = o.ToString();
            WriteDebug(mes);
        }

        #endregion
        

        /// <summary>
        /// 콘솔에 출력하는 메시지를 저장함.
        /// </summary>
        /// <param bsName="number"></param>
        private static void WriteDebug(string mes)
        {
            var time = DateTime.Now.ToString();

            string val = String.Format("<{0}>{1}", time, mes);

            if (mSaveThread != null)
                mSaveThread.Add(val);
        }
        
        #region Write
        /// <summary>
        ///  Console.Write()과 동일한 동작
        /// </summary>
        /// <param bsName="o"></param>
        public static void Write(object o)
        {
#if DEBUG
            if (mState)
            {
                Console.WriteLine(o);
            }
#endif

            String mes = o.ToString();
            WriteDebug(mes);
        }

        /// <summary>
        /// Console.Write의 래핑 메소드 사용법은 동일하다.
        /// </summary>
        /// <param bsName="format">사용할 포멧</param>
        /// <param bsName="param">포멧에 사용할 파라메터</param>
        internal static void Write(string format, params object[] param)
        {
#if DEBUG
            if (mState)
            {
                Console.WriteLine(format, param);
            }
#endif

            String mes = string.Format(format, param);
            WriteDebug(mes);
        }

        #endregion



        /// <summary>
        /// 오류를 파일로 출력한다.
        /// </summary>
        /// <param bsName="e">오류 정보</param>
        internal static void PrintError(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);


            Write(String.Format("발생한 곳 : {0}\nInnerException : {1}\n", e.Source, e.InnerException));
            WriteDebug(e.Message);
            //Debug.WriteLine(e.Message);
            WriteDebug(e.StackTrace);
            //Debug.WriteLine(e.StackTrace);
        }

        internal static void WriteToFile(string mes)
        {
            Write(mes);
        }

        /// <summary>
        /// 송신 로그 쓰기
        /// </summary>
        /// <param name="data"></param>
        internal static void WriteTxLog(byte[] data)
        {
            string mes = GetMessage("tx", data);
            mTxLogThread.Add(mes);
        }

        /// <summary>
        /// 수신 로그
        /// </summary>
        /// <param name="data"></param>
        internal static void WriteRxLog(byte[] data)
        {
            string mes = GetMessage("rx", data);
            mRxLogThread.Add(mes);
        }


        internal static void WriteRxLog(byte[] buffer, int lng)
        {
            string mes = GetMessage("rx", buffer, lng);
            mRxLogThread.Add(mes);
            
        }


        /// <summary>
        /// 메시지
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetMessage(string p, byte[] data)
        {
            return string.Format("<{0} : {1}>{2}", p, DateTime.Now.ToString(), BitConverter.ToString(data));
        }

        private static string GetMessage(string p, byte[] data, int len)
        {
            return string.Format("<{0} : {1}>{2}", p, DateTime.Now.ToString(), BitConverter.ToString(data,0,len));
        }


        #region 로그 정리 기능 <미사용>
        /// <summary>
        /// 3개월 전의 로그 데이터를 삭제함.
        /// </summary>
        internal static void DeleteOldLog()
        {
            DateTime today = DateTime.Today;

            //Directory.CreateDirectory(DebugFolder);
            string folder = DebugFolder + "\\" + today.Year;
            //Directory.CreateDirectory(folder);
            folder = folder + "\\" + (today.Month - 3);

            if (Directory.Exists(folder))
            {
                DeleteFolder(folder);
                Directory.Delete(folder);
            }
        }

        private static void DeleteFolder(string folder)
        {
            foreach (var item in Directory.GetFiles(folder))
            {
                if (File.Exists(item))
                    File.Delete(item);
            }

            // 재귀호출로 해당 폴더에 있는걸 모두 삭제
            foreach (var item in Directory.GetDirectories(folder))
            {
                DeleteFolder(item);
                Directory.Delete(item);
            }
        }


        #endregion


        #region 저장 쓰레드

        /// <summary>
        /// 콘솔 출력 정보를 저장하는데 사용하는 쓰레드 클래스
        /// </summary>
        class SaveThread
        {
            /// <summary>
            /// 데이터가 들어 올 때 기다리는 쓰레드
            /// </summary>
            //private Thread mThread;

            /// <summary>
            /// 쓸 데이터
            /// </summary>
            private Queue<string> mBuffer;

            /// <summary>
            /// 시작 중인지 여부
            /// </summary>
            private bool mRun;

            private string mPath;

            private System.Timers.Timer mTimer;

            public SaveThread(string debugPath)
            {
                mPath = debugPath;

                mTimer = new System.Timers.Timer();
                mTimer.Elapsed += Run;
                mTimer.Interval = 300;
                
                mBuffer = new Queue<string>();
            }

            private void Run(object sender, System.Timers.ElapsedEventArgs e)
            {
                if (mBuffer.Count > 0)
                {
                    string val = mBuffer.Dequeue();

                    Write(val);
                }

            }

            /// <summary>
            /// 쓰레드 시작
            /// </summary>
            public void Start()
            {
                mRun = true;
                mTimer.Start();
            }

            /// <summary>
            /// 쓰레드 중지
            /// </summary>
            public void Stop()
            {
                mRun = false;
                mTimer.Stop();
            }

            /// <summary>
            /// 쓸 메시지를 추가함.
            /// </summary>
            /// <param bsName="message"></param>
            public void Add(string message)
            {
                mBuffer.Enqueue(message);
            }

            /// <summary>
            /// 쓰레드 구현부
            /// </summary>
            private void Run()
            {
                while (mRun)
                {
                    if (mBuffer.Count > 0)
                    {
                        string val = mBuffer.Dequeue();

                        Write(val);
                    }

                    Thread.Sleep(300);
                }
            }

            /// <summary>
            /// txt 파일에 쓰기
            /// </summary>
            /// <param bsName="val">쓸 값</param>
            private void Write(string val)
            {
                try
                {
                    if (File.Exists(mPath))
                    {
                        //var lines = File.ReadAllLines(mPath);
                        //var list = lines.ToList();

                        //list.Add(val);

                        File.AppendAllLines(mPath, new string[]{val});

                        //File.WriteAllLines(mPath, list);
                    }
                    else
                    {
                        File.WriteAllLines(mPath, new String[] { val });
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Debug.WriteLine(e.StackTrace);
                    }
                    catch
                    {

                    }
                }

            }
        }

        #endregion 저장 쓰레드

    }
}