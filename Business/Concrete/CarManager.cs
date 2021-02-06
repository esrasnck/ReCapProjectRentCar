using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddACar(Car car)
        {
     

                if (car.Description.Length < 2)
                {
                    Console.WriteLine("Araba açıklaması minimum 2 karakter olmalıdır.");
                }
                else if (car.DailyPrice <= 0)
                {
                    Console.WriteLine(" ve Ürün fiyatı 0'dan büyük olmalıdır.");
                }
                else
                {
                    _carDal.Add(car);
                    Console.WriteLine("Eklenme başarılı");
                }
           
         


        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int id)
        {
            return _carDal.GetAll(x => x.BrandId == id);
        }


        public List<Car> GetByColorId(int id)
        {
            return _carDal.GetAll(x => x.ColorId == id);
        }

        public Car GetByCarId(int id)
        {
            return _carDal.GetByID(id);
        }
    }
}
