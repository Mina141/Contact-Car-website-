using Grade_Project_.DTO;
using Grade_Project_.Models;

namespace Grade_Project_.Repository
{
    public interface ICar
    {
        List<Car> GetAllforUser();
        List<Car> GetAllforAdmin();
        List<string> GetImagesById(int id);
        Car GetById(int id);
        void Insert(CarWithBrandAndModelDataDto car);
        void Edit(int id, CarWithBrandAndModelDataDto car);
        void Delete(int id);
        List<Car> GetUsedCars();
        List<Car> GetNewCars();
        List<Car> GetCarsByBrand(string brand);
        List<Car> GetCarsByModel(string model);
        List<Car> GetCarsByMadeYear(int year);
        List<Car> GetCarsByTransmission(string type);
        List<CarWithBrandAndModelDataDto> customizedCars(List<Car> cars);
        List<Users> getAllUsers();

    }
}
