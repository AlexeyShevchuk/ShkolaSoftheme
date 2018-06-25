using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom(@"..\..\..\DLL\DLL\bin\Debug\DLL.dll");
            var type = assembly.GetType("DLL.User");
            dynamic user = Activator.CreateInstance(type);
            type = user.GetType();
            var methods = type.GetMethods();
            var properties = type.GetProperties();

            foreach (var info in methods)
            {
                Console.WriteLine(info);
            }

            foreach (var info in properties)
            {
                Console.WriteLine(info);
            }

            properties[0].SetValue(user, "Alex");
            properties[1].SetValue(user, "Email");
            properties[2].SetValue(user, "Password");

            Console.WriteLine(type.GetMethod("GetFullInfo")?.Invoke(user, null));

            Console.WriteLine(type.GetMethod("ToString")?.Invoke(user, null));

            Console.ReadLine();
        }
    }
}
