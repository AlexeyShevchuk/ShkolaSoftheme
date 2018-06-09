using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[1001];
            var rand = new Random();
            var unique = rand.Next();
            int? res = null;
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                array[i] = rand.Next();
                array[i + 1] = array[i];
            }

            array[array.Length - 1] = unique;

            for (int j, i = array.Length - 1; i >= 1; i--)
            {
                j = rand.Next(i + 1);
                var temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            res = Search(array);
            stopWatch.Stop();

            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine("Unique value: {0}", unique);
            Console.WriteLine("Result value: {0}", Search(array));
            Console.ReadLine();
        }

        static int? Search(int[] arr)
        {
            var arrEven = new int?[arr.Length];
            var arrNotEven = new int?[arr.Length];

            var evenLenght = 0;
            var notEvenLenght = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arrEven[evenLenght] = arr[i];
                    evenLenght++;
                }
                else
                {
                    arrNotEven[notEvenLenght] = arr[i];
                    notEvenLenght++;
                }
            }

            if (notEvenLenght % 2 == 0)
            {
                return SearchForPart(arrEven, evenLenght);
            }
            else
            {
                return SearchForPart(arrNotEven, notEvenLenght);
            }
        }
        static int? SearchForPart(int?[] arr, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                if (arr[i] == null)
                {
                    continue;
                }

                for (int j = i + 1; j < lenght; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        arr[i] = null;
                        arr[j] = null;
                        break;
                    }

                    if (arr[i] != arr[j] && j == lenght - 1)
                    {
                        return arr[i];
                    }
                }
            }
            return null;
        }
    }
}
