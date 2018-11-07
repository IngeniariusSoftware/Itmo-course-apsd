namespace Polish_record
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            long[] stack = new long[length];
            int currentLength = -1;
            foreach (string element in input.ReadLine().Split(' '))
            {
                switch (element)
                {
                    case "+":
                        {
                            stack[currentLength - 1] = stack[currentLength - 1] + stack[currentLength];
                            --currentLength;
                            break;
                        }

                    case "-":
                        {
                            stack[currentLength - 1] = stack[currentLength - 1] - stack[currentLength];
                            --currentLength;
                            break;
                        }
                    
                    case "*":
                        {
                            stack[currentLength - 1] = stack[currentLength - 1] * stack[currentLength];
                            --currentLength;
                            break;
                        }

                    default:
                        {
                            ++currentLength;
                            stack[currentLength] = long.Parse(element);
                            break;
                        }
                }
            }

            input.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(stack[0]);
            output.Close();
        }
    }
}
