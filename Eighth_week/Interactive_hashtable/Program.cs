namespace Interactive_hashtable
{
    using System.IO;

    class Program
    {
        private static long[] HashArray;

        public static bool ContainsKey(long number)
        {
            bool find = false;
            int hash = (int)(number % HashArray.Length);
            while (HashArray[hash] != -1 && !find)
            {
                if (HashArray[hash] == number)
                {
                    find = true;
                }

                hash++;
                hash %= HashArray.Length;
            }

            if (find)
            {
                return true;
            }
            else
            {
                HashArray[hash] = number;
                return false;
            }
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int length = int.Parse(tokens[0]);
            long number = long.Parse(tokens[1]);
            long coefficientA = long.Parse(tokens[2]);
            long coefficientB = long.Parse(tokens[3]);
            tokens = input.ReadLine().Split(' ');
            input.Close();
            long coefficientAc = long.Parse(tokens[0]);
            long coefficientBc = long.Parse(tokens[1]);
            long coefficientAd = long.Parse(tokens[2]);
            long coefficientBd = long.Parse(tokens[3]);

            HashArray = new long[9895657];
            for (int i = 0; i < length; i++)
            {
                HashArray[i] = -1;
            }

            for (int i = 0; i < length; ++i)
            {
                if (ContainsKey(number))
                {
                    coefficientA = (coefficientA + coefficientAc) % 1000;
                    coefficientB = (coefficientB + coefficientBc) % 1000000000000000;
                }
                else
                {
                    coefficientA = (coefficientA + coefficientAd) % 1000;
                    coefficientB = (coefficientB + coefficientBd) % 1000000000000000;
                }

                number = ((number * coefficientA) + coefficientB) % 1000000000000000;
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(number + " " + coefficientA + " " + coefficientB);
            output.Close();
        }
    }
}
