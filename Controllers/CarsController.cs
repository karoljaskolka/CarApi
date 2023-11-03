using Microsoft.AspNetCore.Mvc;
using CarApi.Models;
using CarApi.Services;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        // GET: api/Cars?page=1&perPage=10
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars(
            [FromQuery(Name = "page")] int page,
            [FromQuery(Name = "perPage")] int perPage
        )
        {
            IEnumerable<Car> cars = await _carsService.GetCars();

            Console.WriteLine($"Page: {page}, PerPage: {perPage}");

            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Car>> GetCar([FromRoute] long id)
        {
            Car? car = await _carsService.GetCar(id);

            if (car == null) return NotFound(); 

            return Ok(car);
        }

        // PUT: api/Cars/5
        // PATCH: api/Cars/5
        // JSON Body: { Manufacturer: "Ford", Model: "Focus", Year: 2010 }
        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCar([FromRoute] long id, [FromBody] Car car)
        {
            if (id != car.Id) return BadRequest();

            Car? updatedCar = await _carsService.UpdateCar(id, car);

            if (updatedCar == null) return NotFound();

            return Ok(updatedCar);
        }

        // POST: api/Cars
        // JSON Body: { Manufacturer: "Ford", Model: "Mustang", Year: 1974 }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Car>> PostCar([FromBody] Car car)
        {
            Car newCar = await _carsService.AddCar(car);

            string uri = $"https://localhost:7236/api/Cars/{newCar.Id}";

            return Created(uri, newCar);
        }

        // DELETE: api/Cars/5
        // [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCar([FromRoute] long id)
        {
            Car? car = await _carsService.DeleteCar(id);

            if (car == null) return NotFound();

            return NoContent();
        }
    }
}
