using Data.DataModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int id);
        List<Car> GetAll();
        void Create(Car entity);
        void Update(Car entity);
        void Delete(Car entity);

        public List<Car> GetCarsWithModels();
        public List<CarType> GetAllCarTypes();
        void DeleteCarTypeById(int id);
        void CreateCarType(CreateCarTypeDataModel model);
        void UpdateCartType(CreateCarTypeDataModel model);
        CarType GetCarTypeById(int id);
        void CreateCarWithCarType(CreateCarDataModel model, int cTypeId);

    }
}
