namespace Map_parser
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string map = input.ReadLine().Replace(" ", "");
            input.Close();
            var letterPositions = new List<int>[26];
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] - 96 >= 0)
                {
                    letterPositions[map[i] - 96].Add(i);
                }
            }

            long combinations = 0;
            for (int i = 0; i < 26; i++)
            {
                combinations += 2;
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine();
            output.Close();
        }
    }
}

