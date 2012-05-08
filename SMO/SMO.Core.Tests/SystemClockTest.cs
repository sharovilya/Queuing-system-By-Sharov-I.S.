using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMO.Core;

namespace SMO.Core.Tests
{
    [TestClass]
    public class SystemClockTest
    {
        [TestMethod]
        public void TestClockTick()
        {
            ISystemClock clock = new SystemClock();
            var c1 = new MockSystemComponent(clock);
            var c2 = new MockSystemComponent(clock);
            var c3 = new MockSystemComponent(clock);
            clock.Tick();
            int result = c1.Time + c2.Time + c3.Time;
            Assert.AreEqual(3, result);
        }
    }
}
