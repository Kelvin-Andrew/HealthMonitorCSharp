using System;

namespace HealthMonitor
{
    class ImperialBodyMassIndex: BodyMassIndex
    {
        private Human _human;
        public override string WeightMessage { get; } = "Please enter the Weight in Pounds";
        public override string HeightMessage { get; } = "Please enter the Height in Inches";
        public ImperialBodyMassIndex(Human human, Input input)
        {
            _human = human;
            this.input = input;
        }
        public override void CalculateBMI()
        {
            BMI = Math.Round((_human.Weight * 703) / Math.Pow(_human.Height, 2), 2); 
        }
    }
}
