using Core;
using Core.Service;
using DataAccess.Context;
using DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {
        //ECommerceContext db = new ECommerceContext();
        ECommerceContext context = DbContextSingleton.Context;

        public void ProductCount(string categoryName)
        {
            context.Products.SqlQuery(@"{ select COUNT(*) from Products p join SubCategories s on p.SubCategoryId = s.ID join Categories c on c.ID = s.CategoryId where c.CategoryName = "+categoryName+" }");
            
        }
        public string Add(T model)
        {

            try
            {
                model.ID = Guid.NewGuid();
                context.Set<T>().Add(model);
                context.SaveChanges();
                return "veri eklendi!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Add(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Any(exp);
        }

        public string Delete(Guid id)//2
        {
            try
            {
                T deleted = GetById(id);
                deleted.Status = Core.Enums.Status.Deleted;
                Update(deleted);
                return "veri silindi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public string RemoveForce(T model)
        {
            try
            {
                context.Set<T>().Remove(model);
                return "veri kalıcı olarak silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Update(T model)
        {

            try
            {
                T updated = GetById(model.ID);
                context.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return $"{model.ID} nolu veri güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
