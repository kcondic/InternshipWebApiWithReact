using System.Collections.Generic;

namespace InternshipWebApiWithReact.Data.Models.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICollection<Flight> FromFlights { get; set; }
        public ICollection<Flight> ToFlights { get; set; }
    }
}
