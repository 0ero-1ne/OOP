using System;

namespace ContrWork
{
    class Car : ICloneable
    {
        public int Volume { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }

        public Car
        (
            int volume,
            string color,
            string model,
            string number
        )
        {
            Volume = volume;
            Color = color;
            Model = model;
            Number = number;
        }

        public object Clone()
        {
            return new Car(Volume, Color, Model, Number);
        }

        public static Car operator *(Car car, int addingVolume)
        {
            return new Car(car.Volume * addingVolume, car.Color, car.Model, car.Number);
        }
    }
}
