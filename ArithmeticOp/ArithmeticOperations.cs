using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Arithms
    {

        public static string ScientificNotation(double number, string inputformat)
        {
            if (inputformat == "F-E")

                return string.Format("{0:0.#####e+0}", number);
            return number.ToString();

        }



        private static bool IsNumeric(char x)
        {
            if (x >= 48 && x <= 57)
                return true;
            return false;

        }

        private static bool IsOperator(char x)
        {
            return x == '+' || x == '-' || x == '*' || x == '/' || x == '^';
        }
        private static double Calculate(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                case '^': return Math.Pow(a, b);
                default:
                    // Console.WriteLine("Invalid operator");
                    return 0;
            }
        }

        private static double AdditionAndSubstraction(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                default:
                    Console.WriteLine("Invalid operator");
                    return 0;
            }
        }

        public static double Bodmas(String s, String Notation)
        {

            double result = 0;
            double result1 = 0;
            //  Console.Write("Enter the equation: ");
            // string equation = Console.ReadLine();
            start(s);
            //  Console.WriteLine("Result: " + result);
            Console.Write($"\n{ScientificNotation(result, Notation)}");
            return result;

            void start(string equation)
            {
                char op1 = '+';
                int length = equation.Length;
                for (int index = 0; index < equation.Length; index++)
                {
                    double currentNumber1 = 0;
                    /* while (index < length && IsNumeric(equation[index]))
                     {
                         currentNumber1 = currentNumber1 * 10 + (equation[index] - '0');
                         index++;
                     }*/

                    bool decimalPointEncountered = false;
                    double decimalMultiplier = 0.1;

                    while (index < length && (IsNumeric(equation[index]) || (!decimalPointEncountered && equation[index] == '.')))
                    {
                        if (equation[index] == '.')
                        {
                            decimalPointEncountered = true;
                            index++;
                            continue;
                        }

                        if (!decimalPointEncountered)
                        {
                            currentNumber1 = currentNumber1 * 10 + (equation[index] - '0');
                        }
                        else
                        {

                            currentNumber1 = currentNumber1 + (equation[index] - '0') * decimalMultiplier;
                            decimalMultiplier *= 0.1;
                        }

                        index++;
                    }






                    bool againMultiply = false;
                    bool Multiply = false;



                    while (index < length && (equation[index] == '/' || equation[index] == '*' || equation[index] == '^'))
                    {
                        Multiply = true;
                        bool NegativeCurrentNumber2 = false;
                        if (againMultiply)
                        {
                            currentNumber1 = result1;
                        }

                        double currentNumber2 = 0;
                        char op2 = equation[index];
                        index++;
                        if (equation[index] == '-')
                        {
                            NegativeCurrentNumber2 = true;
                            index++;
                        }

                        /* while (index < length && IsNumeric(equation[index]))
                         {
                             currentNumber2 = currentNumber2 * 10 + (equation[index] - '0');
                             if (NegativeCurrentNumber2)
                                 currentNumber2 = -currentNumber2;
                             index++;
                             againMultiply = true;
                         }*/
                        bool decimalPointEncountered1 = false;
                        double decimalMultiplier1 = 0.1;

                        while (index < length && (IsNumeric(equation[index]) || (!decimalPointEncountered1 && equation[index] == '.')))
                        {
                            if (equation[index] == '.')
                            {
                                decimalPointEncountered1 = true;
                                index++;
                                continue;
                            }

                            if (!decimalPointEncountered1)
                            {
                                currentNumber2 = currentNumber2 * 10 + (equation[index] - '0');
                            }
                            else
                            {

                                currentNumber2 = currentNumber2 + (equation[index] - '0') * decimalMultiplier1;
                                decimalMultiplier *= 0.1;
                            }

                            index++;
                        }




                        if (index < length && equation[index] == '^')
                        {
                            while (index < length && equation[index] == '^')
                            {

                                int power = equation[index + 1] - 48;

                                currentNumber2 = Math.Pow(currentNumber2, power);
                                result1 = Calculate(currentNumber1, currentNumber2, op2);
                                index = index + 2;
                            }
                        }

                        else if (index == length || (index < length && equation[index] != '^'))
                        {
                            result1 = Calculate(currentNumber1, currentNumber2, op2);
                        }

                    }

                    result = Calculate(result, result1, op1);
                    result1 = 0;

                    if ((index < length && (equation[index] == '+' || equation[index] == '-') && !Multiply) || (index == length && !Multiply))
                    {
                        result = Calculate(result, currentNumber1, op1);
                        if (index != length)
                        {
                            op1 = equation[index];
                        }
                    }

                    if (index != length)
                    {
                        op1 = equation[index];
                    }

                }
            }

        }




        static int Precedence(char operate)
        {
            if (operate == '+' || operate == '-')
                return 1;
            else if (operate == '*' || operate == '/')
                return 2;
            else if (operate == '^')
                return 3;
            return 0;
        }

        static bool IsOperand(char x)
        {
            return x >= '0' && x <= '9';
        }

        static bool IsOperators(char x)
        {
            return x == '+' || x == '-' || x == '*' || x == '/' || x == '^';
        }

        static double PerformOperation(double a, double b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Cannot divide by zero");
                        return 0;
                    }
                    else
                    {
                        return a / b;
                    }
                case '^':
                    return (double)Math.Pow(a, b);
                default:
                    Console.WriteLine("Invalid operator");
                    return 0;
            }
        }

        public static double Evaluate(string expression, string Notation)
        {
            int length = expression.Length;
            double result = 0;
            double[] values = new double[length];
            int resultIndex = 0;
            char[] operators = new char[length];
            int operatorIndex = 0;
            char firstOperator = ' ';
            bool firstOperatorCome = false;
            int index = 0;

            while (index < length)
            {
                if (IsOperand(expression[index]))
                {
                    double thisNumber = 0;

                    //while (index < length && IsOperand(expression[index]))
                    //{
                    //    thisNumber = thisNumber * 10 + (expression[index] - '0');
                    //    index++;
                    //}
                    bool decimalPointEncountered = false;
                    double decimalMultiplier = 0.1;

                    while (index < length && (IsOperand(expression[index]) || (!decimalPointEncountered && expression[index] == '.')))
                    {
                        if (expression[index] == '.')
                        {
                            decimalPointEncountered = true;
                            index++;
                            continue;
                        }

                        if (!decimalPointEncountered)
                        {
                            thisNumber = thisNumber * 10 + (expression[index] - '0');
                        }
                        else
                        {

                            thisNumber = thisNumber + (expression[index] - '0') * decimalMultiplier;
                            decimalMultiplier *= 0.1;
                        }

                        index++;
                    }


                    if (firstOperatorCome)
                    {
                        if (firstOperator == '-')
                        {
                            thisNumber = 0 - thisNumber;
                            firstOperatorCome = false;
                        }
                    }
                    values[resultIndex++] = thisNumber;
                    index--;
                }
                else if (expression[index] == '(')
                {

                    if (expression[index] != 0 && IsOperand(expression[index - 1]))
                    {
                        operators[operatorIndex++] = '*';
                    }




                    operators[operatorIndex++] = '(';
                }
                else if (expression[index] == ')')
                {
                    while (operatorIndex > 0 && operators[operatorIndex - 1] != '(')
                    {
                        double number1 = values[--resultIndex];
                        double number2 = values[--resultIndex];
                        char op = operators[--operatorIndex];

                        double resultTemp = PerformOperation(number2, number1, op);

                        values[resultIndex++] = resultTemp;
                    }
                    operatorIndex--; // Pop '('
                    if ((index < expression.Length - 1) && (IsOperand(expression[index + 1]) || expression[index + 1] == ' '))
                    {
                        operators[operatorIndex++] = '*';
                    }
                }
                else if (IsOperator(expression[index]))
                {
                    while (operatorIndex > 0 && Precedence(operators[operatorIndex - 1]) >= Precedence(expression[index]))
                    {
                        double number1 = values[--resultIndex];
                        double number2 = values[--resultIndex];
                        char op = operators[--operatorIndex];

                        double resultTemp = PerformOperation(number2, number1, op);

                        values[resultIndex++] = resultTemp;
                    }
                    if (index == 0 && (expression[index] == '+' || expression[index] == '-'))
                    {
                        firstOperator = expression[index];
                        firstOperatorCome = true;
                    }
                    else
                    {
                        operators[operatorIndex++] = expression[index];
                    }
                }
                index++;
            }

            while (operatorIndex > 0)
            {
                double number1 = values[--resultIndex];
                double number2 = values[--resultIndex];
                char op = operators[--operatorIndex];
                double resultTemp = PerformOperation(number2, number1, op);
                values[resultIndex++] = resultTemp;
            }
            result = values[0];

            Console.Write($"\n{ScientificNotation(result, Notation)}");
            return result;
        }


    }
}
