namespace Digital_sorting
{
    using System.IO;
    using System.IO.MemoryMappedFiles;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] tokens = input.ReadLine().Split(' ');
            int strLength = int.Parse(tokens[0]), strCount = int.Parse(tokens[1]), maxSteps = int.Parse(tokens[2]);
            input.Close();
            byte[] allBytes = File.ReadAllBytes("input.txt");
            int[] positions = new int[strLength << 1];
            int[] countNumbers = new int[13 * maxSteps << 1];
            for (int i = 0; i < strLength; i++)
            {
                positions[i] = i;
            }

            long buf1, buf2;
            int x;

            for (int y = 0; y < maxSteps; y++)
            {
                buf1 = strLength * (y & 1);
                buf2 = (y + 1) * strLength;
                for (x = 0; x < strLength; x++)
                {
                    countNumbers[allBytes[positions[x + strLength * (y & 1)] + allBytes.Length - buf2 - (y << 1) - 2]
                                 - 97 + (13 * (y << 1))]++;
                }

                countNumbers[1 + ((13 * (y << 1)))] += countNumbers[((13 * (y << 1)))];
                countNumbers[2 + ((13 * (y << 1)))] += countNumbers[1 + ((13 * (y << 1)))];
                countNumbers[3 + ((13 * (y << 1)))] += countNumbers[2 + ((13 * (y << 1)))];
                countNumbers[4 + ((13 * (y << 1)))] += countNumbers[3 + ((13 * (y << 1)))];
                countNumbers[5 + ((13 * (y << 1)))] += countNumbers[4 + ((13 * (y << 1)))];
                countNumbers[6 + ((13 * (y << 1)))] += countNumbers[5 + ((13 * (y << 1)))];
                countNumbers[7 + ((13 * (y << 1)))] += countNumbers[6 + ((13 * (y << 1)))];
                countNumbers[8 + ((13 * (y << 1)))] += countNumbers[7 + ((13 * (y << 1)))];
                countNumbers[9 + ((13 * (y << 1)))] += countNumbers[8 + ((13 * (y << 1)))];
                countNumbers[10 + ((13 * (y << 1)))] += countNumbers[9 + ((13 * (y << 1)))];
                countNumbers[11 + ((13 * (y << 1)))] += countNumbers[10 + ((13 * (y << 1)))];
                countNumbers[12 + ((13 * (y << 1)))] += countNumbers[11 + ((13 * (y << 1)))];
                countNumbers[13 + ((13 * (y << 1)))] += countNumbers[12 + ((13 * (y << 1)))];
                countNumbers[14 + ((13 * (y << 1)))] += countNumbers[13 + ((13 * (y << 1)))];
                countNumbers[15 + ((13 * (y << 1)))] += countNumbers[14 + ((13 * (y << 1)))];
                countNumbers[16 + ((13 * (y << 1)))] += countNumbers[15 + ((13 * (y << 1)))];
                countNumbers[17 + ((13 * (y << 1)))] += countNumbers[16 + ((13 * (y << 1)))];
                countNumbers[18 + ((13 * (y << 1)))] += countNumbers[17 + ((13 * (y << 1)))];
                countNumbers[19 + ((13 * (y << 1)))] += countNumbers[18 + ((13 * (y << 1)))];
                countNumbers[20 + ((13 * (y << 1)))] += countNumbers[19 + ((13 * (y << 1)))];
                countNumbers[21 + ((13 * (y << 1)))] += countNumbers[20 + ((13 * (y << 1)))];
                countNumbers[22 + ((13 * (y << 1)))] += countNumbers[21 + ((13 * (y << 1)))];
                countNumbers[23 + ((13 * (y << 1)))] += countNumbers[22 + ((13 * (y << 1)))];
                countNumbers[24 + ((13 * (y << 1)))] += countNumbers[23 + ((13 * (y << 1)))];
                countNumbers[25 + ((13 * (y << 1)))] += countNumbers[24 + ((13 * (y << 1)))];

                for (x = strLength - 1; x > -1; x--)
                {
                    positions[countNumbers[
                                  allBytes[positions[x + strLength * (y & 1)] + allBytes.Length - buf2 - (y << 1) - 2]
                                  - 97 + ((13 * (y << 1)))]-- - 1 + strLength * ((y + 1) & 1)] =
                        positions[x + strLength * (y & 1)];
                }
            }


            for (x = 0; x < strLength; x++)
            {
                output.Write(positions[x + ((maxSteps & 1) * strLength)] + 1 + " ");
            }

            output.Close();
        }
    }
}
