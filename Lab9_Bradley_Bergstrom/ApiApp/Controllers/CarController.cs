    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Lab3.Data;
using Lab3.Data.Entities;


namespace ApiApp.Controllers
{

    [RoutePrefix("api/cars")]
    public class CarController : ApiController
    {
        private AppDbContext _dbContext;

        public CarController()
        {
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public IEnumerable<Car> GetAllPets()
        {
            return _dbContext.Cars.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetCar(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault((p) => p.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

    }
}
