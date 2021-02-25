using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class CarManager:ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;

        }

        public CarManager(EfCarDal efCarDal)
        {
            EfCarDal = efCarDal;
        }

        public EfCarDal EfCarDal { get; }

        public void Add(Car car)
        {
            if(car.DailyPrice>0)
            {
                _CarDal.Add(car);
                Console.WriteLine("ArabaEklendi");
            }
            else
            {
                Console.WriteLine("Araba günlük fiyati 0'dan büyük olmalıdır. kontrol ediniz !");
            }
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
            Console.WriteLine("Araba silindi");
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("Tüm Arabalar Listeleniyor...");
            return _CarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _CarDal.Get(x => x.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _CarDal.GetAll(x => x.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _CarDal.GetAll(x => x.ColorId == id);
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
            Console.WriteLine("Araba güncellendi");

        }
    }
}
