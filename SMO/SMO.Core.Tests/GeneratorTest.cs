using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class GeneratorTest
    {
        SystemGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new SystemGenerator();
        }

        [TestMethod] 
        public void TestAvgIntervalValue()
        {
            int runs = 10000000;
            generator.AvgIntervalTime = 10;
            var runsResult = new List<int>();
            for (int i = 0; i < runs; i++)
            {
                runsResult.Add(generator.NextIntervalTime);
            }

            var real = runsResult.Average();
            Console.WriteLine(Math.Floor(real));
            Assert.IsTrue((10 - Math.Floor(real)) < 1);
        }

        [TestMethod]
        public void TestAvgProcessingValue()
        {
            int runs = 10000000;
            generator.AvgProcessingTime = 25;
            var runsResult = new List<int>();
            for (int i = 0; i < runs; i++)
            {
                runsResult.Add(generator.AvgProcessingTime);
            }

            var real = runsResult.Average();
            Assert.IsTrue((25 - Math.Floor(real)) < 1);
        }
    }
}
