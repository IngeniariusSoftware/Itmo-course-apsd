namespace Substring_search
{
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        private static long GetPow(long number, long pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                long result = number;
                for (int i = 1; i < pow; i++)
                {
                    result = (result * number) % long.MaxValue;
                }

                return result;
            }
        }

        private static long GetHash(string str)
        {
            long firstHash = 0, lengthAlphabet = 53;
            for (int i = 0; i < str.Length; i++)
            {
                firstHash = ((GetPow(lengthAlphabet, str.Length - i - 1) * (str[i] - 65)) + firstHash) % long.MaxValue;
            }

            return firstHash;
        }

        private static long[] GetHashArray(int subStrLength, string str)
        {
            long[] hashArray = new long[str.Length + 1 - subStrLength];
            long lengthAlphabet = 53;
            for (int i = 0; i < subStrLength; i++)
            {
                hashArray[0] = ((GetPow(lengthAlphabet, subStrLength - i - 1) * (str[i] - 65)) + hashArray[0])
                               % long.MaxValue;
            }

            for (int i = 1; i < hashArray.Length; i++)
            {
                hashArray[i] =
                    ((hashArray[i - 1] * lengthAlphabet) - ((str[i - 1] - 65) * GetPow(lengthAlphabet, subStrLength))
                     + (str[subStrLength + i - 1] - 65)) % long.MaxValue;
            }

            return hashArray;
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string subStr = input.ReadLine();
            string goalStr = input.ReadLine();
            input.Close();
            var listPositions = new List<int>();
            if (subStr.Length <= goalStr.Length)
            {
                long subStrHash = GetHash(subStr);
                long[] hashArray = GetHashArray(subStr.Length, goalStr);
                for (int i = 0; i <= goalStr.Length - subStr.Length; i++)
                {
                    if (hashArray[i] == subStrHash)
                    {
                        bool isCorrect = true;
                        for (int j = 0; j < subStr.Length && isCorrect; j++)
                        {
                            if (goalStr[j + i] != subStr[j])
                            {
                                isCorrect = false;
                            }
                        }

                        if (isCorrect)
                        {
                            listPositions.Add(i + 1);
                        }
                    }
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(listPositions.Count);
            foreach (int position in listPositions)
            {
                output.Write(position + " ");
            }

            output.Close();
        }
    }
}