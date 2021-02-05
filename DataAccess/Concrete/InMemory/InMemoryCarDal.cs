using DataAccess.Abstract;
using Entities.Concrete;
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
               new Car{CarId=1,BrandId=1,ColorId=2,ModelYear= "1984",DailyPrice=10000,Description="hurda :)"},
               new Car{CarId=2,BrandId=1,ColorId=1,ModelYear="2000",DailyPrice=50000,Description="hareket ediyor :)"},
               new Car{CarId=3,BrandId=2,ColorId=2,ModelYear="2010",DailyPrice=700000,Description="ilk araba için ideal:)"},
               new Car{CarId=4,BrandId=2,ColorId=1,ModelYear="2011",DailyPrice=80000,Description="4 tekeri var :)"},
               new Car{CarId=5,BrandId=3,ColorId=3,ModelYear="2002",DailyPrice=60000,Description="doktordan temiz :)"},
               new Car{CarId=6,BrandId=3,ColorId=4,ModelYear="2007",DailyPrice=65000,Description="ayağımı yerden kesse yeter :)" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public bool Any(Expression<Func<Car, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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

        public Car GetById(int CarId)
        {
            return _cars.FirstOrDefault(c => c.CarId == CarId);
        }

        public Car GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public object Select(Expression<Func<Car, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
