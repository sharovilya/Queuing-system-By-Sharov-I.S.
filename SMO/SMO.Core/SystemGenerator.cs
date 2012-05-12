using System;
using System.Collections.Generic;

namespace SMO.Core
{
    public class SystemGenerator : ISystemGenerator
    {
        private double M = Math.Pow(2.0, 31.0) - 1.0;
        private double A = 630360016;

        private readonly List<int> intervals = new List<int>();
        private readonly List<int> processing = new List<int>();
        private double current = 321160;
        
        #region ISystemGenerator Members

        public int NextProcessingTime
        {
            get { return CalculationProcessing(); }
        }

        public int NextIntervalTime
        {
            get { return CalculationInterval(); }
        }

        public int AvgIntervalTime { get;
            set;
        }

        public int AvgProcessingTime
        {
            get; set;
        }

        public int GetTimeFor(int countRequest)
        {
            return -1;
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
            var result = (int) (-AvgIntervalTime*Math.Log(Calculation()));
            intervals.Add(result);
            return result;
        }

        private int CalculationProcessing()
        {
            var result = (int) (-AvgProcessingTime*Math.Log(Calculation()));
            processing.Add(result);
            return result;
        }

        public double Calculation()
        {
            current = (A*current)%M;
            return current / M;
        }
    }
}