using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMO.Core;
using SMO.UI;

namespace SMO.Core.Tests
{
    [TestClass]
    public class DisciplineQueuingSystemTest
    {
        ISystemDiscipline systemDiscipline;
        ISystemClock clock;
        int size = 5;

        Request r1;
        Request r2;
        Request r3;
        Request r4;

        [TestInitialize]
        public void TestInitialize()
        {
            clock = new SystemClock();
            systemDiscipline = new Fifo();
            systemDiscipline.TotalSize = size;
            InitializeQueue();
        }

        private void InitializeQueue()
        {
            r1 = new Request(1, 1, 1); systemDiscipline.Put(r1);
            r2 = new Request(2, 1, 2); systemDiscipline.Put(r2);
            r3 = new Request(3, 1, 3); systemDiscipline.Put(r3);
            r4 = new Request(4, 1, 4); systemDiscipline.Put(r4);
        }

        [TestMethod]
        public void TestPutRequestInDisciplineSystem()
        {
            Assert.AreEqual(r1, systemDiscipline.PullOut(), "1");
            Assert.AreEqual(r2, systemDiscipline.PullOut(), "2");
            Assert.AreEqual(r3, systemDiscipline.PullOut(), "3");
            Assert.AreEqual(r4, systemDiscipline.PullOut(), "4");            
        }

        [TestMethod]
        public void TestQueueOverflow()
        {
            try
            {
                systemDiscipline.Put(new Request(5, 1, 1));
                systemDiscipline.Put(new Request(5, 1, 2));
                systemDiscipline.Put(new Request(5, 1, 3));

                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}
