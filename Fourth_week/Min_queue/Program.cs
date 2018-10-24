namespace Queue
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string[] inputQueue = File.ReadAllLines("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            Stack<(int, int)> stack1 = new Stack<(int, int)>(inputQueue.Length);
            Stack<(int, int)> stack2 = new Stack<(int, int)>(inputQueue.Length);
            int newElement;
            for (int i = 1; i < inputQueue.Length; i++)
            {
                switch (inputQueue[i][0])
                {
                    case '+':
                        {
                            newElement = int.Parse(inputQueue[i].Substring(2));
                            if (stack1.Count == 0 || stack1.Peek().Item2 >= newElement)
                            {
                                stack1.Push((newElement, newElement));
                            }
                            else
                            {
                                stack1.Push((newElement, stack1.Peek().Item2));
                            }

                            break;
                        }

                    case '-':
                        {
                            if (stack2.Count == 0)
                            {
                                while (stack1.Count > 0)
                                {
                                    newElement = stack1.Pop().Item1;
                                    if (stack2.Count == 0 || stack2.Peek().Item2 >= newElement)
                                    {
                                        stack2.Push((newElement, newElement));
                                    }
                                    else
                                    {
                                        stack2.Push((newElement, stack2.Peek().Item2));
                                    }
                                }
                            }

                            stack2.Pop();
                            break;
                        }

                    case '?':
                        {
                            if (stack1.Count == 0 || stack2.Count == 0)
                            {
                                output.WriteLine(stack1.Count == 0 ? stack2.Peek().Item2 : stack1.Peek().Item2);
                            }
                            else
                            {
                                output.WriteLine(Math.Min(stack1.Peek().Item2, stack2.Peek().Item2));
                            }

                            break;
                        }
                }
            }

            output.Close();
        }
    }
}
