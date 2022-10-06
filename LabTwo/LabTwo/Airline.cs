using System;
using System.Collections.Generic;

namespace LabTwo
{
    partial class Airline
    {
        readonly int ID;
        static string curDate;
        
        public int FlightNumber 
        {
            get
            {
                return flightNumber;
            }
            set
            {
                if (value > 0 && value < 1000) flightNumber = value;
            }
        }
        int flightNumber;

        string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        string destination;

        public string PlaneType
        {
            get
            {
                return planeType;
            }
            set
            {
                planeType = value;
            }
        }
        string planeType;

        public string DepartureTime
        {
            get
            {
                return departureTime;
            }
            set
            {
                departureTime = value;
            }
        }
        string departureTime;

        public string DaysOfTheWeek
        {
            get
            {
                return daysOfTheWeek;
            }
        }
        string daysOfTheWeek;

        static int AmountOfObjects = 0;

        private Airline
        (
            int flightNumber
        )
        {
            ID = GetHashCode();
            FlightNumber = flightNumber;
            Destination = "Бразилия";
            PlaneType = "Ту-137";
            DepartureTime = "12:00";
            this.daysOfTheWeek = "ПН";
            AmountOfObjects++;
        }

        public Airline() //constructor w/o params
        {
            ID = GetHashCode();
            FlightNumber = 1;
            Destination = "Великобритания";
            PlaneType = "Ту-134";
            DepartureTime = "13:00";
            this.daysOfTheWeek = "ПН, ПТ";
            AmountOfObjects++;
        }

        public Airline //costructor with params and default constructor
        (
            int flightNumber,
            string destination,
            string planeType,
            string departureTime = "12:00",
            string daysOfTheWeek = "ПН, СР, ПТ"
        )
        {
            ID = GetHashCode();
            FlightNumber = flightNumber;
            Destination = destination;
            PlaneType = planeType;
            DepartureTime = departureTime;
            this.daysOfTheWeek = daysOfTheWeek;
            AmountOfObjects++;
        }

        static Airline() //static constructor
        {
            curDate = DateTime.Now.ToString();
        }
    }

    partial class Airline
    {
        public static string PrintStaticInfo()
        {
            return string.Format("Amount of objects: {0}, {1}", AmountOfObjects, curDate);
        }

        public override string ToString()
        {
            return string.Format(
                "ID: {0}\nFlight number: {1}\nDestination: {2}\nPlane type: {3}\nDeparture time: {4}\nDays of the week: {5}",
                ID, FlightNumber, Destination, PlaneType, DepartureTime, DaysOfTheWeek
            );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Airline)) return false;

            return (FlightNumber == ((Airline) obj).FlightNumber) && 
                (Destination == ((Airline)obj).Destination) &&
                (PlaneType == ((Airline)obj).PlaneType) &&
                (DepartureTime == ((Airline)obj).DepartureTime) &&
                (daysOfTheWeek == ((Airline)obj).DaysOfTheWeek);
        }

        static public List<Airline> GetFlightsByDestination(ref Airline[] flights, string destination)
        {
            List<Airline> returnFlights = new List<Airline>();

            foreach(var flight in flights)
            {
                if (flight.destination.ToLower() == destination.ToLower())
                {
                    returnFlights.Add(flight);
                }
            }

            return returnFlights;
        }

        public bool hasDepartureDay(string departureDay)
        {
            if (daysOfTheWeek.ToLower().Contains(departureDay.ToLower())) return true;

            return false;
        }
    }
}
