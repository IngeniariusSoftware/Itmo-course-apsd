namespace Stack
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            string[] inputStack = File.ReadAllLines("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] bufStack = new string[inputStack.Length];
            int stackLength = bufStack.Length - 1;
            for (int i = 1; i < inputStack.Length; i++)
            {
                if (inputStack[i][0] == '+')
                {
                    bufStack[stackLength] = inputStack[i].Substring(2);
                    --stackLength;
                }
                else
                {
                    output.WriteLine(bufStack[stackLength + 1]);
                    ++stackLength;
                }
            }

            output.Close();
        }
    }
}
