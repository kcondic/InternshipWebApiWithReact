using System;
using System.Collections.Generic;
using System.Text;
using InternshipWebApiWithReact.Data.Models.Entities;

namespace InternshipWebApiWithReact.Domain.Repositories.Interfaces
{
    public interface IAirportRepository
    {
        List<Airport> GetAllAirports();
        bool AddAirport(Airport airportToAdd);
        bool EditAirport(Airport editedAirport);
        bool DeleteAirport(int idOfAirportToDelete);
        Airport GetAirportById(int id);
    }
}