namespace SMO.Core
{
    public class AverageScore
    {
        public double Result { get; private set; }
        public double Count { get; private set; }

        public void Score(double p)
        {
            double old = Count++;
            Result = (old/Count)*Result + p/Count;
        }

        public void Reset()
        {
            Count = 0;
            Result = 0;
        }
    }
}