using CarApi.Models;

namespace CarApi.Repositories {
    public interface ICarsRepository {
        Task<Car?> GetById(long carId);
        Task<IEnumerable<Car>> GetAll();
        Task<Car> Create(Car car);
        Task<Car> Update(Car car);
        Task<Car> Delete(Car car);
    }
}
