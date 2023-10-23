
using ArithmeticOp;
using static System.Math;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace ScientificOp
{
    public class SciOperations : ArithmeticOperations

    {
        public SciOperations(int num1, int num2) : base(num1, num2) { }
        public double SquareRoot { get { return Sqrt(firstNum); } }

        public double CubeRoot { get { return Cbrt(firstNum); } }

        public double power { get { return Pow((double)firstNum, (double)secondNum); } }

        public double powerMinus { get { return Pow((double)firstNum, 1 / (double)secondNum); } }       
    }
}
