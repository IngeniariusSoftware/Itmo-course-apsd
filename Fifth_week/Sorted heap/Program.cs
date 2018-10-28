namespace Sorted_heap
{
    using System.IO;

    class Program
    {
        private static string[] input;

        private static int[] _heap;

        private static int _leftBoard, _rightBoard = -1;

        private static int BinarySearch(int searchElement)
        {
            int bufLeftBoard = _leftBoard;
            int bufRightBoard = _rightBoard;
            while (bufLeftBoard < bufRightBoard)
            {
                int middleIndex = (bufLeftBoard + bufRightBoard) / 2;
                if (_heap[middleIndex] < searchElement)
                {
                    bufLeftBoard = middleIndex + 1;
                }
                else
                {
                    if (_heap[middleIndex] > searchElement)
                    {
                        bufRightBoard = middleIndex - 1;
                    }
                    else
                    {
                        return middleIndex;
                    }
                }
            }

            if (bufLeftBoard == bufRightBoard && _heap[bufLeftBoard] < searchElement)
            {
                return bufLeftBoard + 1;
            }
            else
            {
                return bufLeftBoard;
            }
        }

        private static string RemoveMin()
        {
            if (_leftBoard <= _rightBoard)
            {
                ++_leftBoard;
                return (_heap[_leftBoard - 1].ToString());
            }
            else
            {
                return "*";
            }
        }

        private static void AddElement(int element)
        {
            int newPosition = BinarySearch(element);
            ++_rightBoard;
            for (int i = _rightBoard; i > newPosition; i--)
            {
                _heap[i] = _heap[i - 1];
            }

            _heap[newPosition] = element;
        }

        private static void ReplaceElement(int lastValue, int newValue)
        {
            int oldPosition = BinarySearch(lastValue);
            int newPosition = BinarySearch(newValue);
            for (int i = oldPosition; i > newPosition; i--)
            {
                _heap[i] = _heap[i - 1];
            }

            _heap[newPosition] = newValue;
        }

        static void Main1()
        {
            input = File.ReadAllLines("input.txt");
            _heap = new int[input.Length];
            int[] currentValues = new int[input.Length];
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = 1; i < input.Length; i++)
            {
                switch (input[i][0])
                {
                    case 'A':
                        {
                            AddElement(int.Parse(input[i].Substring(1)));
                            currentValues[i] = int.Parse(input[i].Substring(1));
                            break;
                        }

                    case 'D':
                        {
                            string[] tokens = input[i].Split(' ');
                            ReplaceElement(currentValues[int.Parse(tokens[1])], int.Parse(tokens[2]));
                            currentValues[int.Parse(tokens[1])] = int.Parse(tokens[2]);
                            break;
                        }

                    case 'X':
                        {
                            output.WriteLine(RemoveMin());
                            break;
                        }
                }
            }

            output.Close();
        }
    }
}

