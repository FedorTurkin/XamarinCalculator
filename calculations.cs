using System;
namespace calculator
{
    public class calculations
    {
        public calculations()
        {
        }


        public string add(float a, float b)
        { 
            return (a + b).ToString();
        }

        public string subtract(float a, float b)
        {
            return (a - b).ToString();
        }

        public string multiply(float a, float b)
        {
            return (a * b).ToString();

        }

        public string divide(float a, float b)
        {
            return (a / b).ToString();
        }
    }
}

