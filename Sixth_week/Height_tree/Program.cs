namespace Height_tree
{
    using System;
    using System.IO;
    using System.Threading;

    class Program
    {
        private static int[] nodes;

        private static StreamWriter output = new StreamWriter("output.txt");

        private static void BigStackMain()
        {
            output.WriteLine(Height_tree(0));
            output.Close();
        }

        private static int Height_tree(int numberNode)
        {
            int leftHeight = 0, rightHeight = 0;
            if (nodes[numberNode * 2] != 0)
            {
                leftHeight = Height_tree(nodes[numberNode * 2] - 1);
            }

            if (nodes[numberNode * 2 + 1] != 0)
            {
                rightHeight = Height_tree(nodes[numberNode * 2 + 1] - 1);
            }
            
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            if (length > 0)
            {
                nodes = new int[length * 2];
                string[] tokens;
                for (int i = 0; i < length; i++)
                {
                    tokens = input.ReadLine().Split(' ');
                    nodes[i * 2] = int.Parse(tokens[1]);
                    nodes[i * 2 + 1] = int.Parse(tokens[2]);
                }

                Thread newThread = new Thread(BigStackMain, 100000000);
                newThread.Start();
            }
            else
            {
                output.WriteLine(0);
                output.Close();
            }
        }
    }
}
