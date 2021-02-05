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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            };
        }



        public void Delete(Color entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            };
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            };
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                if (filter == null)
                {
                    return context.Set<Color>().ToList();
                }
                else
                {
                    return context.Set<Color>().Where(filter).ToList();
                }

            };
        }

        public Color GetByID(int id)
        {

            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Color>().Find(id);
            }
        }


        public void Update(Color entity)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            };
        }

        // benim eklediğim metotlar
        public object Select(Expression<Func<Color, bool>> exp)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Color>().Select(exp).ToList();
            }
        }

        public bool Any(Expression<Func<Color, bool>> exp)
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                return context.Set<Color>().Any(exp);
            }
        }


    }
}
