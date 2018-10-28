namespace Sorted_heap
{
    using System.IO;

    class Program2
    {
        private static string[] input;

        private static (int, int)[] _heap;

        private static int[] _currentPositions;

        private static int _rightBoard = -1;

        private static void CheckHeap(int index)
        {
            int min;
            if (index * 2 + 1 <= _rightBoard && _heap[index * 2 + 1].Item1 < _heap[index].Item1)
            {
                min = index * 2 + 1;
            }
            else
            {
                min = index;
            }

            if (index * 2 + 2 <= _rightBoard && _heap[index * 2 + 2].Item1 < _heap[min].Item1)
            {
                min = index * 2 + 2;
            }

            if (min != index)
            {
                ( int, int) shelf = _heap[min];
                _currentPositions[_heap[min].Item2] = index;
                _currentPositions[_heap[index].Item2] = min;
                _heap[min] = _heap[index];
                _heap[index] = shelf;
                CheckHeap(min);
            }
        }

        private static string RemoveMin()
        {
            if (_rightBoard > -1)
            {
                int shelf = _heap[0].Item1;
                _heap[0] = _heap[_rightBoard];
                _currentPositions[_heap[0].Item2] = 0;
                --_rightBoard;
                CheckHeap(0);
                return (shelf.ToString());
            }
            else
            {
                return "*";
            }
        }

        private static void AddElement((int, int) element)
        {
            int index = ++_rightBoard;
            _heap[index] = element;
            _currentPositions[element.Item2] = index;
            while (index > 0 && _heap[(index - 1) / 2].Item1 > _heap[index].Item1)
            {
                (int, int) shelf = _heap[(index - 1) / 2];
                _currentPositions[_heap[index].Item2] = (index - 1) / 2;
                _currentPositions[_heap[(index - 1) / 2].Item2] = index;
                _heap[(index - 1) / 2] = _heap[index];
                _heap[index] = shelf;
                index = (index - 1) / 2;
            }
        }

        private static void ReplaceElement(int index, int newValue)
        {
            _heap[index].Item1 = newValue;
            while (index > 0 && _heap[(index - 1) / 2].Item1 > _heap[index].Item1)
            {
                (int, int) shelf = _heap[(index - 1) / 2];
                _currentPositions[_heap[index].Item2] = (index - 1) / 2;
                _currentPositions[_heap[(index - 1) / 2].Item2] = index;
                _heap[(index - 1) / 2] = _heap[index];
                _heap[index] = shelf;
                index = (index - 1) / 2;
            }
        }

        static void Main()
        {
            input = File.ReadAllLines("input.txt");
            _heap = new (int, int)[input.Length];
            _currentPositions = new int[input.Length];
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = 1; i < input.Length; i++)
            {
                switch (input[i][0])
                {
                    case 'A':
                        {
                            AddElement((int.Parse(input[i].Substring(1)), i));
                            break;
                        }

                    case 'D':
                        {
                            string[] tokens = input[i].Split(' ');
                            ReplaceElement(_currentPositions[int.Parse(tokens[1])], int.Parse(tokens[2]));
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

