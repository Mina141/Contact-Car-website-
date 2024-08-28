using Grade_Project_.DTO;
using Grade_Project_.Models;
using Grade_Project_.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grade_Project_.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CarController : ControllerBase
    {
        ICar carRepository;
        public CarController(ICar carRepository)
        {
            this.carRepository = carRepository;
        }
        [HttpGet]
        public IActionResult AllCars()
        {
            List<Car> cars = carRepository.GetAllforUser();
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }

        [HttpGet]
        [Route("{id:int}", Name = "FindCarByIdRoute")]  //{name:alpha} this for string or ("id/{id}") to avoid ambiguous
                                                        //[Route("{id:int}/{age:int}")] for two parameter
                                                        //[HttpGet("{id:int}")] instead of httpget and route 
        public IActionResult FindCar(int id)
        {
            Car car = carRepository.GetById(id);
            if (car == null)
            {
                return BadRequest("Id Not Found");
            }

            CarWithBrandAndModelDataDto c1 = new CarWithBrandAndModelDataDto();
            c1.Id = car.ID;
            c1.Price = car.Price;
            c1.Mileage = car.Mileage;
            c1.Made_Year = car.Made_Year;
            c1.Engine_Capacity = car.Engine_Capacity;
            c1.Transmission = car.Transmission;
            c1.Car_Address = car.Car_Address;
            c1.Car_Brand_Name = car.Car_Brand.Brand_Name;
            c1.Car_Model_Name = car.Car_Model.Model_Name;
            c1.Is_Available=car.Is_Available;
            c1.UserId = car.User_Id; 
            return Ok(c1);
        }
        [HttpPost]
        public IActionResult Add(CarWithBrandAndModelDataDto car)
        {
            if (ModelState.IsValid)
            {
                carRepository.Insert(car);
                //string url = "http://localhost:5278/api/Car/" + car.ID;
                string url = Url.Link("FindCarByIdRoute", new { id = car.Id });
                return Created(url, car);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CarWithBrandAndModelDataDto car)
        {
            Car oldcar = carRepository.GetById(id);
            if (oldcar != null)
            {

                if (ModelState.IsValid)
                {
                    carRepository.Edit(id,car);
                    return StatusCode(StatusCodes.Status204NoContent, "Data Saved");

                }
                return BadRequest("Data Not Valid ");
            }
            return BadRequest("Data Not Valid ");

        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveCar(int id)
        {
            Car car = carRepository.GetById(id);
            if (car != null)
            {
                carRepository.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent, "Remove Done");

            }
            return BadRequest("Data Not Valid ");

        }
        [HttpGet("/usedcars")]
        public IActionResult GetUsedCars()
        {
            List<Car> cars = carRepository.GetUsedCars();
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }

        [HttpGet("/newcars")]
        public IActionResult GetNewCars()
        {
            List<Car> cars = carRepository.GetNewCars();
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }

        [HttpGet("/byBrand")]
        public IActionResult GetCarsByBrand(string brand)
        {
            List<Car> cars = carRepository.GetCarsByBrand(brand);
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }

        [HttpGet("/byModel")]
        public IActionResult GetCarsByModel(string Model)
        {
            List<Car> cars = carRepository.GetCarsByModel(Model);
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }
        [HttpGet("/byMadeYear")]
        public IActionResult GetCarsByMadeYear(int year)
        {
            List<Car> cars = carRepository.GetCarsByMadeYear(year);
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }
        [HttpGet("GetImagesId")]

        public IActionResult GetImagesId(int carid)
        {
            var car = carRepository.GetImagesById(carid);

            return Ok(car);
        }

        [HttpGet("/ByTransmission")]
        public IActionResult GetCarsByTransmission(string type)
        {
            List<Car> cars = carRepository.GetCarsByTransmission(type);
            List<CarWithBrandAndModelDataDto> customCars = carRepository.customizedCars(cars);
            return Ok(customCars);
        }
    }
}
