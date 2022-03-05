using System;

namespace HealthMonitor
{
    class RangeValidation
    {
        public bool ValidateRange(int value, int lowerBoundary, int upperBoundary)
        {
            bool isValid = false;

            if(value >= lowerBoundary && value <= upperBoundary)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine($"The value entered: {value} is outside the acceptable range.\n" +
                    $"The value must be between {lowerBoundary} and {upperBoundary}");
            }
            return isValid;     
        }

        public bool ValidateRange(double value, double lowerBoundary, double upperBoundary)
        {
            bool isValid = false;

            if (value >= lowerBoundary && value <= upperBoundary)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine($"The value entered: {value} is outside the acceptable range.\n" +
                    $"The value must be between {lowerBoundary} and {upperBoundary}");
            }
            return isValid;
        }
    }
}
