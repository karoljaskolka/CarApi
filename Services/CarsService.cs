using CarApi.Models;
using CarApi.Repositories;

namespace CarApi.Services {
    public class CarsService : ICarsService {
        private readonly ICarsRepository _carRepo;
        public CarsService(ICarsRepository carRepo) {
            _carRepo = carRepo;
        }
        public async Task<Car?> GetCar(long carId) {
            return await _carRepo.GetById(carId);
        }
        public async Task<IEnumerable<Car>> GetCars() {
            return await _carRepo.GetAll();
        }
        public async Task<Car> AddCar(Car car) {
            return await _carRepo.Create(car);
        }
        public async Task<Car?> UpdateCar(long carId, Car car) {
            Car? updatedCar = await _carRepo.GetById(carId);

            if (updatedCar == null) return null;

            updatedCar.Manufacturer = car.Manufacturer;
            updatedCar.Model = car.Model;
            updatedCar.Year = car.Year;

            return await _carRepo.Update(updatedCar);
        }
        public async Task<Car?> DeleteCar(long carId) {
            Car? car = await _carRepo.GetById(carId);
            
            if (car == null) return null;

            return await _carRepo.Delete(car);
        }
    }
}
 