using Arithmetic;
using Power;
using System;
using System.Text;

namespace Scientific_Calculator1
{
    internal class Program
    {
        static string varDeg = "DEG";
        static string varEF = "E-F";
        static string varExtra = "";

        public static void Main()
        {
            Console.SetCursorPosition(0, 10);


           // Keymapping();

            //keyMapping
           



            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            Console.WriteLine($"{varDeg} | {varEF} | {varExtra}");

            StringBuilder inputExpression = new StringBuilder();
            StringBuilder number = new StringBuilder("0");
            StringBuilder calculate = new StringBuilder();

            ConsoleKeyInfo keyInfo;
            char ch;
            double current = 0;
            double result = 0;
            bool restart = false;
            string memoryValue = string.Empty;
            // char op = '+';
            Console.Write(current);
            bool exOp = false;
            double number2 = 0;
            double number1 = 0;
            StringBuilder temp = new StringBuilder();
            char opCh = ' ';

            do
            {
                
                keyInfo = Console.ReadKey(true);

                ch = keyInfo.KeyChar;



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
                    /* if (temp.Length > 0 && exOp)
                     {
                         temp.Length -= 1;
                         Console.Write("\b \b");
                     }*/


                }
                else if (keyInfo.Key == ConsoleKey.E && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varEF = "F-E";
                    ClearStatusLine(varEF);
                }
                else if (keyInfo.Key == ConsoleKey.F && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varEF = "E-F";
                    ClearStatusLine(varEF);
                }

                else if (keyInfo.Key == ConsoleKey.P && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    varDeg = "radian";
                    ClearStatusLine(varDeg);

                }
                else if (keyInfo.Key == ConsoleKey.Q && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    varDeg = "DEG";
                    ClearStatusLine(varDeg);

                }
                else if (keyInfo.Key == ConsoleKey.R && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    varDeg = "gradian";
                    ClearStatusLine(varDeg);
                }

                else if (keyInfo.Key == ConsoleKey.A && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    inputExpression.Clear();
                    Console.Clear());;
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.Z && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    exOp = false;
                    temp.Clear();
                    number1 = 0;      ////
                    number2 = 0;



                    inputExpression.Clear();
                    number.Clear();
                    calculate.Clear();
                    current = 0;
                    ClearConsoleExceptFirstTwoLine();

                }
                else if (keyInfo.Key == ConsoleKey.M && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varExtra = "MS";
                    ClearStatusLine(varExtra);
                    memoryValue = result.ToString();

                }
                else if (keyInfo.Key == ConsoleKey.Y && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varExtra = "M+";
                    ClearStatusLine(varExtra);
                    if (memoryValue.Length == 0)
                    {
                        memoryValue = Convert.ToDouble(result.ToString()).ToString();
                    }
                    else
                    {
                        memoryValue = (Convert.ToDouble(memoryValue) + Convert.ToDouble(result.ToString())).ToString();
                    }

                }
                else if (keyInfo.Key == ConsoleKey.W && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varExtra = "M-";
                    ClearStatusLine(varExtra);
                    if (memoryValue.Length == 0)
                    {
                        memoryValue = Convert.ToDouble(result.ToString()).ToString();
                    }
                    else
                    {
                        memoryValue = (Convert.ToDouble(memoryValue) - Convert.ToDouble(result.ToString())).ToString();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.N && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varExtra = "MC";
                    ClearStatusLine(varExtra);
                    memoryValue = "";

                }
                else if (keyInfo.Key == ConsoleKey.B && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    varExtra = "MR";
                    ClearStatusLine(varExtra);
                    number.Append(memoryValue);
                    ClearCurrentConsoleLine();
                    Console.Write(memoryValue);
                }

                else if (ch == 'U' || ch == 'V' || ch == 'W' || ch == 'X')
                {

                    OtherFunction(ch);
                    opCh = ch;

                }

                else if (exOp && (char.IsDigit(ch) || ch == '.') && !IsOperatorKey(ch))
                {
                    if (number2 == 0)
                    {
                        number.Clear();
                    }

                    number1 = result;
                    if (number.Length == 0)
                    {
                        ClearCurrentConsoleLine();
                    }

                    number.Append(ch);

                    Console.Write(ch);
                    number2 = Convert.ToDouble(number.ToString());

                }
                else if (IsValidInputKey(keyInfo.KeyChar))
                {
                    /* if (exOp && (char.IsDigit(ch) || ch == '.') && !IsOperatorKey(ch))
                     {
                         number1 = result;
                         if (temp.Length == 0)
                         {
                             ClearCurrentConsoleLine();
                         }

                         temp.Append(ch);

                         Console.Write(ch);
                         number2 = Convert.ToDouble(temp.ToString());
                         //Calculation();
                     }*/

                    if (IsOperatorKey(ch) || IsBracket(ch))
                    {
                        if (exOp && number.Length != 0)      // check
                        {
                            temp.Append(number);
                            current = CallSpecialCalculation(opCh, number1, number2);
                            Console.Write($"\n{current}");
                            result = current;


                            restart = false;
                            if (current == 0)
                                calculate.Append(number).Append(ch);
                            else
                                calculate.Append(current).Append(ch);

                            inputExpression.Append(temp.ToString());
                            exOp = false;
                            temp.Clear();
                            number1 = 0;
                            number2 = 0;
                        }
                        else
                        {
                            exOp = false;
                            restart = false;
                            if (current == 0)
                                calculate.Append(number).Append(ch);
                            else
                                calculate.Append(current).Append(ch);

                            inputExpression.Append(number.ToString());
                        }



                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Remove(inputExpression.Length - 1, 1);
                            inputExpression.Append(ch);


                            Console.Write($"\n{current}");
                            calculate.Append(current).Append(ch);


                        }
                        else if (inputExpression.Length != 0 && IsOperatorKey(inputExpression[inputExpression.Length - 1]) && ch != '(' && ch != ')')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Remove(inputExpression.Length - 1, 1);
                            inputExpression.Append(ch);
                            calculate.Remove(inputExpression.Length - 2, 2);
                            calculate.Append(ch);
                            Console.Write(inputExpression);
                        }
                        else
                        {
                            inputExpression.Append(ch);
                            ClearConsoleExceptFirstTwoLine();
                            Console.WriteLine(inputExpression);
                            Console.Write(current);


                        }
                        number.Clear();
                        current = 0;
                    }


                    else if (char.IsDigit(ch) || ch == '.')
                    {
                        if (number.Length == 0)
                        {
                            ClearCurrentConsoleLine();
                        }

                        if (number.Length == 1 && number[0] == '0' && ch != '.')
                        {
                            number.Clear();
                            ClearCurrentConsoleLine();
                        }


                        if (restart)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Clear();
                            inputExpression.Clear();
                            calculate.Clear();
                            current = 0;
                            restart = false;

                        }

                        number.Append(ch);
                        Console.Write(ch);

                        result = Convert.ToDouble(number.ToString());

                    }

                    else if (ch == '=' && exOp)
                    {
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            continue;
                        }

                        temp.Append(number);


                        current = CallSpecialCalculation(opCh, number1, number2);
                        calculate.Append(current);
                        if (calculate.Length >= 1 && IsOperatorKey(calculate[calculate.Length - 1]))       // 2+2=^2=416
                        {
                            current = Arithms.Evaluate(calculate.ToString(), varEF);
                        }

                        Console.Write($"\n{current}");
                        result = current;



                        if (current == 0)
                            calculate.Append(number).Append(ch);
                        else
                            calculate.Append(current).Append(ch);

                        inputExpression.Append(temp.ToString()).Append(ch);

                        ClearConsoleExceptFirstTwoLine();
                        Console.WriteLine(inputExpression);
                        Console.Write(current);
                        result = current;
                        restart = true;
                        calculate.Clear();
                        calculate.Append(result);
                        number.Clear();
                        inputExpression.Clear();
                        inputExpression.Append(result);
                        exOp = false;
                        temp.Clear();
                        number1 = 0;
                        number2 = 0;
                        current = 0;

                    }


                    else if (ch == '=' && !exOp)
                    {

                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            continue;
                        }

                        if (current == 0)
                            calculate.Append(number).Append(ch);
                        else
                            calculate.Append(current).Append(ch);
                        inputExpression.Append(number.ToString()).Append(ch);
                        ClearConsoleExceptFirstTwoLine();


                        Console.Write(inputExpression);

                        result = Arithms.Evaluate(calculate.ToString(), varEF);
                        restart = true;
                        calculate.Clear();
                        calculate.Append(result);
                        number.Clear();
                        inputExpression.Clear();
                        inputExpression.Append(result);
                    }

                    else if (ch == 's' || ch == 'c' || ch == 't' || ch == 'L' || ch == 'O'
                        || ch == 'S' || ch == 'C' || ch == 'T' || ch == 'Q' || ch == '#' || ch == 'q' ||
                        ch == 'Z' || ch == 'z' || ch == 'b' || ch == 'f' || ch == 'i' || ch == 'A' ||
                        ch == 'e' || ch == 'E' || ch == 'p' || ch == 'F' || ch == 'B' || ch == 'd' || ch == 'r'
                        || ch == 'g' || ch == 'G' || ch == 'h' || ch == 'H' || ch == 'k' || ch == 'K' || ch == 'l'
                        || ch == 'm' || ch == 'n' || ch == 'u' || ch == 'v' || ch == 'w' || ch == 'y')
                    {
                        if (restart)
                        {
                            number.Append(result.ToString());
                            inputExpression.Clear();
                            restart = false;
                        }

                        IsTrigonometricFunctionKey(ch);
                    }

                }
            } while (true);

            bool IsValidInputKey(char input)
            {
                char[] allowedKeys = { 'Q', 'M', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '+',
                    '-', '*', '/', '=', 'S', 's', 'C', 'c', 'T', 't', ')', 'L', 'O', '=','Q','#','q','Z','z'
                    ,'b','f','i','A','e','p','E','F','B','d','r','J','G','g','h','H','k','K','l','m','n','^','(',')','u','v','w','y','U','V','W','X'};

                return Array.IndexOf(allowedKeys, input) != -1;
            }

            bool IsOperatorKey(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
            }
            bool IsBracket(char c)
            {
                return c == ')' || c == '(';
            }
            void IsTrigonometricFunctionKey(char c)
            {
                StringBuilder s = inputExpression;

                switch (c)
                {
                    case 's':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "sin(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = Math.Round(PowerOperations.Sine(CalculateTrigonometricValue(result, varDeg)),10);
                        break;
                   

                    case 'c':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "cos(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Cosine(CalculateTrigonometricValue(result, varDeg));
                        break;
                    case 't':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "tan(").Append(")");
                        Console.Write(s.ToString() + number.ToString());

                        if (result==90 && varDeg== "DEG") {
                            Console.WriteLine(" \n Invalid");
                            Thread.Sleep(1000);
                            exOp = false;
                            temp.Clear();
                            number1 = 0;      ////
                            number2 = 0;



                            inputExpression.Clear();
                            number.Clear();
                            calculate.Clear();
                            current = 0;
                            ClearConsoleExceptFirstTwoLine();
                        }
                        else
                        {
                            current = Math.Round(PowerOperations.Tangent(CalculateTrigonometricValue(result, varDeg)),10);

                        }
                        break;
                    case 'S':
                        if (result < -1 || result > 1)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "Sin^(-1)(").Append(")");
                            Console.WriteLine(s.ToString() + number.ToString());
                            Console.Write("Invalid input");

                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "Sin^(-1)(").Append(")");
                            Console.Write(s.ToString() + number.ToString());
                            current = PowerOperations.SineInverse(result, varDeg);
                        }
                        break;

                    case 'C':
                        if (result < -1 || result > 1)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            Console.Write(s.ToString() + number.ToString());
                            number.Insert(0, "cos^(-1)(").Append(")");
                            Console.Write("Invalid input");
                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "cos^(-1)(").Append(")");
                            Console.Write(s.ToString() + number.ToString());
                            current = PowerOperations.CosineInverse(result, varDeg);
                        }

                        break;
                    case 'T':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Tan^(-1)(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.TangentInverse(result, varDeg);
                        break;
                    case 'g':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cosec(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Cosec(CalculateTrigonometricValue(result, varDeg));
                        break;
                    case 'G':
                        if (result > -1 && result < 1)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "cosec^(-1)(").Append(")");
                            Console.Write("Invalid input");
                        }
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cosec^(-1)(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CosecInverse(result, varDeg);
                        break;
                    case 'h':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Sec(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Sec(CalculateTrigonometricValue(result, varDeg));
                        break;
                    case 'H':
                        if (result > -1 && result < 1)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "sec^(-1)(").Append(")");
                            Console.Write("Invalid input");
                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "Sec^(-1)(").Append(")");
                            Console.Write(s.ToString() + number.ToString());
                            current = PowerOperations.SecInverse(result, varDeg);
                        }

                        break;
                    case 'k':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cot(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Cot(CalculateTrigonometricValue(result, varDeg));
                        break;
                    case 'K':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cot^(-1)(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CotInverse(result, varDeg);
                        break;
                    case 'l':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Sinh(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.SineHyp(result);
                        break;
                    case 'm':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cosh(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CosineHyp(result);
                        break;
                    case 'n':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "tanh(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.TangentHyp(result);
                        break;
                    case 'u':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Cosech(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CosecHyp(result);
                        break;
                    case 'v':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Sech(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.SecHyp(result);
                        break;
                    case 'w':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "Coth(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CotHyp(result);
                        break;




                    case 'L':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "log(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Log(result, 10);
                        break;
                    case 'O':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "ln(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Ln(result);
                        break;

                    case 'Q':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "sqr(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Exponentiation(result, 2);
                        break;
                    case '#':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "cube(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Exponentiation(result, 3);
                        break;
                    case 'q':
                        if (number[0] == '-')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "√(").Append(")");
                            Console.WriteLine(s.ToString() + number.ToString());
                            Console.Write("invalid input");
                            break;
                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "√(").Append(")");
                            Console.Write(s.ToString() + number.ToString());
                            current = PowerOperations.SquareRoot(result);
                            break;
                        }

                    case 'Z':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "cuberoot(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CubeRoot(result);
                        break;
                    case 'z':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "10^(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Exponentiation(10, result);
                        break;
                    case 'b':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "2^(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.Exponentiation(2, result);
                        break;
                    case 'f':
                        if (result >= 0)
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Insert(0, "fact(").Append(")");
                            Console.Write(s.ToString() + number.ToString());


                            current = PowerOperations.Factorial(result);

                        }
                        else
                        {
                            Console.WriteLine(" \n Cannot find factorial of -ve number");
                            Thread.Sleep(1000);
                            exOp = false;
                            temp.Clear();
                            number1 = 0;      ////
                            number2 = 0;



                            inputExpression.Clear();
                            number.Clear();
                            calculate.Clear();
                            current = 0;
                            ClearConsoleExceptFirstTwoLine();

                        }
                        break;
                    case 'i':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "1/(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.inverse(result);
                        break;
                    case 'A':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "abs(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.AbsoluteFunction(result);
                        break;
                    case 'E':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "e^(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.ePowerx(result);
                        break;
                    case 'e':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("2.7182818284590452353602874713527");
                        current = 2.7182818284590452353602874713527;
                        break;
                    case 'p':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("3.1415926535897932384626433832795");
                        current = 3.1415926535897932384626433832795;
                        break;
                    case 'r':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append(PowerOperations.RandomFunction().ToString());
                        current = PowerOperations.RandomFunction();
                        break;
                    case 'F':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "floor(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.FloorFunction(result);
                        break;
                    case 'B':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "ceil(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.CeilingFunction(result);
                        break;


                    case 'd':
                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "dms(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = PowerOperations.ConvertToDMS(result);
                        break;

                    case 'y':

                        ClearConsoleExceptFirstTwoLine();
                        number.Insert(0, "negate(").Append(")");
                        Console.Write(s.ToString() + number.ToString());
                        current = -result;
                        break;



                }
                Console.Write($"\n{current}");
                //  Console.Write(inputExpression);
                // number.Clear();
                result = current;
                //  number= current;

            }

            void OtherFunction(char ch)
            {
                switch (ch)
                {
                    case 'U':
                        exOp = true;
                        ClearConsoleExceptFirstTwoLine();
                        number1 = result;
                        temp.Append(number).Append("^");
                        Console.Write(inputExpression.ToString() + temp.ToString());
                        break;
                    case 'V':
                        exOp = true;
                        ClearConsoleExceptFirstTwoLine();
                        number1 = result;
                        temp.Append(number).Append("MOD");
                        Console.Write(inputExpression.ToString() + temp.ToString());
                        break;
                    case 'W':
                        exOp = true;
                        ClearConsoleExceptFirstTwoLine();
                        number1 = result;
                        temp.Append(number).Append("log base");
                        Console.Write(inputExpression.ToString() + temp.ToString());
                        break;
                    case 'X':
                        exOp = true;
                        ClearConsoleExceptFirstTwoLine();
                        number1 = result;
                        temp.Append(number).Append("Yroot");
                        Console.Write(inputExpression.ToString() + temp.ToString());
                        break;

                }
                Console.Write($"\n{current}");

                // result = current;

            }


            double CallSpecialCalculation(char ch, double num1, double num2)
            {
                double output = 0;
                switch (ch)
                {

                    case 'U':
                        output = Math.Pow(num1, num2);
                        break;
                    case 'V':
                        output = num1 % num2;
                        break;
                    case 'W':
                        output = PowerOperations.Log(num1, num2);
                        break;
                    case 'X':
                        output = PowerOperations.Root(num1, num2);
                        break;

                }
                return output;
            }


        }


        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void ClearConsoleExceptFirstTwoLine()
        {
            Console.SetCursorPosition(0, 2); // Move cursor to the beginning of the second line
            int currentLineCursor = Console.CursorTop;
            for (int i = 2; i <= currentLineCursor + 3; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth)); // Clear each line from the second line onward
            }
            Console.SetCursorPosition(0, 2); // Move cursor back to the beginning of the second line
        }

        public static void ClearStatusLine(String status)
        {
            int originalLeft = Console.CursorLeft;
            int originalTop = Console.CursorTop;
            Console.SetCursorPosition(0, 1);

            // Clear the line and write new content
            Console.Write(new string(' ', Console.WindowWidth - 1)); // Clear the line
            Console.SetCursorPosition(0, Console.CursorTop); // Move back to the beginning of the line
            Console.Write($"{varDeg} | {varEF} | {varExtra}");
            // Restore the original cursor position
            Console.SetCursorPosition(originalLeft, originalTop);
        }


        public static double CalculateTrigonometricValue(double angle, string inputUnit)
        {
            double angleRad;

            switch (inputUnit)
            {
                case "radian":
                    angleRad = angle;
                    break;
                case "DEG":
                    angleRad = Math.PI * angle / 180.0;
                    break;
                case "gradian":
                    angleRad = Math.PI * angle * 0.9 / 180.0;
                    break;
                default:
                    throw new ArgumentException("Invalid unit. Supported units are 'radian', 'DEG', and 'gradian'.");
            }
            return angleRad;
        }

        public static void KeyMapping()
        {
            KeyMapping1("Radian   -  ctrl+P", "DEG    -  ctrl+Q", "Gradian   - ctrl+R   M+    - ctrl+Y     MR      -  ctrl+B  ", 12);
            KeyMapping1("F-E      -  ctrl+E", "E-F       -  ctrl+F", "Exist     - ctrl+A   M-    - ctrl+W      Restart -  ctrl+Z   ", 13);
            KeyMapping1("MC       -  ctrl+N", "MS        -  ctrl+M", " Negate    -    y", 14);
            KeyMapping1("Sin -  s", "Sin^(-1) -  S  Sinh -  l", " Cosec -  g   Cosec^(-1) -  G  Cosech  -  u", 17);
            KeyMapping1("Cos -  c", "Cos^(-1) -  C  Cosh -  m", " Sec   -  h  Sec^(-1)   -  H  Sech   -  v", 18);
            KeyMapping1("tan -  t", "tan^(-1) -  T  tanh -  n", " Cot   -  k  Cot^(-1)   -  K  Coth   -  w", 19);
            KeyMapping1("Pie   -  p", "Random    -  r", "e   - e", 21);
            KeyMapping1("Log   -    L", "ln        -   O", "YlogX  -   W ", 22);
            KeyMapping1("X^Y   -  U", "MOD        -    V", "x√Y     -      X", 24);
            KeyMapping1("Square      -  Q", "Cube    -  #", "SquareRoot - q", 25);
            KeyMapping1("CubeRoot    -  Z", "10^x    -  z", "2^x        - b", 26);
            KeyMapping1("Factorial   -  f", "1/X     -  i", "Absolute   - A", 27);
            KeyMapping1("e^x         -  E", "floor   -  F", "Ceil       - B", 28);
            KeyMapping1("dms         -  d", "  ", "  ", 29);
        }

        private static void KeyMapping1(string c1, string c2, string c3, int row)
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