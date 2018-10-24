namespace Bracket_sequence
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            byte[] bracketSequence = File.ReadAllBytes("input.txt");
            byte[] bufferBrackets = new byte[100000];
            int startPostion;
            for (startPostion = 0; startPostion < bracketSequence.Length && bracketSequence[startPostion] != 10; startPostion++);
            int lengthBuffer = 0;
            bool isRight = true;
            StreamWriter output = new StreamWriter("output.txt");
            for (int i = startPostion + 1; i < bracketSequence.Length; i++)
            {
                switch (bracketSequence[i])
                {
                    case 40:
                        {
                             bufferBrackets[lengthBuffer] = 40;
                            ++lengthBuffer;
                            break;
                        }

                    case 41:
                        {
                            if (lengthBuffer > 0 && bufferBrackets[lengthBuffer - 1] == 40)
                            {
                                --lengthBuffer;
                            }
                            else
                            {
                                isRight = false;
                            }

                            break;
                        }

                    case 91:
                        {
                            bufferBrackets[lengthBuffer] = 91;
                            ++lengthBuffer;
                            break;
                        }

                    case 93:
                        {
                            if (lengthBuffer > 0 && bufferBrackets[lengthBuffer - 1] == 91)
                            {
                                --lengthBuffer;
                            }
                            else
                            {
                                isRight = false;
                            }

                            break;
                        }

                    case 10:
                        {
                            if (isRight && lengthBuffer == 0)
                            {
                                output.WriteLine("YES");
                            }
                            else
                            {
                                output.WriteLine("NO");
                            }

                            lengthBuffer = 0;
                            isRight = true;
                            break;
                        }
                }                
            }

            output.Close();
        }
    }
}
