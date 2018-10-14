namespace Digital_sorting
{
    using System.IO;
    using System.IO.MemoryMappedFiles;

    class Program
    {
        static void Main()
        {

           StreamReader inputAdd = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] tokens = inputAdd.ReadLine().Split(' ');
            int strLength = int.Parse(tokens[0]), strCount = int.Parse(tokens[1]), maxSteps = int.Parse(tokens[2]);
            inputAdd.Close();

            var input = MemoryMappedFile.CreateFromFile(
                "input.txt",
                System.IO.FileMode.Open,
                "fileHandle",
                4096 * 4096);
            var myAccessor = input.CreateViewStream();

            byte[] allBytes = new byte[tokens[0].Length + tokens[1].Length + tokens[2].Length + 4 + strCount * (strLength + 2)];
            for (int i = 0; i < allBytes.Length; i++)
            {
                allBytes[i] = (byte)myAccessor.ReadByte();
            }

            myAccessor.Close();
            int[] positions = new int[strLength * 2];
            int[] countNumbers = new int[26 * maxSteps];
            for (int i = 0; i < strLength; i++)
            {
                positions[i] = i;
            }

            for (int y = 0; y < maxSteps; y++)
            {
                for (int x = 0; x < strLength; x++)
                {
                    countNumbers[allBytes[positions[x + (strLength * (y % 2))] + allBytes.Length - ((y + 1) * strLength)
                                                                                                 - (y + 1) * 2] - 97
                                 + 26 * y]++;
                }

                for (int i = 1; i < 26; i++)
                {
                    countNumbers[i + (26 * y)] += countNumbers[i - 1 + (26 * y)];
                }

                for (int x = strLength - 1; x > -1; x--)
                {
                    positions[countNumbers[allBytes[positions[x + (strLength * (y % 2))] + allBytes.Length
                                                    - ((y + 1) * strLength) - (y + 1) * 2] - 97 + (26 * y)]-- - 1
                              + strLength * ((y + 1) % 2)] = positions[x + strLength * (y % 2)];
                }
            }

            for (int i = 0; i < strLength; i++)
            {
                output.Write(positions[i + (maxSteps % 2 * strLength)] + 1 + " ");
            }

            output.Close();
        }
    }
}
