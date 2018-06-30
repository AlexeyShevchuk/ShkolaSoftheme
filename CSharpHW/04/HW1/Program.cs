using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set date DD/MM/YYYY: ");

            var str = Console.ReadLine();

            if (!DateTime.TryParse(str, out var dateBirth))
            {
                Console.WriteLine("Wrong input!");
                return;
            }
            Console.WriteLine(ZodiakIdentify(dateBirth));
            Console.ReadKey();
        }
        private static string ZodiakIdentify(DateTime dateBirth)
        {
            var result = string.Empty;
            string[] zodiaks = { "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец", "Козерог", "Водолей", "Рыбы" };
            if ((dateBirth.Month == 3 && dateBirth.Day >= 21) || (dateBirth.Month == 4 && dateBirth.Day <= 20))
            {
                result = zodiaks[0];
            }
            else
            if ((dateBirth.Month == 4 && dateBirth.Day >= 21) || (dateBirth.Month == 5 && dateBirth.Day <= 20))
            {
                result = zodiaks[1];
            }
            else
            if ((dateBirth.Month == 5 && dateBirth.Day >= 21) || (dateBirth.Month == 6 && dateBirth.Day <= 21))
            {
                result = zodiaks[2];
            }
            else
            if ((dateBirth.Month == 6 && dateBirth.Day >= 22) || (dateBirth.Month == 7 && dateBirth.Day <= 22))
            {
                result = zodiaks[3];
            }
            else
            if ((dateBirth.Month == 7 && dateBirth.Day >= 23) || (dateBirth.Month == 8 && dateBirth.Day <= 23))
            {
                result = zodiaks[4];
            }
            else
            if ((dateBirth.Month == 8 && dateBirth.Day >= 24) || (dateBirth.Month == 9 && dateBirth.Day <= 23))
            {
                result = zodiaks[5];
            }
            else
            if ((dateBirth.Month == 9 && dateBirth.Day >= 24) || (dateBirth.Month == 10 && dateBirth.Day <= 22))
            {
                result = zodiaks[6];
            }
            else
            if ((dateBirth.Month == 10 && dateBirth.Day >= 23) || (dateBirth.Month == 11 && dateBirth.Day <= 22))
            {
                result = zodiaks[7];
            }
            else
            if ((dateBirth.Month == 11 && dateBirth.Day >= 23) || (dateBirth.Month == 12 && dateBirth.Day <= 21))
            {
                result = zodiaks[8];
            }
            else
            if ((dateBirth.Month == 12 && dateBirth.Day >= 22) || (dateBirth.Month == 1 && dateBirth.Day <= 20))
            {
                result = zodiaks[9];
            }
            else
            if ((dateBirth.Month == 1 && dateBirth.Day >= 21) || (dateBirth.Month == 2 && dateBirth.Day <= 19))
            {
                result = zodiaks[10];
            }
            else
            if ((dateBirth.Month == 2 && dateBirth.Day >= 20) || (dateBirth.Month == 3 && dateBirth.Day <= 20))
            {
                result = zodiaks[11];
            }
            return result;
        }
    }
}
