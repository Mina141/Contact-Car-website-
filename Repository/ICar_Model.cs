using Grade_Project_.DTO;
using Grade_Project_.Models;

namespace Grade_Project_.Repository
{
    public interface ICar_Model
    {
        void Insert(ModelWithBrandDTO C);
        void Edit(int id, Car_Model car);
        void Delete(int id);
        Car_Brand getBrandID(string brand);
        List<ModelWithBrandDTO> GetAll();
        ModelWithBrandDTO GetById(int id);
        ModelWithBrandDTO GetByName(string n);
    }
}
