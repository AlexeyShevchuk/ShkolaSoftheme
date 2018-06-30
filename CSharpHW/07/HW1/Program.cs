using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car() { Model = "Model111", Color = "Green", Year = "2014" };
            Console.WriteLine("Model: {0}, Color: {1}, Year: {2}",car.Model,car.Color, car.Year);
            TuningAtelier.TuneCar(car);
            Console.WriteLine("Model: {0}, Color: {1}, Year: {2}", car.Model, car.Color, car.Year);
            Console.ReadLine();
        }
    }
}
