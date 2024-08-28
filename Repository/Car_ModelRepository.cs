using Grade_Project_.Models;
using Microsoft.EntityFrameworkCore;
using Grade_Project_.DTO;

namespace Grade_Project_.Repository
{
    public class Car_ModelRepository : ICar_Model
    {
        Cars_Entity context = new Cars_Entity();

        

        public List<ModelWithBrandDTO> GetAll()
        {
            var c = context.Car_Models.Include(e => e.Car_Brand).
                  Select(e => new ModelWithBrandDTO()
                  {
                      
                      Model_Name = e.Model_Name,
                      Model_Icon = e.Model_Icon,
                      CarBrand_Name =e.Car_Brand.Brand_Name ,
                      
                  }


              ).ToList();
            ;
            return c;
        }
        public Car_Brand getBrandID(string brand)
        {
            return context.Cars_Brands.FirstOrDefault(x => x.Brand_Name == brand);
        }
        public ModelWithBrandDTO GetById(int id)
        {

            Car_Model C = context.Car_Models.Include(e => e.Car_Brand)

                 .FirstOrDefault(d => d.Id == id);

            

            ModelWithBrandDTO DTO = new ModelWithBrandDTO();
            DTO.Model_Name = C.Model_Name;
            DTO.Model_Icon = C.Model_Icon;
            DTO.CarBrand_Name=C.Car_Brand.Brand_Name;
            //Car_Brand Brand = getBrandID(DTO.CarBrand_Name);

            //Brand.Id= C.CarBrand_Id;

            return DTO;


        }


        public ModelWithBrandDTO GetByName(string name)
        {
            // return context.Car_Models.FirstOrDefault(d => d.Model_Name == name);
            Car_Model C = context.Car_Models.Include(e => e.Car_Brand).FirstOrDefault(d => d.Model_Name == name);



            ModelWithBrandDTO DTO = new ModelWithBrandDTO();
            DTO.Model_Name = C.Model_Name;
            DTO.Model_Icon = C.Model_Icon;
            DTO.CarBrand_Name = C.Car_Brand.Brand_Name;

            return DTO;
        }

        public void Insert(ModelWithBrandDTO modeles)
        {
            Car_Model n = new Car_Model();
            n.Model_Name = modeles.Model_Name;
            n.Model_Icon = modeles.Model_Icon;

            Car_Brand Brand = getBrandID(modeles.CarBrand_Name);
            n.CarBrand_Id = Brand.Id;

            context.Car_Models.Add(n);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Car_Model oldModel = context.Car_Models.FirstOrDefault(d => d.Id == id);

            context.Car_Models.Remove(oldModel);
            context.SaveChanges();
        }

        public void Edit(int id, Car_Model NewModel)
        {
            Car_Model oldModel = context.Car_Models.FirstOrDefault(d => d.Id == id);

            oldModel.Id = NewModel.Id;
            oldModel.Model_Name = NewModel.Model_Name;
            oldModel.Model_Icon = NewModel.Model_Icon;
            context.SaveChanges();
        }

    }
}
