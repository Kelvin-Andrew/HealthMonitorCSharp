using System;

namespace HealthMonitor
{
    class CERGMaxHeartRate : MaximumHeartRate, ICalculateMaxHeartRate
    {
        public override string MaxHeartRateVersion { get; } = "Cardiac Exercise Research Group (CERG)";
        public CERGMaxHeartRate(Human human, TargetHeartRate targetHeartRate)
        {
            this.human = human;
            this.targetHeartRate = targetHeartRate;
        }

        public double CalculateMaxHeartRate()
        {
            return 211 - 0.64 * human.Age;
        }

        public override void RunMaxHeartRate()
        {
            MaxHeartRate = Math.Round(CalculateMaxHeartRate());
            OutputMaxHeartRate();
        }
    }
}
