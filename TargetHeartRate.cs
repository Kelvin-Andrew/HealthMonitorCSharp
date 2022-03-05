using System;

namespace HealthMonitor
{
    class TargetHeartRate
    {
        private int LowerBoundaryTargetHeartRate { get; set; }
        private int UpperBoundaryTargetHeartRate { get; set; }
        private double[] intensityPercentage = { 0.50, 0.70, 0.80, 0.90, 1.00 };
        private string[] intensity = { "Low", "Moderate", "High", "Max" };
        private void OutputTargetHeartRateBoundaries(string intensity)
        {
            Console.WriteLine($"At {intensity} intensity your target heart range is between {LowerBoundaryTargetHeartRate}" +
                $" and {UpperBoundaryTargetHeartRate}");
        }

        public void CalculateTargetHeartRate(MaximumHeartRate maximumHeartRate)
        {
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                LowerBoundaryTargetHeartRate = (int)(maximumHeartRate.MaxHeartRate * intensityPercentage[i]);
                UpperBoundaryTargetHeartRate = (int)(maximumHeartRate.MaxHeartRate * intensityPercentage[i+1]);
                OutputTargetHeartRateBoundaries(intensity[j]);
                j += 1;
            }  
        } 
    }
}
