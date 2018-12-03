namespace FunctionZ
{
    using System.IO;

    class Program
    {
        private static int[] zFunction(string str)
        {
            int[] zValues = new int[str.Length];
            int rightBoard = 0, leftBoard = 0, j = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (i >= rightBoard)
                {
                    j = 0;
                    while (i + j < str.Length && str[i + j] == str[j])
                    {
                        j++;
                    }

                    leftBoard = i;
                    rightBoard = i + j;
                    zValues[i] = j;
                }
                else
                {
                    if (zValues[i - leftBoard] < rightBoard - i)
                    {
                        zValues[i] = zValues[i - leftBoard];
                    }
                    else
                    {
                        j = rightBoard - i;
                        while (i + j < str.Length && str[i + j] == str[j])
                        {
                            j++;
                        }

                        leftBoard = i;
                        rightBoard = i + j;
                        zValues[i] = j;
                    }
                }
            }


            return zValues;
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int[] zValues = zFunction(input.ReadLine());
            input.Close();
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = 1; i < zValues.Length; i++)
            {
                output.Write(zValues[i] + " ");
            }

            output.Close();
        }
    }
}
