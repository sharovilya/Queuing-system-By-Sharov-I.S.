using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class DeviceTest
    {
        ISystemClock clock;
        IRandomGenerator generator;
        IDevice d1;
        IRequest request;

        int countHandledRequest;
        bool isHandled = false;

        [TestInitialize]
        public void TestInitialize()
        {
            request = Request.New(1);
            generator = new MockRandomGenerator();
            clock = new SystemClock();
            d1 = new Device(clock, generator);
            d1.RequestHandledEvent += d1_RequestHandledEvent;
        }

        void d1_RequestHandledEvent(object sender, EventArgs e)
        {
            countHandledRequest++;
            isHandled = true;
        }

        [TestMethod]
        public void TestTakeDevice()
        {
            d1.Take(request);
            Assert.IsFalse(d1.IsFree);
        }

        [TestMethod]
        public void TestDeviceHandleRequest()
        {
            d1.Take(request);

            while (!isHandled)
            {
                clock.Tick();
            }

            Assert.AreEqual(1, countHandledRequest);
            Assert.IsTrue(d1.IsFree);
        }
    }
}
