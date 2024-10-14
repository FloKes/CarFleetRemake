using CarFleet.Contracts.V1;
using CarFleet.Contracts.V1.Requests;
using CarFleet.Contracts.V1.Responses;
using CarFleet.Domain;
using CarFleet.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarFleet.Controllers.V1
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet(ApiRoutes.Cars.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await carService.GetCarsAsync());
        }

        [HttpPut(ApiRoutes.Cars.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid carId, UpdateCarRequest request)
        {
            var car = new Car
            {
                Id = carId,
                Name = request.Name,
                Engine = request.Engine,
            };

            var updated = await carService.UpdateCarAsync(car);

            if (updated)
                return Ok(car);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Cars.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid carId)
        {
            var deleted = await carService.DeleteCarAsync(carId);

            if (deleted)
                return NoContent();

            return NotFound(); 
        }

        [HttpGet(ApiRoutes.Cars.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid carId)
        {
            var car = await carService.GetCarByIdAsync(carId);

            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost(ApiRoutes.Cars.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCarRequest carRequest)
        {
            var car = new Car
            {
               Name = carRequest.Name,
               Engine = carRequest.Engine
            };

            if (car.Id != Guid.Empty)
                car.Id = Guid.NewGuid();

            await carService.CreateCarAsync(car);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Cars.Get.Replace("{carId}", car.Id.ToString());

            var response = new CarResponse 
            {
                Id = car.Id,
                Name = car.Name,
                Engine = car.Engine
            };
            return Created(locationUri, response);
        }
    }
}
