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
            for (int i = 0; i < 26; i++)
            {
                letterPositions[i] = new List<int>();
            }

            for (int i = 0; i < map.Length; i++)
            {
                letterPositions[map[i] - 97].Add(i);
            }

            StreamWriter output = new StreamWriter("output.txt");

            long allCombinations = 0;
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < letterPositions[i].Count; j++)
                {
                    long combinations = 0;
                    for (int k = j + 1; k < letterPositions[i].Count; k++)
                    {
                        combinations += letterPositions[i][k] - letterPositions[i][j] - 1;
                    }

                    allCombinations += combinations;
                    output.WriteLine((char)(97 + i) + ": " + combinations);
                }

            }

            output.WriteLine(allCombinations);
            output.Close();
        }
    }
}

