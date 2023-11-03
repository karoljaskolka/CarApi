using CarApi.Models;

namespace CarApi.Services {
    public interface ICarsService {
        Task<Car> AddCar(Car car);
        Task<IEnumerable<Car>> GetCars();
        Task<Car?> GetCar(long carId);
        Task<Car?> UpdateCar(long carId, Car car);
        Task<Car?> DeleteCar(long carId);
    }
}
