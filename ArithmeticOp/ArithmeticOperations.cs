using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Arithms
    {
        public static string ScientificNotation(double number, string inputFormat)
        {
            return inputFormat == "F-E" ? string.Format("{0:0.#####e+0}", number) : number.ToString();
        }

        private static bool IsNumeric(char x)
        {
            return x >= '0' && x <= '9';
        }

        private static double Calculate(double operand1, double operand2, char op)
        {
            return op switch
            {
                '+' => operand1 + operand2,
                '-' => operand1 - operand2,
                '*' => operand1 * operand2,
                '/' => operand1 / operand2,
                '^' => Math.Pow(operand1, operand2),
                _ => 0,
            };
        }

        private static double CalculatePower(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }

        public static double Bodmas(string equation, string notation)
        {
            double result = 0;

            char previousOperator = '+';
            int index = 0;
            int length = equation.Length;

            while (index < length)
            {
                double currentOperand = GetNextNumber(equation, ref index);

                bool isMultiplication = false;

                while (index < length && (equation[index] == '/' || equation[index] == '*' || equation[index] == '^'))
                {
                    isMultiplication = true;

                    char currentOperator = equation[index];
                    index++;

                    double nextOperand = GetNextNumber(equation, ref index);

                    if (currentOperator == '^')
                    {
                        nextOperand = CalculatePower(currentOperand, nextOperand);
                        result = Calculate(result, nextOperand, previousOperator);
                        currentOperand = 0;
                    }
                    else
                    {
                        double tempResult = Calculate(currentOperand, nextOperand, currentOperator);
                        result = Calculate(result, tempResult, previousOperator);
                        currentOperand = 0;
                    }
                }

                result = Calculate(result, currentOperand, previousOperator);

                if (index < length && (equation[index] == '+' || equation[index] == '-') && !isMultiplication)
                {
                    previousOperator = equation[index];
                }

                if (index != length)
                {
                    previousOperator = equation[index];
                }

                index++;
            }

            Console.Write($"\n{ScientificNotation(result, notation)}");
            return result;
        }

        private static double GetNextNumber(string equation, ref int index)
        {
            double currentNumber = 0;
            bool decimalPointEncountered = false;
            double decimalMultiplier = 0.1;

            while (index < equation.Length && (IsNumeric(equation[index]) || (!decimalPointEncountered && equation[index] == '.')))
            {
                if (equation[index] == '.')
                {
                    decimalPointEncountered = true;
                    index++;
                    continue;
                }

                if (!decimalPointEncountered)
                {
                    currentNumber = currentNumber * 10 + (equation[index] - '0');
                }
                else
                {
                    currentNumber += (equation[index] - '0') * decimalMultiplier;
                    decimalMultiplier *= 0.1;
                }

                index++;
            }

            return currentNumber;
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
                else if (IsOperators(expression[index]))
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
