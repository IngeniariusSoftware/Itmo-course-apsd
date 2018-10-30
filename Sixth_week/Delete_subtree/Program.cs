namespace Delete_subtree
{
    using System.IO;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int[] nodes;
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
