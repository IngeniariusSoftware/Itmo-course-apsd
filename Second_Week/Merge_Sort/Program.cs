namespace SortMerge
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        public static int inver = 0;

        public static StreamWriter output = new StreamWriter("output.txt");

        static List<int> Merge(List<int> list, int leftBoard, int rightBoard)
        {
            if (rightBoard == leftBoard)
            {
                return list.GetRange(leftBoard, 1);
            }
            else
            {
                List<int> sortArray = new List<int>();
                int i = 0, j = 0, middleRight = (int)Math.Ceiling((double)(rightBoard + leftBoard) / 2);
                List<int> leftList = Merge(list, leftBoard, middleRight - 1);
                List<int> rightList = Merge(list, middleRight, rightBoard);
                while (i < leftList.Count || j < rightList.Count)
                {
                    if (i == leftList.Count || j < rightList.Count && leftList[i] > rightList[j])
                    {
                        sortArray.Add(rightList[j]);
                        j++;
                    }
                    else
                    {
                        sortArray.Add(leftList[i]);
                        i++;
                    }
                }

                output.WriteLine(
                    "{0} {1} {2} {3}",
                    leftBoard + 1,
                    rightBoard + 1,
                    sortArray.First(),
                    sortArray.Last());
                return sortArray;
            }
        }

        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("input.txt");
            input.ReadLine();
            List<int> list = new List<int>();
            foreach (var token in input.ReadLine().Split(' '))
            {
                list.Add(int.Parse(token));
            }

            input.Close();
            foreach (int number in Merge(list, 0, list.Count - 1))
            {
                output.Write("{0} ", number);
            }

            output.WriteLine(inver);
            output.Close();
        }
    }
}
