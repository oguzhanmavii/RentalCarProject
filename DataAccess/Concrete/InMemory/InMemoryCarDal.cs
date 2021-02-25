using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId =1, ModelYear = 2011, DailyPrice = 110000, Descriptions = "Hatchback"},
                new Car{Id = 2,BrandId = 1, ModelYear = 2013, DailyPrice = 90000, Descriptions = "Hatchback"},
                new Car{Id = 3,BrandId = 2, ModelYear = 2019, DailyPrice = 225000, Descriptions = "Sedan"},
                new Car{Id = 4,BrandId = 2, ModelYear = 2021, DailyPrice = 425000, Descriptions = "SUV"},
                new Car{Id = 5,BrandId = 3, ModelYear = 2016, DailyPrice = 575000, Descriptions = "Super Car"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // LINQ
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }
}
