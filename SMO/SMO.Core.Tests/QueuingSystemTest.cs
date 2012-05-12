using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class QueuingSystemTest
    {
        private const int COUNT_TEST_REQUEST = 10;
        private const int SIZE_QUEUE = 10;
        private ISystemClock clock;
        private ISystemConfiguration configuration;

        private Device d1;
        private Device d2;
        private Device d3;
        private Device d4;
        private Device d5;
        private ISystemDevices devices;
        private ISystemDiscipline systemDiscipline;
        private IEngine engine;
        private ISystemGenerator generator;
        private ISystemStatistics statistics;
        private IQueuingSystem system;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new MockSystemGenerator();

            clock = new SystemClock();
            engine = new Engine(clock, generator);
            devices = new SystemDevices(clock);


            systemDiscipline = new Fifo {TotalSize = 10};

            configuration = new SystemConfiguration(generator, devices, systemDiscipline);

            statistics = new SystemStatistics();

            system = new QueuingSystem(configuration, clock, engine, statistics);

            InitializeDevices();
        }

        public void InitializeDevices()
        {
            d1 = new Device(clock);
            devices.Add(d1);
            d2 = new Device(clock);
            devices.Add(d2);
            d3 = new Device(clock);
            devices.Add(d3);
            d4 = new Device(clock);
            devices.Add(d4);
            d5 = new Device(clock);
            devices.Add(d5);
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

            Assert.AreEqual(SIZE_QUEUE, systemDiscipline.CountRequestsInQueue);
            Assert.IsTrue(systemDiscipline.IsFull);

            while (system.AreRequests)
            {
                clock.Tick();
            }

            Assert.IsTrue(systemDiscipline.IsEmpty);
            Assert.AreEqual(countDevices + SIZE_QUEUE, system.CountHandledRequest);
            Assert.IsTrue(d1.IsFree && d3.IsFree && d3.IsFree && d4.IsFree && d5.IsFree);
        }
    }
}