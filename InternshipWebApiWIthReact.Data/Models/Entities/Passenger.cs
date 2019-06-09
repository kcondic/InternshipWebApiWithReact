using System.Collections.Generic;

namespace InternshipWebApiWithReact.Data.Models.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FlightPoints { get; set; }
        public ICollection<PassengerFlight> PassengerFlights { get; set; }
    }
}
