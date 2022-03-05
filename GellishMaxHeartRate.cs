using System;

namespace HealthMonitor
{
    class GellishMaxHeartRate : MaximumHeartRate, ICalculateMaxHeartRate
    {
        public override string MaxHeartRateVersion { get; } = "Gellish";

        public GellishMaxHeartRate(Human human, TargetHeartRate targetHeartRate)
        {
            this.human = human;
            this.targetHeartRate = targetHeartRate;
        }

        public double CalculateMaxHeartRate()
        {
            return 206.9 - (0.67 * human.Age);
        }

        public override void RunMaxHeartRate()
        {
            MaxHeartRate = Math.Round(CalculateMaxHeartRate());
            OutputMaxHeartRate();
        }
    }
}
