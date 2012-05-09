using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class EngineTest
    {
        IEngine engine;
        ISystemClock clock;
        ISystemGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new MockSystemGenerator();
            clock = new SystemClock();
            engine = new Engine(clock, generator);
            engine.NewRequestEvent += engine_NewRequestEvent;
        }

        [TestMethod]
        public void TestGenerateNewRequest()
        {
            engine.GenerateNewRequest();
            Assert.IsTrue(requestIsGenerated);
        }

        [TestMethod]
        public void TestGenerateNewRequestOnClock()
        {
            NextRequest();
            Assert.IsTrue(requestIsGenerated);
        }

        [TestMethod]
        public void TestGenerateTenRequestOnClock()
        {
            int timeForSomeRequest = generator.GetTimeFor(COUNT_TEST_REQUEST);
            int time = 0;
            while (time++ < timeForSomeRequest)
            {
                clock.Tick();
            }
            int expectedRequest = engine.CountGeneratedRequest;
            Assert.AreEqual(expectedRequest, COUNT_TEST_REQUEST);
        }

        private const int COUNT_TEST_REQUEST = 10;

        private void NextRequest()
        {
            requestIsGenerated = false;
            int time = 0;

            int nextTimeRequest = engine.NextTimeForNewRequest;
            while (time <= nextTimeRequest)
            {
                clock.Tick();
                time++;
            }
        }

        private bool requestIsGenerated = false;

        void engine_NewRequestEvent(object sender, EventArgs e)
        {
            requestIsGenerated = true;
        }
    }
}
