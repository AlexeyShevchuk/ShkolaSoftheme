using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var carConstructor = new CarConstructor();
            var car = carConstructor.Construct(Engine.Engine1, Color.Color1, Transmission.Transmission1);
            Console.WriteLine(car.Engine);
            carConstructor.Reconstruct(car);
            Console.WriteLine(car.Engine);
        }
    }
}
