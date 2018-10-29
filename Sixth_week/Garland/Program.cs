namespace Garland
{
    using System.IO;
    using System;
    using System.Globalization;

    class Program
    {
        private static double BuildGarland(int countNodes, double lastHeight, double currentHeight)
        {
            for (; 0 < countNodes && currentHeight > 0; --countNodes)
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
                   bestStartHeight = firstHeight / 2,
                   deviation = 0.0000000001,
                   upBoardResult = 0,
                   downBoardResult,
                   shelfHeight;

            input.Close();
            while (0 > BuildGarland(countNodes: countNodes, lastHeight: firstHeight, currentHeight: bestStartHeight))
            {
                shelfHeight = bestStartHeight;
                bestStartHeight += Math.Abs(lastBestHeight - bestStartHeight) / 2;
                lastBestHeight = shelfHeight;
            }

            bool isFind = false;
            while (!isFind)
            {
                downBoardResult = BuildGarland(
                    countNodes,
                    firstHeight,
                    bestStartHeight - (Math.Abs(lastBestHeight - bestStartHeight) / 2));

                upBoardResult = BuildGarland(
                    countNodes,
                    firstHeight,
                    bestStartHeight + (Math.Abs(lastBestHeight - bestStartHeight) / 2));

                shelfHeight = bestStartHeight;
                if (downBoardResult > 0 && downBoardResult < upBoardResult)
                {
                    bestStartHeight -= Math.Abs(lastBestHeight - bestStartHeight) / 2;
                }
                else
                {
                    bestStartHeight += Math.Abs(lastBestHeight - bestStartHeight) / 2;
                }

                lastBestHeight = shelfHeight;

                if (Math.Abs(downBoardResult - upBoardResult) < deviation)
                {
                    isFind = true;
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(upBoardResult);
            output.Close();
        }
    }
}
    



