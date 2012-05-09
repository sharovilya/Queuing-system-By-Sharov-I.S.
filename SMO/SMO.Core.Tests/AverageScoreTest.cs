using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMO.Core.Tests
{
    [TestClass]
    public class AverageScoreTest
    {
        private AverageScore score;

        [TestInitialize]
        public void TestInitialize()
        {
            score = new AverageScore();
        }

        [TestMethod]
        public void TestAverageScorerGetResult()
        {
            score.Score(1);
            score.Score(1.5);
            score.Score(2.5);
            score.Score(2.5);

            double expectedResult = 7.5/4.0;
            Assert.AreEqual(expectedResult, score.Result);
        }
    }
}