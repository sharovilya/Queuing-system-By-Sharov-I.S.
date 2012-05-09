using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class RequestTest
    {
        [TestMethod]
        public void TestEqualTwoRequest()
        {
            IRequest r = new Request(1, 1, 2);
            IRequest r1 = new Request(1, 1, 2);

            Assert.IsTrue(r.Equals(r1));
            Assert.AreEqual(r1, r);
        }
    }
}
