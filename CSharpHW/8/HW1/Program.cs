using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserClass original1 = new UserClass("aaa1", "bbb1", "ccc1", new SomeClass(1,1));
            UserClass clone1 = original1;

            Console.WriteLine("Первая проверка");

            Console.WriteLine(original1);
            Console.WriteLine(clone1);

            original1.Login = "111";
            original1.SomeClass.A = 11;
            original1.SomeClass.B = 11;

            Console.WriteLine("Вторая проверка после изменения");
            Console.WriteLine(original1);
            Console.WriteLine(clone1);

            UserClass original2 = new UserClass("aaa2", "bbb2", "ccc2", new SomeClass(2, 2));
            UserClass clone2 = original2.Clone() as UserClass;

            Console.WriteLine("Первая проверка");

            Console.WriteLine(original2);
            Console.WriteLine(clone2);

            original2.Login = "222";
            original2.SomeClass.A = 22;
            original2.SomeClass.B = 22;

            Console.WriteLine("Вторая проверка после изменения");
            Console.WriteLine(original2);
            Console.WriteLine(clone2);

            UserStruct original3 = new UserStruct("aaa3", "bbb3", "ccc3", new SomeClass(3, 3));
            UserStruct clone3 = original3;

            Console.WriteLine("Первая проверка");

            Console.WriteLine(original3);
            Console.WriteLine(clone3);

            original3.Login = "333";
            original3.SomeClass.A = 33;
            original3.SomeClass.B = 33;

            Console.WriteLine("Вторая проверка после изменения");
            Console.WriteLine(original3);
            Console.WriteLine(clone3);

            UserStruct original4 = new UserStruct("aaa4", "bbb4", "ccc4", new SomeClass(4, 4));
            UserStruct clone4 = (UserStruct)original4.Clone();

            Console.WriteLine("Первая проверка");

            Console.WriteLine(original4);
            Console.WriteLine(clone4);

            original4.Login = "444";
            original4.SomeClass.A = 44;
            original4.SomeClass.B = 44;

            Console.WriteLine("Вторая проверка после изменения");
            Console.WriteLine(original4);
            Console.WriteLine(clone4);

            Console.ReadKey();
        }
    }
}
