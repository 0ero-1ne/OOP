using System;
using System.Collections.Generic;
using System.Linq;

namespace LabTen
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {
                "December", "January", "February",
                "March", "April", "May",
                "June", "July", "August",
                "September", "October", "November"
            };

            int N = 5;

            var monthsWithNLength = from month in months
                                    where month.Length == N
                                    select month;

            var summerMonths = from month in months
                               where month.Equals("June") || month.Equals("July") || month.Equals("August")
                               select month;

            var winterMonths = from month in months
                               where month.Equals("December") || month.Equals("January") || month.Equals("February")
                               select month;

            var orderedMonths = months.OrderBy(month => month);
            var monthsWithLetterU = months.Where(month => month.Contains("u")).Where(month => month.Length >= 4);

            Console.WriteLine("Months with length N = 5:");
            foreach (var month in monthsWithNLength)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("\nSummer months:");
            foreach (var month in summerMonths)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("\nWinter months:");
            foreach (var month in winterMonths)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("\nOrdered months:");
            foreach (var month in orderedMonths)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("\nMonths with letter u and length >= 4:");
            foreach (var month in monthsWithLetterU)
            {
                Console.WriteLine(month);
            }

            List<Airline> airlines = new List<Airline>();
            airlines.Add(new Airline(1, "Минск", "Бизнес-класс", "13:40", "ПН, ВТ, СР"));
            airlines.Add(new Airline(2, "Брест", "Эконом-класс", "12:00", "ПН, ВТ"));
            airlines.Add(new Airline(3, "Минск", "Эконом-класс", "06:55", "ПН, СР"));
            airlines.Add(new Airline(4, "Гомель", "Бизнес-класс"));
            airlines.Add(new Airline(5, "Брест", "Эконом-класс"));
            airlines.Add(new Airline(6, "Витебск", "Бизнес-класс"));
            airlines.Add(new Airline(7, "Гродно", "Эконом-класс"));
            airlines.Add(new Airline(8, "Могилёв", "Бизнес-класс"));

            List<Airline> newAirlines = new List<Airline>();
            newAirlines.Add(new Airline(9, "Минск", "Бизнес-класс"));
            newAirlines.Add(new Airline(10, "Брест", "Бизнес-класс"));
            newAirlines.Add(new Airline(11, "Гомель", "Бизнес-класс"));
            newAirlines.Add(new Airline(12, "Минск", "Бизнес-класс"));


            var airlinesToMinsk = from airline in airlines
                                  where airline.Destination.Equals("Минск")
                                  select airline;

            var airlinesOnMonday = airlines.Where(airline => airline.DaysOfTheWeek.Contains("ПН"));
            var firstAirlineOnMonday = airlines.Where(airline => airline.DaysOfTheWeek.Contains("ПН")).OrderBy(
                airline => Convert.ToInt32(airline.DepartureTime.Split(':')[0])
            ).First();
            var lastAirlineOnWednesday = airlines.Where(airline => airline.DaysOfTheWeek.Contains("СР")).OrderBy(
                airline => Convert.ToInt32(airline.DepartureTime.Split(':')[0])
            ).Last();
            var orderedAirlines = airlines.OrderBy(airline => airline.DepartureTime);

            Console.WriteLine("\n-----\nAirlines to Minsk:\n");
            foreach (var airline in airlinesToMinsk)
            {
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\n-----\nAirlines on monday:\n");
            foreach (var airline in airlinesOnMonday)
            {
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\n-----\nFirst airline on monday:\n\n{0}", firstAirlineOnMonday.ToString());
            Console.WriteLine("\n-----\nLast airline on wednesday:\n\n{0}", lastAirlineOnWednesday.ToString());

            Console.WriteLine("\n-----\nOrdered airlines:\n");
            foreach (var airline in orderedAirlines)
            {
                Console.WriteLine(airline.ToString());
            }

            var multiQuery = airlines.Where(airline => airline.DaysOfTheWeek.Contains("ПН"))
                               .GroupBy(airline => airline.Destination)
                               .OrderBy(airline => airline.Key)
                               .Select(group =>
                               {
                                   int count = 0;
                                   foreach (var airline in group) count++;

                                   return new { Destination = group.Key, Count = count };
                               });

            Console.WriteLine("\n-----\nGrouped airlines:\n");
            foreach (var group in multiQuery)
            {
                Console.WriteLine(group.Destination + ": " + group.Count);
            }

            var joinedAirlines = airlines.Join(newAirlines,
                                 a1 => a1.Destination,
                                 a2 => a2.Destination,
                                 (a1, a2) => new { First = a1.FlightNumber, Second = a2.FlightNumber, Destination = a1.Destination });

            Console.WriteLine("\n-----\nJoined airlines:\n");
            foreach (var airline in joinedAirlines)
            {
                Console.WriteLine(airline.First + " - " + airline.Second + " - " + airline.Destination);
            }
        }
    }
}
