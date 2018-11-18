namespace Eighth_week
{
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            int length = int.Parse(input.ReadLine());
            Dictionary<string, int> positionDictionary = new Dictionary<string, int>(length);
            (string, int, int)[] valueArray = new (string, int, int)[length];
            int currentPostion = 0, lastPosition, nextPosition;
            StreamWriter output = new StreamWriter("output.txt");
            valueArray[0].Item2 = -1;
            for (int i = 1; i <= length; ++i)
            {
                string[] tokens = input.ReadLine().Split(' ');
                switch (tokens[0])
                {
                    case "get":
                        {
                            if (positionDictionary.ContainsKey(tokens[1]))
                            {
                                output.WriteLine(valueArray[positionDictionary[tokens[1]]].Item1);
                            }
                            else
                            {
                                output.WriteLine("<none>");
                            }

                            break;
                        }

                    case "prev":
                        {
                            if (positionDictionary.ContainsKey(tokens[1]))
                            {
                                if (valueArray[positionDictionary[tokens[1]]].Item2 >= 0)
                                {
                                    output.WriteLine(valueArray[valueArray[positionDictionary[tokens[1]]].Item2].Item1);
                                }
                                else
                                {
                                    output.WriteLine("<none>");
                                }
                            }
                            else
                            {
                                output.WriteLine("<none>");
                            }

                            break;
                        }

                    case "next":
                        {
                            if (positionDictionary.ContainsKey(tokens[1]))
                            {
                                if (valueArray[positionDictionary[tokens[1]]].Item3 < currentPostion)
                                {
                                    output.WriteLine(valueArray[valueArray[positionDictionary[tokens[1]]].Item3].Item1);
                                }
                                else
                                {
                                    output.WriteLine("<none>");
                                }
                            }
                            else
                            {
                                output.WriteLine("<none>");
                            }

                            break;
                        }

                    case "put":
                        {
                            if (positionDictionary.ContainsKey(tokens[1]))
                            {
                                valueArray[positionDictionary[tokens[1]]].Item1 = tokens[2];
                            }
                            else
                            {
                                positionDictionary[tokens[1]] = currentPostion;
                                valueArray[currentPostion].Item1 = tokens[2];
                                valueArray[currentPostion].Item3 = currentPostion + 1;
                                ++currentPostion;
                                valueArray[currentPostion].Item2 = currentPostion - 1;
                            }

                            break;
                        }

                    case "delete":
                        {
                            if (positionDictionary.ContainsKey(tokens[1]))
                            {
                                lastPosition = valueArray[positionDictionary[tokens[1]]].Item2;
                                nextPosition = valueArray[positionDictionary[tokens[1]]].Item3;
                                if (lastPosition >= 0)
                                {
                                    valueArray[lastPosition].Item3 = nextPosition;
                                }

                                if (nextPosition <= currentPostion)
                                {
                                    valueArray[nextPosition].Item2 = lastPosition;
                                }

                                positionDictionary.Remove(tokens[1]);
                            }

                            break;
                        }
                }
            }

            input.Close();
            output.Close();
        }
    }
}