using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic;
using Power;

namespace Scientific_Calculator
{
    internal class Program
    {
        Arithms keymp = new Arithms();
        static string Var1 = "degree";
        static string Var2 = "E-F";
        static double memory = 0;
        static string Memorycheck = "M";

        public static void Main(string[] args)
        {

            Console.SetCursorPosition(0, 10);
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"{Var1}  |  {Var2} ");

            StringBuilder inputExpression = new StringBuilder("0");
            StringBuilder number = new StringBuilder();

            ConsoleKeyInfo keyInfo;
            char inputChar;
            double currentNumber = 0;
            double result = 0;

            char op = '+';
            Console.Write(currentNumber);
            bool IsValidInputKey(char input)
            {
                char[] allowedKeys = { 'Q', 'M', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '+',
                    '-', '*', '/', '=', 'S', 's', 'C', 'c', 'T', 't', ')', 'L', 'O', '=','Q','#','q','Z','z'
                    ,'b','f','i','A','e','p','E','F','B','d','r','J','G','g','h','H','k','K','l','m','n'};

                return Array.IndexOf(allowedKeys, input) != -1;
            }
            static void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            static void ClearConsoleExceptFirstTwoLine()
            {
                Console.SetCursorPosition(0, 1);
                int currentLineCursor = Console.CursorTop;
                for (int i = 1; i <= currentLineCursor + 3; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                Console.SetCursorPosition(0, 2);
            }

            static void ClearStatusLine(String status)
            {
                int originalLeft = Console.CursorLeft;
                int originalTop = Console.CursorTop;
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"{Var1} | {Var2}");
                Console.SetCursorPosition(originalLeft, originalTop);
            }

            static double CalculateTrigonometricValue(double angle, string inputUnit)
            {
                double angleRad;

                switch (inputUnit)
                {

                    case "degree":
                        angleRad = Math.PI * angle / 180.0;
                        break;
                    case "rad":
                        angleRad = angle;
                        break;
                    case "gradian":
                        angleRad = Math.PI * angle * 0.9 / 180.0;
                        break;
                    default:
                        throw new ArgumentException("Invalid unit. Supported units are 'radian', 'degree', and 'gradian'.");
                }
                return angleRad;
            }
            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Delete)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {

                    if (number.Length > 0)
                    {
                        number.Length -= 1;
                        Console.Write("\b \b");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.E && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    Var2 = "F-E";
                    ClearStatusLine(Var2);
                }
                else if (keyInfo.Key == ConsoleKey.F && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    Var2 = "!F-E";
                    ClearStatusLine(Var2);
                }

                else if (keyInfo.Key == ConsoleKey.Q && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    Var1 = "radian";
                    ClearStatusLine(Var1);

                }
                else if (keyInfo.Key == ConsoleKey.P && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    Var1 = "degree";
                    ClearStatusLine(Var1);

                }
                else if (keyInfo.Key == ConsoleKey.R && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    Var1 = "gradian";
                    ClearStatusLine(Var1);
                }

                else if (keyInfo.Key == ConsoleKey.M && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    inputExpression.Clear();
                    Console.Clear();
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.Z && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    inputExpression.Clear();
                    number.Clear();
                    currentNumber = 0;
                    ClearConsoleExceptFirstTwoLine();

                }
                else if (keyInfo.Key == ConsoleKey.W && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    Console.SetCursorPosition(13, 0);
                    memory += currentNumber;
                    Console.WriteLine($" ||   {Memorycheck}");
                }
                if (keyInfo.Key == ConsoleKey.L && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    Memorycheck = "";
                    ClearStatusLine(Memorycheck);
                    memory = 0;
                    ClearConsoleExceptFirstTwoLine();
                    Console.WriteLine("there is nothing saved in your memory");




                }

                else if (IsValidInputKey(keyInfo.KeyChar))
                {

                    inputChar = keyInfo.KeyChar;

                    if (IsOperatorKey(inputChar))
                    {

                        inputExpression.Append(number.ToString());
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Clear();
                            inputExpression.Append(currentNumber).Append(inputChar);
                            Console.Write(inputExpression);
                            Console.Write($"\n{currentNumber}");
                            op = inputChar;
                        }
                        else if (inputExpression.Length != 0 && IsOperatorKey(inputExpression[inputExpression.Length - 1]))
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Remove(inputExpression.Length - 1, 1);
                            inputExpression.Append(inputChar);
                            Console.Write(inputExpression);
                            op = inputChar;
                            Console.Write($"\n{currentNumber}");
                            number.Clear();
                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Append(inputChar);
                            Console.Write(inputExpression);
                            Arithmetic.Arithms.PerformOperation(ref currentNumber, number.ToString(), op, Var2);
                            op = inputChar;
                            number.Clear();
                        }

                    }


                    else if (char.IsDigit(inputChar) || inputChar == '.')
                    {
                        if (number.Length == 0)
                        {
                            ClearCurrentConsoleLine();
                        }
                        if (inputExpression.Length > 0 && inputExpression[0] == '0')
                        {
                            inputExpression.Clear();
                        }
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Clear();
                            inputExpression.Clear();
                            currentNumber = 0;
                            op = '+';
                        }

                        number.Append(inputChar);
                        Console.Write(inputChar);

                        result = Convert.ToDouble(number.ToString());

                    }

                    else if (inputChar == '=')
                    {
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            continue;
                        }
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append(number.ToString()).Append('=');
                        Console.Write(inputExpression);
                        Arithmetic.Arithms.PerformOperation(ref currentNumber, number.ToString(), op, Var2);
                        number.Clear();
                    }

                    switch (inputChar)
                    {
                        case 's':
                        case 'c':
                        case 't':
                        case 'L':
                        case 'O':
                        case 'S':
                        case 'C':
                        case 'T':
                        case 'Q':
                        case '#':
                        case 'q':
                        case 'Z':
                        case 'z':
                        case 'b':
                        case 'f':
                        case 'i':
                        case 'A':
                        case 'e':
                        case 'E':
                        case 'p':
                        case 'F':
                        case 'B':
                        case 'd':
                        case 'r':
                        case 'g':
                        case 'G':
                        case 'h':
                        case 'H':
                        case 'k':
                        case 'K':
                        case 'l':
                        case 'm':
                        case 'n':
                            IsTrigonometricFunctionKey(inputChar);
                            break;
                        default:
                            break;
                    }


                }
            } while (true);

            bool IsOperatorKey(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/' || c == ')';
            }
            void IsTrigonometricFunctionKey(char c)
            {
                switch (c)
                {
                    case 's':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sin(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Sine(CalculateTrigonometricValue(result, Var1));
                        break;

                    case 'c':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cos(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cosine(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 't':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tan(" + number).Append(")");
                        Console.Write(inputExpression);

                        currentNumber = PowerOperations.Tangent(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'S':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sin^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);

                        currentNumber = PowerOperations.SineInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'C':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cos^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosineInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'T':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tan^(-1)(" + number).Append(")"); ;
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.TangentInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'g':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cosec(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cosec(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'G':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cosec^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosecInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'h':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Sec(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Sec(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'H':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Sec^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SecInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'k':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cot(" + number).Append(")"); ;
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cot(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'K':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cot^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CotInverse(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'l':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sinh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SineHyp(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'm':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cosh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosineHyp(CalculateTrigonometricValue(result, Var1));
                        break;
                    case 'n':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tanh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.TangentHyp(CalculateTrigonometricValue(result, Var1));
                        break;

                    case 'L':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Log" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Log(result, 10);
                        break;
                    case 'O':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Ln" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Ln(result);
                        break;

                    case 'Q':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sqr(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponent(result, 2);
                        break;
                    case '#':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cube(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponent(result, 3);
                        break;
                    case 'q':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "√(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SquareRoot(result);
                        break;
                    case 'Z':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cuberoot(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CubeRoot(result);
                        break;
                    case 'z':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "10^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponent(10, result);
                        break;
                    case 'b':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "2^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponent(2, result);
                        break;
                    case 'f':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "fact(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Factorial(result);
                        break;
                    case 'i':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "1/(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.inverse(result);
                        break;
                    case 'A':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "abs(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.AbsoluteFunction(result);
                        break;
                    case 'E':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "e^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.ePowerx(result);
                        break;
                    case 'e':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("2.7182818284590452353602874713527");
                        currentNumber = 2.7182818284590452353602874713527;
                        break;
                    case 'p':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("3.1415926535897932384626433832795");
                        currentNumber = 3.1415926535897932384626433832795;
                        break;
                    case 'r':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append(PowerOperations.RandomFunction().ToString());
                        currentNumber = PowerOperations.RandomFunction();
                        break;
                    case 'F':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "floor(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.FloorFunction(result);
                        break;
                    case 'B':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "ceil(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CeilingFunction(result);
                        break;


                    case 'd':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "dms(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.ConvertToDMS(result);
                        break;

                }
                Console.Write($"\n{currentNumber}");
                result = currentNumber;

                number.Clear();
            }

        }




    }

}
