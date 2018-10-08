namespace Sort_Scarecrow
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int radius = int.Parse(tokens[1]);
            List<int> list = new List<int>();
            foreach (var token in input.ReadLine().Split(' '))
            {
                list.Add(int.Parse(token));
            }

            List<int> sortedList = new List<int>(list.GetRange(0, list.Count));
            sortedList.Sort();
            List<int> noBusyIndex = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                noBusyIndex.Add(i);
            }

            SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();
            input.Close();
            bool isPosible = true;
            if (radius > 1)
            {
                for (int i = 0; i < list.Count && isPosible; i++)
                {
                    bool find = false;
                    int needIndex;
                    if (dictionary.ContainsKey(list[i]))
                    {
                        needIndex = dictionary[list[i]];
                    }
                    else
                    {
                        needIndex = sortedList.BinarySearch(list[i]);
                        dictionary.Add(list[i], needIndex);
                    }

                    while (needIndex > 0 && sortedList[needIndex - 1] == list[i])
                    {
                        needIndex--;
                    }

                    while (needIndex < list.Count && sortedList[needIndex] == list[i] && !find && isPosible)
                    {
                        if (needIndex % radius == i % radius)
                        {
                            if (noBusyIndex.BinarySearch(needIndex) > -1)
                            {
                                noBusyIndex.Remove(needIndex);
                                find = true;
                            }
                            else
                            {
                                needIndex += radius;
                            }
                        }

                        if (needIndex % radius != i % radius)
                        {
                            needIndex += Math.Abs(needIndex % radius - i % radius);
                        }
                    }

                    if (!find)
                    {
                        isPosible = false;
                    }
                }
            }

            if (isPosible)
            {
                output.Write("YES");
            }
            else
            {
                output.Write("NO");
            }

            output.Close();
        }
    }
}
