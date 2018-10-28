namespace Binary_search
{
    using System.IO;

    class Program
    {
        private static (int, int) BinarySearch(int element, int leftBoard, int rightBoard, int[] array)
        {
            while (leftBoard < rightBoard)
            {
                int middleIndex = (leftBoard + rightBoard) / 2;
                if (array[middleIndex] < element)
                {
                    leftBoard = middleIndex + 1;
                }
                else
                {
                    if (array[middleIndex] > element)
                    {
                        rightBoard = middleIndex - 1;
                    }
                    else
                    {
                        // Двоичный поиск границ, либо запоминаем позиции (лучше все и сразу)
                        int firstPosition = middleIndex, lastPosition = middleIndex;
                        while (firstPosition > 0 && array[firstPosition - 1] == array[middleIndex])
                        {
                            --firstPosition;
                        }

                        while (lastPosition < rightBoard && array[lastPosition + 1] == array[middleIndex])
                        {
                            ++lastPosition;
                        }

                        return (firstPosition + 1, lastPosition + 1);
                    }
                }
            }

            if (array[leftBoard] == element)
            {
                return (leftBoard + 1, leftBoard + 1);
            }
            else
            {
                return (-1, -1);
            }
        }

        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            int[] array = new int[length];
            int index = 0;
            foreach (string element in input.ReadLine().Split(' '))
            {
                array[index] = int.Parse(element);
                index++;
            }

            input.ReadLine();
            StreamWriter output = new StreamWriter("output.txt");

            foreach (string searchElement in input.ReadLine().Split(' '))
            {
                (int, int) result = BinarySearch(int.Parse(searchElement), 0, length - 1, array);
                output.WriteLine(result.Item1 + " " + result.Item2);
            }

            input.Close();
            output.Close();
        }
    }
}
