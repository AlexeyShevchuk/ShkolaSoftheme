using System;


namespace HW2
{
    class CarConstructor
    {
        public Car Construct(Engine engine, Color color, Transmission transmission)
        {
            return new Car(engine, color, transmission);
        }
        public void Reconstruct(Car car)
        {
            car.Engine = new Engine("NewEngine");
        }
    }
}