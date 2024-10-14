using CarFleet.Domain;

namespace CarFleet.Services
{
    public interface ICarService
    {
        Task<List<Car>> GetCarsAsync();

        Task<Car> GetCarByIdAsync(Guid carId);

        Task<bool> CreateCarAsync(Car car);

        Task<bool> UpdateCarAsync(Car carToUpdate);

        Task<bool> DeleteCarAsync(Guid carId);
    }
}
