using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Создайте консольное приложение мобильный оператор.Используя события реализуйте и продемонстрируйте следующий функционал:
//   Создайте один мобильный оператор поддерживающий маршрутизацию с многими экземплярами MobileAccount.

//   Класс представляющий мобильный оператор должен знать о зарегистрированных MobileAccount и осуществлять маршрутизацию звонков и смс.
//   В момент когда приходит звонок или смс выводите в консоль соответствующее сообщение из конкретного экземпляра MobileAccount.

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileOperator mobileOperator = new MobileOperator();
            var mobile1 = new MobileAccount(1);
            var mobile2 = new MobileAccount(2);
            var mobile3 = new MobileAccount(3);
            var mobile4 = new MobileAccount(4);
            var mobile5 = new MobileAccount(5);
            mobileOperator.AddMobileAccount(mobile1);
            mobileOperator.AddMobileAccount(mobile2);
            mobileOperator.AddMobileAccount(mobile3);
            mobileOperator.AddMobileAccount(mobile4);
            mobileOperator.AddMobileAccount(mobile5);

            mobile1.Call(mobile3.Id);
            mobile3.Call(mobile5.Id);
            mobile2.Call(mobile1.Id);
            mobile1.Call(mobile3.Id);
            mobile2.Call(49);

            mobile1.SMS(mobile3.Id);
            mobile3.SMS(mobile5.Id);
            mobile2.SMS(mobile1.Id);
            mobile1.SMS(mobile3.Id);
            mobile2.SMS(50);

            Console.ReadLine();
        }
    }
}
