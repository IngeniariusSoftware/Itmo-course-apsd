namespace Garland
{
    using System.IO;
    using System;
    using System.Globalization;

    class Program
    {
        private static double BuildGarland(int countNodes, double lastHeight, double currentHeight)
        {
            for (; 0 < countNodes && currentHeight >= 0; --countNodes)
            {
                double shelf = currentHeight;
                currentHeight = currentHeight - (lastHeight - currentHeight - 2);
                lastHeight = shelf;
            }

            return currentHeight;
        }

        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int countNodes = int.Parse(tokens[0]) - 2;
            double firstHeight = double.Parse(tokens[1], CultureInfo.InvariantCulture),
                   lastBestHeight = firstHeight,
                   currentBestHeight = 0,
                   deviation = 0.0000000001,
                   currentResult = 0,
                   lastResult = 0,
                   shelfHeight;

            input.Close();
            bool isFind = false;
            while (!isFind)
            {
                if (currentResult >= 0)
                {
                    lastResult = currentResult;
                }

                shelfHeight = currentBestHeight;
                if (currentResult <= 0)
                {
                    currentBestHeight += Math.Abs(lastBestHeight - currentBestHeight) / 2;
                    currentResult = BuildGarland(countNodes, firstHeight, currentBestHeight);
                }
                else
                {
                    currentBestHeight -= Math.Abs(lastBestHeight - currentBestHeight) / 2;
                    currentResult = BuildGarland(countNodes, firstHeight, currentBestHeight);
                }

                lastBestHeight = shelfHeight;
                if (Math.Abs(lastResult - currentResult) < deviation || Math.Abs(currentResult) < deviation)
                {
                    isFind = true;
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            if (currentResult >= 0)
            {
                output.WriteLine(currentResult);
            }
            else
            {
                output.WriteLine(lastResult);
            }

            output.Close();
        }
    }
}
    



