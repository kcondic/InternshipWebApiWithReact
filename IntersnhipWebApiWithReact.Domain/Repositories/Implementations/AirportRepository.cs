using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InternshipWebApiWithReact.Data.Models;
using InternshipWebApiWithReact.Data.Models.Entities;
using InternshipWebApiWithReact.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebApiWithReact.Domain.Repositories.Implementations
{
    public class AirportRepository : IAirportRepository
    {
        public AirportRepository(InternshipWebApiWithReactContext context)
        {
            _context = context;
        }
        private readonly InternshipWebApiWithReactContext _context;

        public List<Airport> GetAllAirports()
        {
            return _context.Airports.ToList();
        }

        public bool AddAirport(Airport airportToAdd)
        {
            var doesAirportExist =
                _context.Airports.Any(airport => string.Equals(airport.CityName, airportToAdd.CityName, StringComparison.CurrentCultureIgnoreCase));

            if (doesAirportExist || airportToAdd.CityName.Length < 3)
                return false;

            _context.Airports.Add(airportToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool EditAirport(Airport editedAirport)
        {
            var doesEditedAirportExist =
                _context.Airports.Any(airport => string.Equals(airport.CityName, editedAirport.CityName, StringComparison.CurrentCultureIgnoreCase));

            if (doesEditedAirportExist || editedAirport.CityName.Length < 3)
                return false;

            var airportToEdit = _context.Airports.Find(editedAirport.Id);

            if (airportToEdit == null)
                return false;

            airportToEdit.CityName = editedAirport.CityName;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteAirport(int idOfAirportToDelete)
        {
            var airportToDelete = _context.Airports.Find(idOfAirportToDelete);

            if (airportToDelete == null)
                return false;

            _context.Remove(airportToDelete);
            _context.SaveChanges();
            return true;
        }

        public Airport GetAirportById(int id)
        {
            var airportWithThatId = _context.Airports.Find(id);

            return airportWithThatId;
        }
    }
}
