using System.ComponentModel.DataAnnotations;
using System.Linq;
using Grade_Project_.DTO;
using Grade_Project_.Models;
using Grade_Project_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grade_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Car_ModelController : ControllerBase
    {

        ICar_Model Car_ModelRepository;
        public Car_ModelController(ICar_Model Car_ModelRepository)
        {

            this.Car_ModelRepository = Car_ModelRepository;

        }
        [HttpGet]
        public IActionResult GetAllModel()
        {
            List<ModelWithBrandDTO> C = (List<ModelWithBrandDTO>)Car_ModelRepository.GetAll();


            /* ModelWithBrandDTO DTO = new ModelWithBrandDTO() ;
              DTO.Model_Id = C.Select(e=>e.Id).FirstOrDefault();
              DTO.Model_Name = C.Select(e => e.Model_Name).FirstOrDefault();
              DTO.Model_Icon = C.Select(e => e.Model_Icon).FirstOrDefault();
              DTO.CarBrand_Id = C.Select(e => e.CarBrand_Id).FirstOrDefault();
              DTO.CarBrand_Name = C.Select(e => e.Model_Name).FirstOrDefault();*/
            return Ok(C);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            ModelWithBrandDTO modeles = Car_ModelRepository.GetById(id);
            if (modeles == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(modeles);
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName(string name)
        {
            ModelWithBrandDTO m = Car_ModelRepository.GetByName(name);
            if (m == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(m);

        }

        [HttpPost]

        public IActionResult Add(ModelWithBrandDTO modeles)
        {

            if (ModelState.IsValid)
            {

                Car_ModelRepository.Insert(modeles);
                return Ok(modeles);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]

        public IActionResult Update([FromRoute] int id, [FromBody] Car_Model NewModel)
        {
            if (ModelState.IsValid)
            {
                Car_ModelRepository.Edit(id, NewModel);
                return StatusCode(StatusCodes.Status204NoContent, "Data saved");
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id:int}")]

        public IActionResult Removebyid(int id)
        {

            Car_ModelRepository.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, "Data Deleted");



        }
    }
}