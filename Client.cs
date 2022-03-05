using System;
using System.Collections.Generic;

namespace HealthMonitor
{
    class Client
    {
        private Input _input;
        private RangeValidation _rangeValidation;
        private TargetHeartRate _targetHeartRate;
        private Human _human;
        private BodyMassIndex _imperialBodyMassIndex;
        private BodyMassIndex _metricBodyMassIndex;
        private byte _maxHeartRateVersion;
        private byte _imperialOrMetric;
        public Client()
        {
            _input = new Input();
            _rangeValidation = new RangeValidation();
            _targetHeartRate = new TargetHeartRate();
            _human = new Human(_input, _rangeValidation, _imperialOrMetric);
            _imperialBodyMassIndex = new ImperialBodyMassIndex(_human, _input);
            _metricBodyMassIndex = new MetricBodyMassIndex(_human, _input);
        }
        public void RunClient()
        {
            _imperialOrMetric = ImperialOrMetric();
            _human.ImperialOrMetric = _imperialOrMetric;

            List<MaximumHeartRate> maximumHeartRates = new List<MaximumHeartRate>();
            maximumHeartRates.Add(new GellishMaxHeartRate(_human, _targetHeartRate));
            maximumHeartRates.Add(new Gellish2MaxHeartRate(_human, _targetHeartRate));
            maximumHeartRates.Add(new TanakaMaxHeartRate(_human, _targetHeartRate));
            maximumHeartRates.Add(new CERGMaxHeartRate(_human, _targetHeartRate));
            maximumHeartRates.Add(new FairburnMaxHeartRate(_human, _targetHeartRate));

            _human.RunHuman();

            _maxHeartRateVersion = MaxHeartRateVersion();

            if (_maxHeartRateVersion == 1)
            {
                maximumHeartRates[0].RunMaxHeartRate();
                _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[0]);
            }
            else if (_maxHeartRateVersion == 2)
            {
                maximumHeartRates[1].RunMaxHeartRate();
                _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[1]);
            }
            else if (_maxHeartRateVersion == 3)
            {
                maximumHeartRates[2].RunMaxHeartRate();
                _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[2]);
            }
            else if (_maxHeartRateVersion == 4)
            {
                maximumHeartRates[3].RunMaxHeartRate();
                _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[3]);
            }
            else if (_maxHeartRateVersion == 5)
            {
                maximumHeartRates[4].RunMaxHeartRate();
                _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[4]);
            }
            else if (_maxHeartRateVersion == 6)
            {
                int i = 0;
                foreach(MaximumHeartRate maximumHeartRate in maximumHeartRates)
                {
                    maximumHeartRate.RunMaxHeartRate();
                    _targetHeartRate.CalculateTargetHeartRate(maximumHeartRates[i]);
                    i += 1;
                }
            }

            if (_imperialOrMetric == 1)
            { 
                _imperialBodyMassIndex.RunBodyMassIndex();
            }
            else if (_imperialOrMetric == 2)
            {   
                _metricBodyMassIndex.RunBodyMassIndex();
            }
        }

        private byte ImperialOrMetric()
        {
            byte choice = 0;
            bool isValid = false;
            do
            {
                Console.WriteLine("Will you be providing Imperial (Pounds and Inches) or Metric (Kilograms and Meters) units?\n" +
                "For Imperial units press 1\n" +
                "For Metric units press 2\n");
                isValid = Byte.TryParse(Console.ReadLine(), out choice);
                if (!isValid)
                {
                    Console.WriteLine("Type Error. Enter a byte only. Please try again");
                }
                if(choice < 1 || choice > 2)
                {
                    Console.WriteLine("Incorrect data entered. Only integer values of 1 and 2 are accepted");
                }
            } while (!isValid || choice < 1 || choice > 2);
            return choice;
        }

        private byte MaxHeartRateVersion()
        {
            byte choice = 0;
            bool isValid = false;
            do
            {
                Console.WriteLine("Which version / algorithm would you like to use to calculate your Maximum Heart Rate?\n" +
                "Press 1 for Gellish\n" +
                "Press 2 for Gellish Version 2\n" + 
                "Press 3 for Tanaka\n" +
                "Press 4 for Cardiac Exercise Research Group\n" +
                "Press 5 for Fairburn\n" +
                "Press 6 to calculate them all\n");
                isValid = Byte.TryParse(Console.ReadLine(), out choice);
                if (!isValid)
                {
                    Console.WriteLine("Type Error. Enter a byte only. Please try again");
                }
                if (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Incorrect data entered. Only integer values between 1 and 5 are accepted");
                }
            } while (!isValid || choice < 1 || choice > 6);
            return choice;
        }
    }
}