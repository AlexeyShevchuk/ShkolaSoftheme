using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[1001];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            var temp = 0;
            for (int j, i = array.Length - 1; i >= 1; i--)
            {
                j = rand.Next(i + 1);
                temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            array = Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadLine();
        }

        static int[] Sort(int[] array)
        {
            var x = 0;
            var i = 0;
            var j = i;
            for (i = 0; i < array.Length; i++)
            {
                x = array[i];
                j = i;
                for (; j > 0 && array[j - 1] > x; j--)
                {
                    if (true)
                    {
                        array[j] = array[j - 1];
                    }
                }
                array[j] = x;
            }
            return array;
        }
    }
}
