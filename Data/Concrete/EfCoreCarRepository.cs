using Data.Abstract;
using Data.DataModel;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class EfCoreCarRepository : EfCoreGenericRepository<Car, CarParkContext>, ICarRepository
    {
        public void CreateCarType(CreateCarTypeDataModel model)
        {
            using (var context = new CarParkContext())
            {
                var entity = new CarType()
                {
                    CarTypeName = model.CarTypeName,
                };
                context.Add(entity);
                context.SaveChanges();
                
            }
        }

        public void CreateCarWithCarType(CreateCarDataModel model, int cTypeId)
        {
            using (var context = new CarParkContext())
            {
                var entity = new Car()
                {
                   Id = model.Id,
                   CarTypeId = cTypeId,
                   Plate = model.Plate,
                   EnterTime = DateTime.Now,
                };
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteCarTypeById(int id)
        {
            using (var context = new CarParkContext())
            {
                var cType = context.carTypes
                                   .Where(c => c.Id == id)
                                   .FirstOrDefault();
                context.Remove(cType);
                context.SaveChanges();
            }
        }

        public List<CarType> GetAllCarTypes()
        {
            using (var context = new CarParkContext())
            {
                var cType = context.carTypes;
                return cType.ToList();
            }
        }

        public List<Car> GetCarsWithModels()
        {
            using (var context = new CarParkContext())
            {
                var car = context.cars
                                 .Include(c => c.CarType);
                return car.ToList();
            }
        }

        public CarType GetCarTypeById(int id)
        {
            using (var context = new CarParkContext())
            {
                return context.carTypes
                              .Where (c => c.Id == id)
                              .FirstOrDefault();
            }
        }

        public void UpdateCartType(CreateCarTypeDataModel model)
        {
            using (var context = new CarParkContext())
            {
                var entity = new CarType()
                {
                    Id = model.Id,
                    CarTypeName = model.CarTypeName,
                };
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
