using ArithmeticOp;

namespace Application
{
    class Program  :ArithmeticOperations
    {
        public Program(int num1, int num2) : base(num1, num2)
        {

        }

        public static void MyTemplate<temp>(temp[] arr, int size)
        {
            for (int i = 1; i < size; i++)
            {
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Enter the value to insert in array");
                    try
                    {
                        arr[i] = (temp)Convert.ChangeType(Console.ReadLine(), typeof(temp));
                        check = false;


                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message + "Try Again");
                    }
                }

            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        static void Main1(string[] args)
        {
            bool isValidSize = false;
            int size = 0;
            while (!isValidSize)
            {
                try
                {
                    Console.WriteLine("Enter number of elements to be inserted in array");
                    size = Convert.ToInt32(Console.ReadLine());
                    isValidSize = true;
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int[] intArr = new int[size];
            bool[] boolArr = new bool[size];
            float[] floatArr = new float[size];

            Console.WriteLine("Enter the value to insert in array");

            String firstInput = Console.ReadLine();
            switch (firstInput)
            {
                case var s when int.TryParse(s, out int firstInt):
                    intArr[0] = firstInt;
                    Program.MyTemplate(intArr, size);
                    break;

                case var s when bool.TryParse(s, out bool firstBool):
                    boolArr[0] = firstBool;
                    Program.MyTemplate(boolArr, size);
                    break;

                case var s when float.TryParse(s, out float firstFloat):
                    floatArr[0] = firstFloat;
                    Program.MyTemplate(floatArr, size);
                    break;

                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }

        static void Main()
        {
            Program p = new Program(6,8);
            Console.WriteLine(p.Result("*"));

        }
    }

}
