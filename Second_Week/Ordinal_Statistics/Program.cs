namespace Ordinal_Statistics
{
    using System.IO;
    using System.Collections.Generic;

    class Program
    {
        public static int LeftBoard, RightBoard;

        private static int Partition(ref List<int> list, int low, int high)
        {
            int middle = list[(low + high) / 2];
            int leftBoard = low - 1;
            int rightBoard = high + 1;
            while (true)
            {
                do
                {
                    leftBoard++;
                }
                while (list[leftBoard] < middle);

                do
                {
                    rightBoard--;
                }
                while (list[rightBoard] > middle);

                if (leftBoard >= rightBoard)
                    return rightBoard;

                int shelf = list[leftBoard];
                list[leftBoard] = list[rightBoard];
                list[rightBoard] = shelf;
            }
        }

        private static void QuickRecursive(ref List<int> list, int low, int high)
        {
            if (high - low >= 1)
            {
                int p = Partition(ref list, low, high);
                if (LeftBoard - 1 <= p && RightBoard - 1 >= low)
                {
                    QuickRecursive(ref list, low, p);
                }

                if (RightBoard - 1 >= p + 1 && LeftBoard - 1 <= high)
                {
                    QuickRecursive(ref list, p + 1, high);
                }
            }
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int length = int.Parse(tokens[0]);
            LeftBoard = int.Parse(tokens[1]);
            RightBoard = int.Parse(tokens[2]);
            tokens = input.ReadLine().Split(' ');
            int coefficientA = int.Parse(tokens[0]);
            int coefficientB = int.Parse(tokens[1]);
            int coefficientC = int.Parse(tokens[2]);
            List<int> list = new List<int>(length);
            list.Add(int.Parse(tokens[3]));
            list.Add(int.Parse(tokens[4]));
            for (int i = 2; i < length; i++)
            {
                list.Add(coefficientA * list[i - 2] + coefficientB * list[i - 1] + coefficientC);
            }

            input.Close();
            QuickRecursive(ref list, 0, list.Count - 1);
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = LeftBoard - 1; i < RightBoard; i++)
            {
                output.Write(list[i] + " ");
            }

            output.Close();
        }
    }
}
