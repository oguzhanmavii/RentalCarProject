using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;

        }

        public BrandManager(EfBrandDal efBrandDal)
        {
            EfBrandDal = efBrandDal;
        }

        public EfBrandDal EfBrandDal { get; }

        public void Add(Brand brand)
        {
            if(brand.BrandName.Length>=2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Araba markası başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Araba adı min 2 karakter ve üstünde olmalıdır !");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Araba Markası silindi");
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("Tüm Araba Markaları:");
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(x=>x.Id==id);
        }

        public void Update(Brand brand)
        {
            Brand brand1 = new Brand();
            brand1.Id = brand.Id;
            brand1.BrandName = brand.BrandName;

            if(brand.Id==brand1.Id)
            {
                _brandDal.Update(brand1);
                Console.WriteLine("Araba Marka adı güncellendi.");
            }

        }
    }
}
