using System;

namespace LabTwo
{
    class Program
    {
        static void Main()
        {
            Airline[] flights = new Airline[] {
                new Airline(1, "Minsk", "Business", "14:00", "MN, TU, WED"),
                new Airline(2, "Paris", "Econom"),
                new Airline(3, "Moscow", "Business", "15:00", "MN, ST, SU")
            };

            var flightsByDestination = Airline.GetFlightsByDestination(ref flights, "Minsk");
            
            foreach(var flight in flightsByDestination)
            {
                Console.WriteLine(flight.ToString() + "\n");
            }

            Console.WriteLine("------------------------------------\n");

            foreach (var flight in flights)
            {
                if (flight.HasDepartureDay("MN"))
                {
                    Console.WriteLine(flight.ToString() + "\n");
                }
            }

            Console.WriteLine(Airline.PrintStaticInfo());

            var plane = new { 
                FlightNumber = 255,
                Destination = "Brest",
                FlightType = "Business",
                DepartureType = "12:00",
                DaysOfTheWeek = "MN, TU, WED, TH, FR, ST, SU"
            };
        }
    }
}
