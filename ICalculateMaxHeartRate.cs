using System;

namespace HealthMonitor
{
    interface ICalculateMaxHeartRate
    {
        public string MaxHeartRateVersion { get; }
        public double MaxHeartRate { get; set; }
        public double CalculateMaxHeartRate();
        public void RunMaxHeartRate();
        public void OutputMaxHeartRate()
        {
            Console.WriteLine($"Based on the {MaxHeartRateVersion} algorithm, " +
                $"your maximum heart rate is {MaxHeartRate}");
        }       
    }
}
