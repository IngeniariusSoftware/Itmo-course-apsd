namespace Map_parser
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string map = input.ReadLine().Replace(" ", "");
            input.Close();
            var letterParameters = new (long, long)[26];
            long allCombinations = 0;
            for (int i = 0; i < map.Length; ++i)
            {
                if (letterParameters[map[i] - 97].Item1 != 0)
                {
                    allCombinations += (long)Math.Round(
                        letterParameters[map[i] - 97].Item1
                        * (i - ((double)letterParameters[map[i] - 97].Item2 / letterParameters[map[i] - 97].Item1)
                             - 1));
                }

                ++letterParameters[map[i] - 97].Item1;
                letterParameters[map[i] - 97].Item2 += i;
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(allCombinations);
            output.Close();
        }
    }
}
