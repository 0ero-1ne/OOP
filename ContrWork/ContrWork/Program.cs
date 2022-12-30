using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
//Variant 13

namespace ContrWork
{
    class Program
    {
        static void Main()
        {
            int number = 10;
            object o = number;

            FirstTask firstTask = new FirstTask(5, 5);
            firstTask.FillArray();
            Console.WriteLine(firstTask.CalculateElements());
            Car car1 = new Car(75, "Green", "Audi", "1234AB-1");
            object car2 = car1.Clone();
            Console.WriteLine(car1.Equals(car2));
            Car car3 = car1 * 5;
            Console.WriteLine(car3.Volume);

            dynamic[] cars = new dynamic[3] {
                new Car(75, "Green", "Audi", "1234AB-1"),
                new SuperCar(95, "Red", "Toyota", "1255AB-3"),
                new VipCar(80, "White", "Mazda", "1344AB-2")
            };

            Console.WriteLine(cars[2].Go());
        }
    }
}
