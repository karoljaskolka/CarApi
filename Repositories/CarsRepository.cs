using CarApi.Context;
using CarApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Repositories {
    public class CarsRepository : ICarsRepository {
        private readonly CarDbContext _context;
        public CarsRepository(CarDbContext context) {
            _context = context;
        }
        public async Task<Car?> GetById(long carId) {
            return await _context.Cars.FindAsync(carId);
        }
        public async Task<IEnumerable<Car>> GetAll() {
            return await _context.Cars.ToListAsync();
        }
        public async Task<Car> Create(Car car) {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Update(Car car) {
            _context.Entry(car).State = EntityState.Modified;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Car car) {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
