using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = true;
            do
            {
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1 - триугольник");
                Console.WriteLine("2 - квадрат");
                Console.WriteLine("3 - ромб");
                Console.WriteLine("4 - Выход");
                if (!int.TryParse(Console.ReadLine(), out var chouse))
                {
                    Console.Clear();
                    continue;
                }
                if (chouse == 4)
                {
                    flag = false;
                    continue;
                }
                Console.WriteLine("Выберите размерность:");
                if (!int.TryParse(Console.ReadLine(), out var length))
                {
                    Console.Clear();
                    continue;
                }
                switch (chouse)
                {
                    case 1: Triangle(length); break;
                    case 2: Square(length); break;
                    case 3: Romb(length); break;
                    default: flag = false; continue;
                }
                Console.WriteLine("Для продолжения нажмите кнопку...");
                Console.ReadKey();
                Console.Clear();

            } while (flag) ;
            Console.ReadKey();
        }

        static void Triangle(int length)
        {
            for (int i = length; i >= 0; i--)
            {
                for (int j = 0; j < length - i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void Square(int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void Romb(int length)
        {
            if (length % 2 == 0)
            {
                length++;
            }
            int center = length / 2;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i <= center)
                    {
                        if (j >= center - i && j <= center + i)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        if (j >= center + i - length + 1 && j <= center - i + length - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
