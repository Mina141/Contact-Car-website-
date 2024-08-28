using Grade_Project_.DTO;
using Grade_Project_.Models;
using Grade_Project_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grade_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        ICar carRepository;
        public AdminController(ICar carRepository)
        {
            this.carRepository = carRepository;
        }
        [HttpGet("getAllcars")]
        public IActionResult getAllCars()
        {
            List<Car> cars = carRepository.GetAllforAdmin();
            List<carsForAdminDto> carsForAdmin = new List<carsForAdminDto>();
            for (int i = 0; i < cars.Count; i++)
            {
                carsForAdminDto c1 = new carsForAdminDto();
                c1.Price = cars[i].Price;
                c1.Mileage = cars[i].Mileage;
                c1.Made_Year = cars[i].Made_Year;
                c1.Engine_Capacity = cars[i].Engine_Capacity;
                c1.Transmission = cars[i].Transmission;
                c1.Car_Address = cars[i].Car_Address;
                c1.Description = cars[i].Description;
                c1.Car_Brand_Name = cars[i].Car_Brand.Brand_Name;
                c1.Car_Model_Name = cars[i].Car_Model.Model_Name;
                c1.Is_Approved = cars[i].Is_Approved;
                if (cars[i].Is_Used == true)
                {
                    c1.Status = "Used";
                }
                else
                {
                    c1.Status = "New";
                }
                carsForAdmin.Add(c1);
            }

            return Ok(carsForAdmin);
        }
        [HttpGet("getallUsers")]
        public IActionResult getAllusers()
        {
            List<Users> users = carRepository.getAllUsers();
            List<usersForAdminDto> userForAdmin = new List<usersForAdminDto>();
            for (int i = 0; i < users.Count; i++)
            {
                usersForAdminDto c1 = new usersForAdminDto();
                c1.UserName = users[i].UserName;
                c1.Email = users[i].Email;
                c1.Address = users[i].User_Address;
                c1.password = users[i].PasswordHash;
                c1.PhoneNumber = users[i].PhoneNumber;
                c1.Is_Active = users[i].Is_Active;

                userForAdmin.Add(c1);
            }
            return Ok(userForAdmin);
        }
    }
}
