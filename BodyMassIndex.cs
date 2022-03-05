using System;

namespace HealthMonitor
{
    abstract class BodyMassIndex
    {
        protected Input input;
        protected double BMI { get; set; } = 0.0;
        protected string BMICategory { get; set; }
        protected double[] boundary = { 18.0, 25.0, 30.0, 35.0, 40.0 };
        public virtual string WeightMessage { get; }
        public virtual string HeightMessage { get; }
        public abstract void CalculateBMI();

        public void RunBodyMassIndex()
        {
            CalculateBMI();
            CalculateBMICategory();
            OutputBodyMassIndex();
            OutputBodyMassIndexCategory();
        }

        protected void CalculateBMICategory()
        {
            if (BMI < boundary[0])
            {
                BMICategory = "Underweight";
            }
            else if (BMI >= boundary[0] && BMI < boundary[1])
            {
                BMICategory = "Normal";
            }
            else if (BMI >= boundary[1] && BMI < boundary[2])
            {
                BMICategory = "Overweight";
            }
            else if (BMI >= boundary[2] && BMI < boundary[3])
            {
                BMICategory = "Obese Class 1";
            }
            else if (BMI >= boundary[3] && BMI < boundary[4])
            {
                BMICategory = "Obese Class 2";
            }
            else if (BMI >= boundary[4])
            {
                BMICategory = "Obese Class 3";
            }
        }

        protected void OutputBodyMassIndex()
        {
            Console.WriteLine($"BMI: {BMI}");
        }

        protected void OutputBodyMassIndexCategory()
        {
            Console.WriteLine($"BMI Category: {BMICategory}");
        }

    }
}
