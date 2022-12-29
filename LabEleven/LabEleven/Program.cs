using System;

namespace LabEleven
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle(10);
            var assemblyInfo = Reflector.GetBuildName("LabEleven.Circle");
            var publicMethodsOfCircle = Reflector.GetPublicMethods("LabEleven.Circle");
            Reflector.InvokeMethod(circle, "Calculate");

            foreach (var method in publicMethodsOfCircle)
            {
                Console.WriteLine(method);
            }

            Console.WriteLine(assemblyInfo);

            var circleTwo = Reflector.Create<Circle>();
            Console.WriteLine(circleTwo.Radius);

            Console.WriteLine("-----");
            var publicMethodsOfInt = Reflector.GetPublicMethods("System.Int32");
            foreach (var method in publicMethodsOfInt)
            {
                Console.WriteLine(method);
            }
        }
    }
}
