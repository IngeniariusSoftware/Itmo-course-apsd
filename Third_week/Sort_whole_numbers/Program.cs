namespace Third_week
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            input.ReadLine();
            string[] tokens = input.ReadLine().Split(' ');
            int[] firstArray = new int[tokens.Count()];
            for (int i = 0; i < tokens.Count(); i++)
            {
                firstArray[i] = int.Parse(tokens[i]);
            }

            tokens = input.ReadLine().Split(' ');
            int[] secondArray = new int[tokens.Count()];
            for (int i = 0; i < tokens.Count(); i++)
            {
                secondArray[i] = int.Parse(tokens[i]);
            }

            input.Close();
            int[] countNumbers = new int[24415];
            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    countNumbers[(firstArray[i] * secondArray[j]) >> 16]++;
                }
            }

            for (int i = 1; i < countNumbers.Length; i++)
            {
                countNumbers[i] += countNumbers[i - 1];
            }

            long[] finalArray = new long[firstArray.Length * secondArray.Length];
            
            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    finalArray[countNumbers[(firstArray[i] * secondArray[j]) >> 16] - 1] =
                        firstArray[i] * secondArray[j];
                    countNumbers[(firstArray[i] * secondArray[j]) >> 16]--;
                }
            }

            Array.Sort(finalArray);
            long sum = 0;
            for (int i = 0; i < finalArray.Length; i += 10)
            {
                sum += finalArray[i];
            }

            //long[][] finalArray = new long[countNumbers.Length][];
            //for (int i = 0; i < countNumbers.Length; i++)
            //{
            //    finalArray[i] = new long[countNumbers[i]];
            //}

            //for (int i = 0; i < firstArray.Length; i++)
            //{
            //    for (int j = 0; j < secondArray.Length; j++)
            //    {
            //        finalArray[(firstArray[i] * secondArray[j]) >> 16][
            //            countNumbers[(firstArray[i] * secondArray[j]) >> 16] - 1] = firstArray[i] * secondArray[j];
            //        countNumbers[(firstArray[i] * secondArray[j]) >> 16]--;
            //    }
            //}

            //for (int i = 0; i < finalArray.Length; i++)
            //{
            //    Array.Sort(finalArray[i]);
            //}

            //Console.WriteLine(timer.Elapsed);
            output.WriteLine(sum);
            output.Close();
        }
    }
}

