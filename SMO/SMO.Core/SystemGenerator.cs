using System;
using System.Collections.Generic;

namespace SMO.Core
{
    public class SystemGenerator : ISystemGenerator
    {
        private const double M = 2147483647;
        private const double A = 630360016;

        private readonly List<int> intervals = new List<int>();
        private readonly List<int> processing = new List<int>();
        private double current = 321160;
        private int intervalTime;
        private int processingTime;

        #region ISystemGenerator Members

        public int NextProcessingTime
        {
            get { return CalculationProcessing(); }
        }

        public int NextIntervalTime
        {
            get { return CalculationInterval(); }
        }

        public int GetTimeFor(int countRequest)
        {
            return -1;
        }

        public void SetAvgProcessingTime(int processingTime)
        {
            this.processingTime = processingTime;
        }

        public void SetAvgIntervalTime(int intervalTime)
        {
            this.intervalTime = intervalTime;
        }

        public void Reset()
        {
            current = 321160;
            intervals.Clear();
            processing.Clear();
        }

        #endregion

        private int CalculationInterval()
        {
            var result = (int) (-intervalTime*Math.Log(Calculation()));
            intervals.Add(result);
            return result;
        }

        private int CalculationProcessing()
        {
            var result = (int) (-processingTime*Math.Log(Calculation()));
            processing.Add(result);
            return result;
        }

        private double Calculation()
        {
            current = ((A*current)%M)/M;
            return current;
        }
    }
}