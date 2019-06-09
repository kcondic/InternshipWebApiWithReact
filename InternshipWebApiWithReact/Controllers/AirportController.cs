using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipWebApiWithReact.Data.Models.Entities;
using InternshipWebApiWithReact.Domain.Repositories.Implementations;
using InternshipWebApiWithReact.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebApiWithReact.Web.Controllers
{
    [Route("api/airports")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        public AirportController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }
        private readonly IAirportRepository _airportRepository;

        [HttpGet("all")]
        public IActionResult GetAllAirports()
        {
            return Ok(_airportRepository.GetAllAirports());
        }

        [HttpPost("add")]
        public IActionResult AddAirport(Airport airportToAdd)
        {
            var wasAddSuccessful = _airportRepository.AddAirport(airportToAdd);
            if (wasAddSuccessful)
                return Ok();
            return Forbid();
        }

        [HttpPost("edit")]
        public IActionResult EditAirport(Airport editedAirport)
        {
            var wasEditSuccessful = _airportRepository.EditAirport(editedAirport);
            if (wasEditSuccessful)
                return Ok();
            return Forbid();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAirport(int id)
        {
            var wasDeleteSuccessful = _airportRepository.DeleteAirport(id);
            if (wasDeleteSuccessful)
                return Ok();
            return Forbid();
        }

        [HttpGet("get-by-id")]
        public IActionResult GetAirportById(int id)
        {
            var airport = _airportRepository.GetAirportById(id);
            if(airport != null)
                return Ok(airport);
            return NotFound();
        }
    }
}