using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayClass = new ArrayClass();

            for (int i = 0; i < 1001; i++)
            {
                arrayClass.Add(i);
            }

            for (int i = 0; i < arrayClass.Arr.Length; i++)
            {
                Console.Write(arrayClass.GetByIndex(i) + " ");
            }

            Console.ReadLine();
        }
    }
}
