namespace Prefix
{
    using System.IO;

    class Program
    {
        private static int[] BuildPrefix(string str)
        {
            int[] prefixes = new int[str.Length];
            int i = 1, j = 0;
            while (i < str.Length)
            {
                if (str[i] == str[j])
                {
                    prefixes[i] = j + 1;
                    ++i;
                    ++j;
                }
                else
                {
                    if (j > 0)
                    {
                        j = prefixes[j - 1];
                    }
                    else
                    {
                        prefixes[i] = 0;
                        ++i;
                    }
                }
            }

            return prefixes;
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int[] prefixes = BuildPrefix(input.ReadLine());
            input.Close();
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = 0; i < prefixes.Length; i++)
            {
                output.Write(prefixes[i] + " ");
            }

            output.Close();
        }
    }
}
