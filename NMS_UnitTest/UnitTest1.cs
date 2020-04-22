using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMS;
using System.Threading;

namespace NMS_UnitTest
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            frmMain main = new frmMain();

            PrivateObject obj = new PrivateObject(main);

            obj.Invoke("DeleteLog", null);

            obj.Invoke("PingTest", null);


            var t =(bool) obj.GetField("PingTestSuccess");

            Assert.AreEqual(true, t);

            if (t)
                Console.WriteLine("Ping Test 성공");

        }


    }
}
