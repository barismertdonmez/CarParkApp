using Business.Abstract;
using Data.Abstract;
using Data.DataModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarRepository _carRepository;
        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void Create(Car entity)
        {
            _carRepository.Create(entity);
        }

        public void CreateCarType(CreateCarTypeDataModel model)
        {
            _carRepository.CreateCarType(model);
        }

        public void CreateCarWithCarType(CreateCarDataModel model, int cTypeId)
        {
            _carRepository.CreateCarWithCarType(model, cTypeId);
        }

        public void Delete(Car entity)
        {
            _carRepository.Delete(entity);
        }

        public void DeleteCarTypeById(int id)
        {
            _carRepository.DeleteCarTypeById(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public List<CarType> GetAllCarTypes()
        {
            return _carRepository.GetAllCarTypes();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public List<Car> GetCarsWithModels()
        {
            return _carRepository.GetCarsWithModels();
        }

        public CarType GetCarTypeById(int id)
        {
            return _carRepository.GetCarTypeById(id);
        }

        public void Update(Car entity)
        {
            _carRepository.Update(entity);
        }

        public void UpdateCartType(CreateCarTypeDataModel model)
        {
            _carRepository.UpdateCartType(model);
        }
    }
}
