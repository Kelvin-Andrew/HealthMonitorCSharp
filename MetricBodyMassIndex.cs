using System;

namespace HealthMonitor
{
    class MetricBodyMassIndex: BodyMassIndex
    {
        private Human _human;
        public override string WeightMessage { get; } = "Please enter the Weight in Kilograms";
        public override string HeightMessage { get; } = "Please enter the Height in Meters";
        public MetricBodyMassIndex(Human human, Input input)
        {
            _human = human;
            this.input = input;
        }
        public override void CalculateBMI()
        {
            BMI = Math.Round(_human.Weight / Math.Pow(_human.Height, 2), 2);
        }
    }
}
