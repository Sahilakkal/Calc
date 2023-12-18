using System;

namespace Power
{
    public class PowerOperations
    {


        static double CalculateTrigonometricValue(double angle, string inputUnit)
        {
            double angleRad;

            switch (inputUnit)
            {
                case "radian":
                    angleRad = angle;
                    break;
                case "DEG":
                    angleRad = angle * 180.0 / Math.PI;
                    break;
                case "gradian":
                    angleRad = angle * 200 / Math.PI;
                    break;
                default:
                    throw new ArgumentException("Invalid unit. Supported units are 'radian', 'DEG', and 'gradian'.");
            }

            return angleRad;
        }

        public static double Sine(double angle)
        {
            return Math.Sin(angle);
        }

        public static double Cosine(double angle)
        {
            const double epsilon = 1e-10;
            return Math.Cos(angle) < epsilon ? 0 : Math.Cos(angle);
        }

        public static double Tangent(double angle)
        {
            return Math.Tan(angle);
        }

        public static double Cot(double angle)
        {
            return Math.Cos(angle) / Math.Sin(angle);
        }

        public static double Sec(double angle)
        {
            return 1 / Math.Cos(angle);
        }

        public static double Cosec(double angle)
        {
            return 1 / Math.Sin(angle);
        }

        public static double SineInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Asin(angle), status);
        }

        public static double CosineInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Acos(angle), status);
        }

        public static double TangentInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Atan(angle), status);
        }

        public static double CotInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Atan(1 / angle), status);
        }

        public static double SecInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Acos(1 / angle), status);
        }

        public static double CosecInverse(double angle, string status)
        {
            return CalculateTrigonometricValue(Math.Asin(1 / angle), status);
        }

        public static double SineHyp(double angle)
        {
            return Math.Sinh(angle);
        }

        public static double CosineHyp(double angle)
        {
            return Math.Cosh(angle);
        }

        public static double TangentHyp(double angle)
        {
            return Math.Tanh(angle);
        }

        public static double CosecHyp(double angle)
        {
            return 1 / Math.Sinh(angle);
        }

        public static double SecHyp(double angle)
        {
            return 1 / Math.Cosh(angle);
        }

        public static double CotHyp(double angle)
        {
            return 1 / Math.Tanh(angle);
        }

        public static double AbsoluteFunction(double input)
        {
            return Math.Abs(input);
        }

        public static double FloorFunction(double input)
        {
            return Math.Floor(input);
        }

        public static double inverse(double x)
        {
            return x != 0 ? 1 / x : 0;
        }

        public static double CeilingFunction(double input)
        {
            return Math.Ceiling(input);
        }

        public static double RandomFunction()
        {
            Random random = new Random();
            return random.NextDouble();
        }

        public static double ConvertDegreeToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public static double ConvertRadiansToDegree(double rad)
        {
            return (180 / Math.PI) * rad;
        }

        public static double ConvertGradientToDegree(double angle)
        {
            return (9 / 10.0) * angle;
        }

        public static double ConvertToDMS(double angle)
        {
            int degrees = (int)Math.Floor(angle);
            double minutes = (angle - degrees) * 60;
            int minutesInt = (int)Math.Floor(minutes);
            double seconds = (minutes - minutesInt) * 60;

            double result = degrees + minutesInt / 100.0 + seconds / 10000.0;

            return result;
        }

        public static double Exponentiation(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }

        public static double Root(double baseValue, double rootValue)
        {
            return Math.Pow(baseValue, 1.0 / rootValue);
        }

        public static double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid input");
            }

            return Math.Sqrt(number);
        }

        public static double CubeRoot(double number)
        {
            if (number < 0)
            {
                return -Math.Pow(-number, 1.0 / 3.0);
            }
            else
            {
                return Math.Pow(number, 1.0 / 3.0);
            }

        }

        public static double Log(double x, double baseValue)
        {
            return Math.Log(x) / Math.Log(baseValue);
        }

        public static double Ln(double x)
        {
            return Math.Log(x);
        }

        public static double ePowerx(double x)
        {
            return Math.Exp(x);
        }


        public static double Factorial(double n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Invalid input");
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
        public static string ConvertToScientificNotation(double number)
        {
            return string.Format("{0:0.#####e+0}", number);
        }
    }
}
