using System;

namespace HealthMonitor
{
    class Gellish2MaxHeartRate : MaximumHeartRate, ICalculateMaxHeartRate
    {
        public override string MaxHeartRateVersion { get; } = "Gellish 2";

        public Gellish2MaxHeartRate(Human human, TargetHeartRate targetHeartRate)
        {
            this.human = human;
            this.targetHeartRate = targetHeartRate;
        }

        public double CalculateMaxHeartRate()
        {
            return 191.5 - 0.007 * Math.Pow(human.Age, 2);
        }
        public override void RunMaxHeartRate()
        {
            MaxHeartRate = Math.Round(CalculateMaxHeartRate());
            OutputMaxHeartRate();
        }
    }
}
