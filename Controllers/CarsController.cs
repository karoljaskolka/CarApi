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

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            IEnumerable<Car> cars = await _carsService.GetCars();

            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(long id)
        {
            Car? car = await _carsService.GetCar(id);

            if (car == null) return NotFound(); 

            return Ok(car);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(long id, [FromBody] Car car)
        {
            if (id != car.Id) return BadRequest();

            Car? updatedCar = await _carsService.UpdateCar(id, car);

            if (updatedCar == null) return NotFound();

            return Ok(updatedCar);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar([FromBody] Car car)
        {
            Car newCar = await _carsService.AddCar(car);

            string uri = $"https://localhost:7236/api/Cars/{newCar.Id}";

            return Created(uri, newCar);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(long id)
        {
            Car? car = await _carsService.DeleteCar(id);

            if (car == null) return NotFound();

            return NoContent();
        }
    }
}
