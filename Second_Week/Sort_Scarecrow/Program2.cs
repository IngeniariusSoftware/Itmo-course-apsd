namespace week2
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Class1
    {
        public static StreamWriter output = new StreamWriter("output.txt");

        public static long Inv = 0;

        public static void StartProgram()
        {
            var input = new StreamReader("input.txt");
            var s = input.ReadLine();
            var k = Int32.Parse(s.Split(' ')[1]);
            var n = Int32.Parse(s.Split(' ')[0]);

            List<int> list = new List<int>();
            foreach (var token in input.ReadLine().Split(' '))
            {
                list.Add(int.Parse(token));
            }

            Prg(k, list.ToArray(), n);

            output.Close();
        }


        static bool Check(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1]) return false;
            }

            return true;

        }

        public static void Prg(int k, int[] arr, int n)
        {

            for (int i = 0; i < k; ++i)
            {
                List<int> tmp = new List<int>();
                for (int j = i; j < n; j += k)
                    tmp.Add(arr[j]);
                tmp.Sort();
                for (int j = i, curPos = 0; j < n; j += k)
                    arr[j] = tmp[curPos++];
            }

            output.WriteLine(Check(arr) ? "YES" : "NO");
        }
    }
}