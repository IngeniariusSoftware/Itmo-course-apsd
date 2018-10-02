using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Reader.Read();
            var sorter = new Sorter(list);
            sorter.Sort1();
        }
    }
  

    class Reader
    {
        public static List<int> Read()
        {
            var sr = new StreamReader("input.txt");
            sr.ReadLine();
            var s = sr.ReadLine();
            var a = s.Split(' ').ToList();
            var b = new List<int>();
            foreach (var ch in a)
            {
                b.Add(Int32.Parse(ch));
            }

            return b;
        }

        public static void Write(List<int> sort)
        {
            var sw = new StreamWriter("output.txt");
            foreach (var item in sort)
            {
                sw.Write(item+" ");
            }
            
            sw.Close();
        }
    }
    class Sorter
    {
        public List<int> Collection { get; set; }
        public Sorter(List<int> collection)
        {
            Collection = collection;
        }

        public void Sort1()
        {
            var sw = new StreamWriter("output.txt");
            for (int i = 0; i < Collection.Count(); i++)
            {
                for (int j = Collection.Count - 1; j > i; j--)
                {
                    if (Collection[j] < Collection[i])
                    {
                        sw.WriteLine("Swap elements at indices {0} and {1}.", i + 1, j + 1);
                        var temp = Collection[j];
                        Collection[j] = Collection[i];
                        Collection[i] = temp;
                    }
                }
            }
            sw.Write("No more swaps needed.\n");
            foreach (var item in Collection)
            {
                sw.Write(item + " ");
            }

            sw.Close();
        }
    }
}
