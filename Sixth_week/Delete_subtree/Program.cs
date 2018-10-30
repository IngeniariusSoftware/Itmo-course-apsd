namespace Delete_subtree
{
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        private static (int, int, int, bool)[] _nodes;

        private static Dictionary<int, int> _positionsIndicator;

        private static int FindElement(int element)
        {
            if (_positionsIndicator.ContainsKey(element))
            {
                return _positionsIndicator[element];
            }
            else
            {
                return -1;
            }
        }

        private static void DeleteNodeValue(int value)
        {
            int index = FindElement(value);
            if (index != -1)
            {
                DeleteNodeIndex(_nodes[index].Item2 - 1);
                DeleteNodeIndex(_nodes[index].Item3 - 1);
                _nodes[index].Item4 = false;
                _positionsIndicator.Remove(value);
            }
        }

        private static void DeleteNodeIndex(int index)
        {
            if (index != -1 && _nodes[index].Item4)
            {
                DeleteNodeIndex(_nodes[index].Item2 - 1);
                DeleteNodeIndex(_nodes[index].Item3 - 1);
                _nodes[index].Item4 = false;
                _positionsIndicator.Remove(_nodes[index].Item1);
            }
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            _nodes = new (int, int, int, bool)[length];
            _positionsIndicator = new Dictionary<int, int>(length);
            string[] tokens;
            for (int i = 0; i < length; i++)
            {
                tokens = input.ReadLine().Split(' ');
                _positionsIndicator[int.Parse(tokens[0])] = i;
                _nodes[i] = (int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]), true);
            }

            input.ReadLine();
            StreamWriter output = new StreamWriter("output.txt");
            foreach (string value in input.ReadLine().Split(' '))
            {
                DeleteNodeValue(int.Parse(value));
                output.WriteLine(_positionsIndicator.Count);
            }

            input.Close();
            output.Close();
        }
    }
}
