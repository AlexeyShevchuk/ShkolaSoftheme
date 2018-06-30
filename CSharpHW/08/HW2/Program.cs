using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            var carConstructor = new CarConstructor();
            var car = carConstructor.Construct(new Engine("Engine"), new Color("Red"), new Transmission("Transmission"));
            Console.WriteLine(car.Engine.Model);
            carConstructor.Reconstruct(car);
            Console.WriteLine(car.Engine.Model);
        }
    }
}
