using System;


namespace HW
{
    class Car
    {
        public Engine Engine { set; get; }
        public Color Color { set; get; }
        public Transmission Transmission { set; get; }

        public Car(Engine engine, Color color, Transmission transmission)
        {
            this.Engine = engine;
            this.Color = color;
            this.Transmission = transmission;
        }
    }
}