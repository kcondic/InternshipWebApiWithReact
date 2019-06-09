using System;
using System.Collections.Generic;
using InternshipWebApiWithReact.Data.Enums;

namespace InternshipWebApiWithReact.Data.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime TimeOfFlight { get; set; }
        public FlightType Type { get; set; }
        public Airport SourceAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public Plane Plane { get; set; }
        public ICollection<PassengerFlight> PassengerFlights { get; set; }
    }
}
