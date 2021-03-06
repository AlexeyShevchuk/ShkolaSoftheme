﻿using System;
using System.Diagnostics;

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
            var temp = 0;
            for (int j, i = array.Length - 1; i >= 1; i--)
            {
                j = rand.Next(i + 1);
                temp = array[j];
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

            var evenLength = 0;
            var notEvenLength = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arrEven[evenLength] = arr[i];
                    evenLength++;
                }
                else
                {
                    arrNotEven[notEvenLength] = arr[i];
                    notEvenLength++;
                }
            }

            if (notEvenLength % 2 == 0)
            {
                return SearchForPart(arrEven, evenLength);
            }
            else
            {
                return SearchForPart(arrNotEven, notEvenLength);
            }
        }

        static int? SearchForPart(int?[] arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (arr[i] == null)
                {
                    continue;
                }

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        arr[i] = null;
                        arr[j] = null;
                        break;
                    }

                    if (arr[i] != arr[j] && j == length - 1)
                    {
                        return arr[i];
                    }
                }
            }
            return null;
        }
    }
}
