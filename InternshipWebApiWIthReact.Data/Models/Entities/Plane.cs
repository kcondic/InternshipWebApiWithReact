using System.Collections.Generic;

namespace InternshipWebApiWithReact.Data.Models.Entities
{
    public class Plane
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Carrier { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}