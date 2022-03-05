using System;

namespace HealthMonitor
{
    class FairburnMaxHeartRate : MaximumHeartRate, ICalculateMaxHeartRate
    {
        public override string MaxHeartRateVersion { get; } = "Fairburn";

        public FairburnMaxHeartRate(Human human, TargetHeartRate targetHeartRate)
        {
            this.human = human;
            this.targetHeartRate = targetHeartRate;
        }

        public double CalculateMaxHeartRate()
        {
            if(human.IsFemale)
            {
                return 201 - 0.63 * human.Age;
            }
            else
            {
                return 208 - 0.80 * human.Age;
            }   
        }

        public override void RunMaxHeartRate()
        {
            MaxHeartRate = Math.Round(CalculateMaxHeartRate());
            OutputMaxHeartRate();
        }
    }
}
