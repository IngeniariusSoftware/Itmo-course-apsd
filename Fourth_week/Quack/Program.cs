namespace Quack
{
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string[] inputQueue = File.ReadAllLines("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            bool isEnd = false;
            long[] registers = new long[26];
            Dictionary<string, int> labels = new Dictionary<string, int>();
            long[] bufQueue = new long[10000000];
            int queueLength = 0;
            int queuePosition = 0;
            for (int i = 0; i < inputQueue.Length; i++)
            {
                if (inputQueue[i][0] == ':')
                {
                    labels.Add(inputQueue[i].Substring(1), i);
                }
            }
            
            for (int i = 0; i < inputQueue.Length && !isEnd; i++)
            {
                switch (inputQueue[i][0])
                {
                    case '+':
                        {
                            bufQueue[queueLength] = (bufQueue[queuePosition] + bufQueue[queuePosition + 1]) & 65535;
                            queuePosition += 2;
                            ++queueLength;
                            break;
                        }

                    case '-':
                        {
                            bufQueue[queueLength] = (bufQueue[queuePosition] - bufQueue[queuePosition + 1]) & 65535;
                            queuePosition += 2;
                            ++queueLength;
                            break;
                        }

                    case '/':
                        {
                            if (bufQueue[queuePosition + 1] != 0)
                            {
                                bufQueue[queueLength] = bufQueue[queuePosition] / bufQueue[queuePosition + 1] & 65535;
                            }
                            else
                            {
                                bufQueue[queueLength] = 0;
                            }

                            queuePosition += 2;
                            ++queueLength;
                            break;
                        }

                    case '%':
                        {
                            if (bufQueue[queuePosition + 1] != 0)
                            {
                                bufQueue[queueLength] = bufQueue[queuePosition] % bufQueue[queuePosition + 1] & 65535;
                            }
                            else
                            {
                                bufQueue[queueLength] = 0;
                            }

                            queuePosition += 2;
                            ++queueLength;
                            break;
                        }

                    case '*':
                        {
                            bufQueue[queueLength] = (bufQueue[queuePosition] * bufQueue[queuePosition + 1]) & 65535;
                            queuePosition += 2;
                            ++queueLength;
                            break;
                        }

                    case ':':
                        {
                            break;
                        }

                    case '>':
                        {
                            registers[inputQueue[i][1] - 97] = bufQueue[queuePosition];
                            ++queuePosition;
                            break;
                        }

                    case '<':
                        {
                            bufQueue[queueLength] = registers[inputQueue[i][1] - 97];
                            ++queueLength;
                            break;
                        }

                    case 'J':
                        {
                            i = labels[inputQueue[i].Substring(1)];
                            break;
                        }

                    case 'C':
                        {
                            if (inputQueue[i].Length > 1)
                            {
                                char symbol = (char)(registers[inputQueue[i][1] - 97] % 256);
                                if (symbol == 10)
                                {
                                    output.WriteLine();
                                }
                                else
                                {
                                    output.Write(symbol);
                                }
                            }
                            else
                            {
                                char symbol = (char)(bufQueue[queuePosition] % 256);
                                if (symbol == 10)
                                {
                                    output.WriteLine();
                                }
                                else
                                {
                                    output.Write(symbol);
                                }
                                ++queuePosition;
                            }

                            break;
                        }

                    case 'Z':
                        {
                            if (registers[inputQueue[i][1] - 97] == 0)
                            {
                                i = labels[inputQueue[i].Substring(2)];
                            }

                            break;
                        }

                    case 'E':
                        {
                            if (registers[inputQueue[i][1] - 97] == registers[inputQueue[i][2] - 97])
                            {
                                i = labels[inputQueue[i].Substring(3)];
                            }

                            break;
                        }

                    case 'P':
                        {
                            if (inputQueue[i].Length > 1)
                            {
                                output.WriteLine(registers[inputQueue[i][1] - 97]);
                            }
                            else
                            {
                                output.WriteLine(bufQueue[queuePosition]);
                                ++queuePosition;
                            }

                            break;
                        }

                    case 'G':
                        {
                            if (registers[inputQueue[i][1] - 97] > registers[inputQueue[i][2] - 97])
                            {
                                i = labels[inputQueue[i].Substring(3)];
                            }

                            break;
                        }

                    case 'Q':
                        {
                            isEnd = true;
                            break;
                        }

                    default:
                        {
                            bufQueue[queueLength] = int.Parse(inputQueue[i]);
                            queueLength++;
                            break;
                        }
                }
            }

            output.Close();
        }
    }
}
