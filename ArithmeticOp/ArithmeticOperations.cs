using System;


namespace ArithmeticOp
{
    public class ArithmeticOperations : CalInterface
    {
        private int num1, num2;
        public int firstNum { get { return num1; } }
        public int secondNum { get { return num2; } }
        public ArithmeticOperations(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public int Result(string op)
        {
            switch (op)
            {
                case "+": return AddNum;

                case "-": return SubNum;

                case "*": return MulNum;

                case "/": return DivNum;

                case "%": return ModNum;

                default:
                    throw new NotImplementedException();

            }
        }

        public int AddNum { get { return firstNum + secondNum; } }
        public int SubNum { get { return firstNum - secondNum; } }

        public int MulNum { get { return firstNum * secondNum; } }

        public int DivNum { get { return firstNum / secondNum; } }

        public int ModNum { get { return firstNum % secondNum; } }

        //int CalInterface.num1 => throw new NotImplementedException();
    }
}