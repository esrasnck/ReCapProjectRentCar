using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            };
        }



        public void Delete(Car entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            };
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);

            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                if (filter == null)
                {
                    return context.Set<Car>().ToList();
                }
                else
                {
                    return context.Set<Car>().Where(filter).ToList();
                }

            };
        }

        public Car GetByID(int id)
        {

            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Car>().Find(id);
            }

        }



        public void Update(Car entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            };
        }


        // benim eklediğim metotlar
        public bool Any(Expression<Func<Car, bool>> exp)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Car>().Any(exp);
            }
        }
        public object Select(Expression<Func<Car, bool>> exp)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Car>().Select(exp).ToList();
            }
        }

    }
}
