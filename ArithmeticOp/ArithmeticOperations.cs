using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Arithms
    {

        private static readonly Dictionary<char, Func<double, double, double>> Operations = new Dictionary<char, Func<double, double, double>>
        {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b },
            { '*', (a, b) => a * b },
            { '/', (a, b) => b != 0 ? a / b : throw new DivideByZeroException("Error: Division by zero.") }
         };

        public static void PerformOperation(ref double currentNumber, string inputExpression, char operatorKey, string Notation)
        {
            if (!string.IsNullOrEmpty(inputExpression) && Operations.ContainsKey(operatorKey))
            {
                double operand = Convert.ToDouble(inputExpression);
                try
                {
                    currentNumber = Operations[operatorKey].Invoke(currentNumber, operand);
                    Console.Write($"\n{ScientificNotation(currentNumber, Notation)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"\n{ex.Message}");
                }
            }
            else
            {
                Console.Write($"\nError: Invalid operator '{operatorKey}'.");
            }
        }

        public static string ScientificNotation(double number, string inputformat)
        {
            if (inputformat == "F-E")
            {
                return string.Format("{0:0.#####e+0}", number);
            }
            return number.ToString();
        }

        public static void KeyMapping()
        {

            KeyMapping1("Radian   -  ctrl+P", "Degree    -  ctrl+Q", "Gradian   - ctrl+R", 12);
            KeyMapping1("F-E      -  ctrl+E", "!F-E      -  ctrl+F", "Exist     - ctrl+M", 13);

            KeyMapping1("Sin   -  s", "Sin^(-1)   -  S", "Sinh -  l", 15);
            KeyMapping1("Cos   -  c", "Cos^(-1)   -  C", "Cosh -  m", 16);
            KeyMapping1("tan   -  t", "tan^(-1)   -  T", "tanh -  n", 17);
            KeyMapping1("Cosec -  g", "Cosec^(-1) -  G", " ", 18);
            KeyMapping1("Sec   -  h", "Sec^(-1)   -  H", " ", 19);
            KeyMapping1("Cot   -  k", "Cot^(-1)   -  K", " ", 20);
            KeyMapping1("Log   -  L", "ln  - O", " ", 22);
            KeyMapping1("Square      -  Q", "Cube    -  #", "SquareRoot - q", 23);
            KeyMapping1("CubeRoot    -  Z", "10^x    -  z", "2^x        - b", 24);
            KeyMapping1("Factorial   -  f", "1/X     -  i", "Absolute   - A", 25);
            KeyMapping1("e^x         -  E", "floor   -  F", "Ceil       - B", 26);
            KeyMapping1("dms         -  d", "  ", "  ", 27);
            KeyMapping1("Pie   -  p", "Random    -  r", "e   - e", 29);


        }
        public static void KeyMapping1(string c1, string c2, string c3, int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write($"{c1}");
            Console.SetCursorPosition(30, row);
            Console.Write($"{c2}");
            Console.SetCursorPosition(60, row);
            Console.Write($"{c3}");

        }

    }
}
