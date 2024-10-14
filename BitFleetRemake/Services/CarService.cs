using CarFleet.Data;
using CarFleet.Domain;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using static CarFleet.Contracts.V1.ApiRoutes;

namespace CarFleet.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext dataContext;

        public CarService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await dataContext.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(Guid carId)
        {
            return await dataContext.Cars.SingleOrDefaultAsync(x => x.Id == carId);
        }

        public async Task<bool> CreateCarAsync(Car car)
        {
            await dataContext.Cars.AddAsync(car);
            var created = await dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateCarAsync(Car carToUpdate)
        {
            dataContext.Cars.Update(carToUpdate);
            var updated = await dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteCarAsync(Guid carId)
        {
            var car = await GetCarByIdAsync(carId);

            if (car == null)
                return false;

            dataContext.Cars.Remove(car);
            var deleted = await dataContext.SaveChangesAsync();
            
            return deleted > 0;
        }
    }
}
