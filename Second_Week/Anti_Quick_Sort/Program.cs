namespace Anti_Quick_Sort
{
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            int length = int.Parse(input.ReadLine());
            input.Close();
            List<int> list = new List<int> { 0, 1 };
            for (int i = 2; i < length; i++)
            {
                list.Add(i);
                int shelf = list[i];
                list[i] = list[i / 2];
                list[i / 2] = shelf;
            }

            for (int i = 0; i < length; i++)
            {
                output.Write("{0} ", list[i] + 1);
            }

            output.Close();
        }
    }
}
