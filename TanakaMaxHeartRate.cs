using System;

namespace HealthMonitor
{
    class TanakaMaxHeartRate : MaximumHeartRate, ICalculateMaxHeartRate
    {
        public override string MaxHeartRateVersion { get; } = "Tanaka";

        public TanakaMaxHeartRate(Human human, TargetHeartRate targetHeartRate)
        {
            this.human = human;
            this.targetHeartRate = targetHeartRate;
        }
        public double CalculateMaxHeartRate()
        {
            return 208 - (0.7 * human.Age);
        }

        public override void RunMaxHeartRate()
        {
            MaxHeartRate = Math.Round(CalculateMaxHeartRate());
            OutputMaxHeartRate();
        }
    }
}
