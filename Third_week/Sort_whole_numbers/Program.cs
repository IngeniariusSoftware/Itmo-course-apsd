namespace Third_week
{
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            input.ReadLine();
            string[] tokens = input.ReadLine().Split(' ');
            int[] firstArray = new int[tokens.Count()];
            for (int i = 0; i < tokens.Count(); i++)
            {
                firstArray[i] = int.Parse(tokens[i]);
            }

            tokens = input.ReadLine().Split(' ');
            int[] secondArray = new int[tokens.Count()];
            for (int i = 0; i < tokens.Count(); i++)
            {
                secondArray[i] = int.Parse(tokens[i]);
            }

            input.Close();
            (byte, byte, byte, byte)[] byteArray = new (byte, byte, byte, byte)[firstArray.Length * secondArray.Length * 2];
            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    byteArray[(i * secondArray.Length) + j].Item1 = (byte)((firstArray[i] * secondArray[j]) & 255);
                    byteArray[(i * secondArray.Length) + j].Item2 = (byte)((firstArray[i] * secondArray[j]) >> 8 & 255);
                    byteArray[(i * secondArray.Length) + j].Item3 =
                        (byte)((firstArray[i] * secondArray[j]) >> 16 & 255);
                    byteArray[(i * secondArray.Length) + j].Item4 =
                        (byte)((firstArray[i] * secondArray[j]) >> 24 & 255);
                }
            }

            int[] countNumbers = new int[1024];
            for (int i = 0; i < byteArray.Length / 2; i++)
            {
                countNumbers[byteArray[i].Item1]++;
                countNumbers[byteArray[i].Item2 + 256]++;
                countNumbers[byteArray[i].Item3 + 512]++;
                countNumbers[byteArray[i].Item4 + 768]++;
            }

            for (int i = 1; i < 256; i++)
            {
                countNumbers[i] += countNumbers[i - 1];
                countNumbers[i + 256] += countNumbers[i + 255];
                countNumbers[i + 512] += countNumbers[i + 511];
                countNumbers[i + 768] += countNumbers[i + 767];
            }

            for (int j = byteArray.Length / 2 - 1; j > -1; j--)
            {
                byteArray[countNumbers[byteArray[j].Item1] - 1 + byteArray.Length / 2] = byteArray[j];
                countNumbers[byteArray[j].Item1]--;
            }

            for (int j = byteArray.Length - 1; j > byteArray.Length / 2 - 1; j--)
            {
                byteArray[countNumbers[byteArray[j].Item2 + 256] - 1] = byteArray[j];
                countNumbers[byteArray[j].Item2 + 256]--;
            }

            for (int j = byteArray.Length / 2 - 1; j > -1; j--)
            {
                byteArray[countNumbers[byteArray[j].Item3 + 512] - 1 + byteArray.Length / 2] = byteArray[j];
                countNumbers[byteArray[j].Item3 + 512]--;
            }

            for (int j = byteArray.Length - 1; j > byteArray.Length / 2 - 1; j--)
            {
                byteArray[countNumbers[byteArray[j].Item4 + 768] - 1] = byteArray[j];
                countNumbers[byteArray[j].Item4 + 768]--;
            }

            long sum = 0;
            for (int i = 0; i < byteArray.Length / 2; i += 10)
            {
                sum += (byteArray[i].Item4 << 24) + (byteArray[i].Item3 << 16) + (byteArray[i].Item2 << 8)
                       + byteArray[i].Item1;
            }

            output.WriteLine(sum);
            output.Close();
        }
    }
}
