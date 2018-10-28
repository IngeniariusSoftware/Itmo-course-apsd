namespace Non_decreasing_binary_heap
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            int[] heap = new int[length];

            int index = 0;
            foreach (string strNumber in input.ReadLine().Split(' '))
            {
                heap[index] = int.Parse(strNumber);
                ++index;
            }

            input.Close();

            bool isNonDecreasing = true;
            for (int i = 0; i < length && isNonDecreasing; i++)
            {
                if (((i * 2) + 1 < length && heap[(i * 2) + 1] < heap[i]) || ((i * 2) + 2 < length && heap[(i * 2) + 2] < heap[i]))
                {
                    isNonDecreasing = false;
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            if (isNonDecreasing)
            {
                output.WriteLine("YES");
            }
            else
            {
                output.WriteLine("NO");
            }

            output.Close();
        }
    }
}
