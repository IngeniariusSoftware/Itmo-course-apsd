namespace Third_week
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            input.ReadLine();
            string[] tokens = input.ReadLine().Split(' ');
            List<int> firstList = new List<int>();
            //foreach (string token in tokens)
            //{
            //    firstList.Add(int.Parse(token));
            //}

            for (int i = 0; i < 300; i++)
            {
                firstList.Add(i);
            }

            tokens = input.ReadLine().Split(' ');
            List<int> secondList = new List<int>();
            //foreach (string token in tokens)
            //{
            //    secondList.Add(int.Parse(token));
            //}

            for (int i = 0; i < 300; i++)
            {
                secondList.Add(i);
            }

            input.Close();
            firstList.Sort();
            secondList.Sort();
            int[] pointers = new int[secondList.Count];

            bool end = false;
            int queue = 1;
            long sum = 0;
            while (!end)
            {
                int max = 0;
                for (int i = 1; i < firstList.Count; i++)
                {
                    if (pointers[max] == secondList.Count
                        || (pointers[max] < secondList.Count && pointers[i] < secondList.Count
                                                             && firstList[i] * secondList[pointers[i]]
                                                             < firstList[max] * secondList[pointers[max]]))
                    {
                        max = i;
                    }
                }

                if (pointers[max] == secondList.Count)
                {
                    end = true;
                }
                else
                {
                    if (queue % 10 == 1)
                    {
                        sum += firstList[max] * secondList[pointers[max]];
                    }

                    pointers[max]++;
                    queue++;
                }
            }

            Console.WriteLine(timer.Elapsed);
            output.WriteLine(sum);
            output.Close();
        }
    }
}

