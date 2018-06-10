using System;


namespace HW
{
    class CarConstructor
    {
        public Car Construct(Engine engine, Color color, Transmission transmission)
        {
            return new Car(engine, color, transmission);
        }
        public void Reconstruct(Car car)
        {
            car.Engine = Engine.NewEngine;
        }
    }
}