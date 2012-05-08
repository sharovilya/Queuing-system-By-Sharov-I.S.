using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMO.Core;
using SMO.UI;

namespace SMO.Core.Tests
{
    [TestClass]
    public class DisciplineQueuingSystemTest
    {
        IDisciplineQueuingSystem discipline;
        ISystemClock clock;
        int size = 5;

        IRequest r1;
        IRequest r2;
        IRequest r3;
        IRequest r4;

        [TestInitialize]
        public void TestInitialize()
        {
            clock = new SystemClock();
            discipline = new FIFOQueuingSystem(clock, size);
            InitializeQueue();
        }

        private void InitializeQueue()
        {
            r1 = new Request(1); discipline.Put(r1);
            r2 = new Request(2); discipline.Put(r2);
            r3 = new Request(3); discipline.Put(r3);
            r4 = new Request(4); discipline.Put(r4);
        }

        [TestMethod]
        public void TestPutRequestInDisciplineSystem()
        {
            Assert.AreEqual(r1, discipline.PullOut(), "1");
            Assert.AreEqual(r2, discipline.PullOut(), "2");
            Assert.AreEqual(r3, discipline.PullOut(), "3");
            Assert.AreEqual(r4, discipline.PullOut(), "4");            
        }

        [TestMethod]
        public void TestQueueOverflow()
        {
            try
            {
                discipline.Put(new Request(5));
                discipline.Put(new Request(5));
                discipline.Put(new Request(5));

                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}
