
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("----------------");
            int total = 0;
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out int n)) Console.Write($" {n.ToString().PadLeft(2).PadRight(2)} + {total.ToString().PadLeft(2).PadRight(2)} = {(total += n).ToString().PadLeft(2).PadRight(2)} \n");
            }
            Console.WriteLine($"-----------------\nTotal: {total}");
        }
    }
}
