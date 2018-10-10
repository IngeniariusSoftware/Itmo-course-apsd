namespace Digital_sorting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {

            Stopwatch timer =new Stopwatch();
            timer.Start();
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            Random rnd = new Random();

            

            //for (int i = 0; i < 6000; i++)
            //{
            //    for (int j = 0; j < 6000; j++)
            //    {
            //        if (j != 5999)
            //        {
            //        output.Write("{0} ", (char)rnd.Next(97, 122));
            //        }
            //        else
            //        {
            //            output.Write("{0}"(char)rnd.Next(97, 122));
            //        }
            //    }

            //    if (i != 5999)
            //    {
            //        output.WriteLine();
            //    }
            //}
            


            string[] tokens = input.ReadLine().Split(' ');
            int strLength = int.Parse(tokens[1]);
            int maxSteps = int.Parse(tokens[2]);
            int[] positions = new int[strLength];
            int[] countNumbers = new int[26];
            for (int y = 0; y < maxSteps; y++)
            {
                countNumbers = new int[26];
                tokens = input.ReadLine().Split(' ');
                for (int x = 0; x < tokens.Length; x++)
                {
                    countNumbers[(byte)tokens[x][0] - 97]++;
                }

                for (int i = 1; i < countNumbers.Length; i++)
                {
                    countNumbers[i] += countNumbers[i - 1];
                }

                //for (int i = tokens.Length - 1; i > -1; i--)
                //{
                //    positions[countNumbers[(byte)tokens[i][0] - 97]] = i;
                //}
            }

            Console.WriteLine(timer.Elapsed);

            input.Close();
        }
    }
}
