namespace Queue
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            string[] inputQueue = File.ReadAllLines("input.txt");
            StreamWriter output = new StreamWriter("output.txt");
            string[] bufQueue = new string[inputQueue.Length];
            int queueLength = 0;
            int queuePosition = 0;
            for (int i = 1; i < inputQueue.Length; i++)
            {
                if (inputQueue[i][0] == '+')
                {
                    bufQueue[queueLength] = inputQueue[i].Substring(2);
                    queueLength++;
                }
                else
                {
                    output.WriteLine(bufQueue[queuePosition]);
                    queuePosition++;
                }
            }

            output.Close();
        }
    }
}
