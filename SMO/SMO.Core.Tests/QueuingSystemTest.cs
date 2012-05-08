using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMO.Core;

namespace SMO.Core.Tests
{
    [TestClass]
    public class QueuingSystemTest
    {
        IRandomGenerator generator;
        ISystemClock clock;
        IEngine engine;
        IQueuingSystem system;
        ISystemDevices devices;
        IDisciplineQueuingSystem discipline;

        IDevice d1;
        IDevice d2;
        IDevice d3;
        IDevice d4;
        IDevice d5;
                
        private const int COUNT_TEST_REQUEST = 10;
        private const int SIZE_QUEUE = 10;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new MockRandomGenerator();
            clock = new SystemClock();
            engine = new Engine(clock, generator);
            devices = new SystemDevices();
            discipline = new FIFOQueuingSystem(clock, SIZE_QUEUE);
            system = new QueuingSystem(clock, engine, devices, discipline);

            InitializeDevices();
        }

        public void InitializeDevices()
        {
            d1 = new Device(clock, generator); system.Devices.Add(d1);
            d2 = new Device(clock, generator); system.Devices.Add(d2);
            d3 = new Device(clock, generator); system.Devices.Add(d3);
            d4 = new Device(clock, generator); system.Devices.Add(d4);
            d5 = new Device(clock, generator); system.Devices.Add(d5);
        }

        [TestMethod]
        public void TestReceiptOfNewRequest()
        {
            engine.GenerateNewRequest();
            Assert.AreEqual(system.CountRequestInSystem, 1);
        }

        [TestMethod]
        public void TestSystemHandleTenRequest()
        {
            ProcessCountRequest(COUNT_TEST_REQUEST);

            int expectedRequst = system.CountHandledRequest;
            Assert.AreEqual(expectedRequst, COUNT_TEST_REQUEST);
        }

        private void ProcessCountRequest(int countRequest)
        {
            int timeForSomeRequest = generator.GetTimeFor(countRequest);
            int time = 0;
            while (time++ != timeForSomeRequest)
            {
                clock.Tick();
            }
        }

        [TestMethod]
        public void TestSystemOnLoadRequestPutInQueue()
        {
            int countDevices = 5;
            for (int id = 0; id < countDevices; id++)
            {
                engine.GenerateNewRequest();
            }

            Assert.IsTrue(!d1.IsFree && !d3.IsFree && !d3.IsFree && !d4.IsFree && !d5.IsFree);
            
            for (int id = 0; id < SIZE_QUEUE; id++)
            {
                engine.GenerateNewRequest();
            }

            engine.Stop();

            Assert.AreEqual(SIZE_QUEUE, discipline.CountRequestsInQueue);
            Assert.IsTrue(discipline.IsFull);

            while (system.AreRequests)
            {
                clock.Tick();
            }

            Assert.IsTrue(discipline.IsEmpty);
            Assert.AreEqual(countDevices + SIZE_QUEUE, system.CountHandledRequest);
            Assert.IsTrue(d1.IsFree && d3.IsFree && d3.IsFree && d4.IsFree && d5.IsFree);
        }
    }
}
