namespace Hash_killer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static long Hash(string str, int coeff)
        {
            long hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash = hash * coeff + (int)str[i];
            }
            return hash;
        }

        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            for (int coeff = 2; coeff < 10; coeff++)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    output.Write(Hash(lines[i], coeff) + " ");
                }

                output.WriteLine();
            }

            output.Close();
        }
    }
}
