using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using Entity.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //AllTest();
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.CarName);
            }
        }

        private static void AllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car newCar = new Car();
            newCar.BrandId = 9;
            newCar.ColorId = 1;
            newCar.DailyPrice = 0;
            carManager.Add(newCar);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Marka ID : " + car.BrandId + " Model : " + car.ModelYear + " Fiyat : " + car.DailyPrice + " Açıklama : " + car.Descriptions);
            }

            Console.WriteLine("\nMarka ID : 2 için Listeleme");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Marka ID : " + car.BrandId + " Model : " + car.ModelYear + " Fiyat : " + car.DailyPrice + " Açıklama : " + car.Descriptions);
            }
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka ID : " + brand.Id + " Model : " + brand.BrandName);
            }
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Marka ID : " + color.Id + " Model : " + color.ColorName);
            }
        }
    }
}