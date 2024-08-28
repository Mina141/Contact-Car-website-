using Grade_Project_.Models;
using Grade_Project_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grade_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Car_ImagesController : ControllerBase
    {
        ICar_Images car_Images;
        public Car_ImagesController(ICar_Images car_Images)
        {
            this.car_Images = car_Images;
        }

        [HttpGet]
        public IActionResult Get_Images()
        {
            return Ok(car_Images.GetAll());
        }
        [HttpGet("/id/{id:int}",Name ="FindbyId")]
        public IActionResult GetById(int id)
        {
            return Ok(car_Images.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(Car_Images _Images)
        {
            if (ModelState.IsValid) { 
            car_Images.Insert(_Images);
            return Created(Url.Link("FindbyId",new {id=_Images.ID}),_Images );
        
            }
            return BadRequest("Data Not Valid");

        }
        [HttpPut]
        public IActionResult Update(int id , Car_Images _Images)
        {
            if (ModelState.IsValid) { 
            car_Images.Edit(id, _Images);
            return StatusCode(StatusCodes.Status204NoContent, "Data saved");
            }
            return BadRequest("Data Not Valid");

        }
        [HttpDelete]
        public IActionResult Remove_Image(int id)
        {
            car_Images.Delete(id);
            return Ok(StatusCodes.Status200OK);

        }
    }
}
