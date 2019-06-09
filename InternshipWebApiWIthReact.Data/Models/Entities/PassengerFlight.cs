using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipWebApiWithReact.Data.Models.Entities
{
    public class PassengerFlight
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public string SeatNumber { get; set; }
    }
}
