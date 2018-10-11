namespace Digital_sorting
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int strLength = int.Parse(tokens[0]), strCount = int.Parse(tokens[1]), maxSteps = int.Parse(tokens[2]);

            if ((double)(strLength / strCount) <= 50)
            {
                #region Сортировка подсчетом

                int[] positions = new int[strLength * 2];
                int[] countNumbers = new int[26 * maxSteps];
                char[][] letters = new char[maxSteps][];
                for (int i = 0; i < strLength; i++)
                {
                    positions[i] = i;
                }

                for (int y = 0; y < strCount - maxSteps; y++)
                {
                    input.ReadLine();
                }

                for (int y = 0; y < maxSteps; y++)
                {
                    letters[y] = input.ReadLine().ToCharArray();
                }

                for (int y = 0; y < maxSteps; y++)
                {

                    for (int x = 0; x < strLength; x++)
                    {
                        countNumbers[(byte)letters[maxSteps - 1 - y][positions[x + strLength * (y % 2)]] - 97
                                     + 26 * y]++;
                    }

                    for (int i = 1; i < 26; i++)
                    {
                        countNumbers[i + 26 * y] += countNumbers[i - 1 + 26 * y];
                    }

                    for (int x = strLength - 1; x > -1; x--)
                    {
                        positions[countNumbers[(byte)letters[maxSteps - 1 - y][positions[x + strLength * (y % 2)]] - 97
                                               + 26 * y] - 1 + strLength * ((y + 1) % 2)] =
                            positions[x + strLength * (y % 2)];
                        countNumbers[(byte)letters[maxSteps - 1 - y][positions[x + strLength * (y % 2)]] - 97
                                     + 26 * y]--;
                    }
                }

                input.Close();

                for (int i = 0; i < strLength; i++)
                {
                    output.Write("{0} ", positions[i + ((maxSteps) % 2 * strLength)] + 1);
                }

                #endregion
            }
            else
            {
                (string, int)[] strings = new (string, int) [strLength];
                for (int y = 0; y < strCount - maxSteps; y++)
                {
                    input.ReadLine();
                }

                char[][] letters = new char[maxSteps][];
                for (int y = 0; y < maxSteps; y++)
                {
                    char[] charArray = input.ReadLine().ToCharArray();
                    for (int i = 0; i < strLength; i++)
                    {
                        strings[i].Item1 = strings[i].Item1 + charArray[i];
                    }
                }

                for (int i = 0; i < strLength; i++)
                {
                    strings[i].Item2 = i;
                }

                Array.Sort(strings);

                for (int i = 0; i < strLength; i++)
                {
                    output.Write("{0} ", strings[i].Item2 + 1);
                }
            }

            output.Close();
        }
    }
}
