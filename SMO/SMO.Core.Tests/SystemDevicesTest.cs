using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMO.Core;

namespace SMO.Core.Tests
{
    [TestClass]
    public class SystemDevicesTest
    {
        ISystemDevices devices;
        IRandomGenerator generator;
        ISystemClock clock;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new MockRandomGenerator();
            clock = new SystemClock();
            devices = new SystemDevices();

            devices.Add(new Device(clock, generator));
            devices.Add(new Device(clock, generator));
        }

        [TestMethod]
        public void TestTakeFreeDeviceInSystem()
        {
            Assert.IsTrue(devices.ThereIsFreeDevice, "Empty");

            devices.TakeFreeDevice(Request.New(1));
            Assert.IsTrue(devices.ThereIsFreeDevice, "1 device busy");

            devices.TakeFreeDevice(Request.New(2));
            Assert.IsFalse(devices.ThereIsFreeDevice, "All device busy");
        }

        [TestMethod]
        public void TestHandleRequestOnBusyDevice()
        {
            int countRequest = 2;
            int timeForRequest = generator.GetTimeFor(countRequest);
            int time = 0;

            devices.TakeFreeDevice(Request.New(1));
            devices.TakeFreeDevice(Request.New(2));

            Assert.IsFalse(devices.ThereIsFreeDevice);
            while (time++ != timeForRequest)
            {
                clock.Tick();
            }

            Assert.IsTrue(devices.ThereIsFreeDevice);
        }
    }
}
