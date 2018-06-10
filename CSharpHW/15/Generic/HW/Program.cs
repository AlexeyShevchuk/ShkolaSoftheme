using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            list.Remove(4);

            var array = list.ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
