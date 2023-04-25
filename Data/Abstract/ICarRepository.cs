using Data.DataModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface ICarRepository : IRepository<Car>
    {
        public List<Car> GetCarsWithModels();
        public List<CarType> GetAllCarTypes();
        void DeleteCarTypeById(int id);
        void CreateCarType(CreateCarTypeDataModel model);
        void UpdateCartType(CreateCarTypeDataModel model);
        CarType GetCarTypeById(int id);
        void CreateCarWithCarType(CreateCarDataModel model, int cTypeId);
    }
}
