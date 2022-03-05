using System;

namespace HealthMonitor
{
    class Input
    {
        public string RawInput { get; set; }
        public string TypeError { get; } = "Value entered is not the correct type. Please enter a valid value";
        public double GetInputAndTypeValidate(string message, double value)
        {
            Console.WriteLine(message);
            bool isValid = false;
            do
            {
                isValid = double.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine(TypeError);
                }     
            } while (!isValid);
            return value;
        }

        public int GetInputAndTypeValidate(string message, int value)
        {
            Console.WriteLine(message);
            bool isValid = false;
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine(TypeError);
                }
            } while (!isValid);
            return value;
        }

        public bool GetInputAndTypeValidate(string message, bool value)
        {
            Console.WriteLine(message);
            bool isValid = false;
            do
            {
                isValid = bool.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine(TypeError);
                }
            } while (!isValid);
            return value;
        }

    }
}
