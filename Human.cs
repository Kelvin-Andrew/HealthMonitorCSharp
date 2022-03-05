namespace HealthMonitor
{
    class Human
    {
        private Input _input;
        private RangeValidation _rangeValidation;
        public int Age { get; set; }
        public bool IsFemale { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public byte ImperialOrMetric { get; set; }

        public Human(Input input, RangeValidation rangeValidation, byte imperialOrMetric)
        {
            _input = input;
            _rangeValidation= rangeValidation;
            ImperialOrMetric = imperialOrMetric;
        }

        //Improves usability by defining units when asking user for height and weight, depending on whether they select metric or imperial units
        private string DetermineWeightMessage(byte imperialOrMetric) => imperialOrMetric == 1 ? "Pounds" : "Kilograms";
        private string DetermineHeightMessage(byte imperialOrMetric) => imperialOrMetric == 1 ? "Inches" : "Meters (E.G: 1.75 for 175cm)";
        public void RunHuman()
        {
            Age = _input.GetInputAndTypeValidate("Please enter your age", Age);
            _rangeValidation.ValidateRange(Age, 0, 150);
            IsFemale = _input.GetInputAndTypeValidate("Were you born a female? Enter \"false\" for no, enter \"true\" for yes", IsFemale);
            Weight = _input.GetInputAndTypeValidate($"Please enter your weight in {DetermineWeightMessage(ImperialOrMetric)}", Weight);
            _rangeValidation.ValidateRange(Weight, 0, 1000);
            Height = _input.GetInputAndTypeValidate($"Please enter your height in {DetermineHeightMessage(ImperialOrMetric)}", Height );
            _rangeValidation.ValidateRange(Height, 0.0, 118.0);
        }
    }
}
