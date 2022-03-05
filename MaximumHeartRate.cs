using System;

namespace HealthMonitor
{
    abstract class MaximumHeartRate
    {
        protected Human human;
        protected TargetHeartRate targetHeartRate;
        public virtual string MaxHeartRateVersion { get; }
        public double MaxHeartRate { get; set; }
        public abstract void RunMaxHeartRate();
        public void OutputMaxHeartRate()
        {
            Console.WriteLine($"\nBased on the {MaxHeartRateVersion} algorithm, " +
                $"your maximum heart rate is {MaxHeartRate}");
        }
    }
}
