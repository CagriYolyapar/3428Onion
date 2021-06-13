using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _iRep;

        public BaseManager(IRepository<T> irep)
        {
            _iRep = irep;
        }

        public virtual string Add(T item)
        {
            if (item.CreatedDate!=null)
            {
                _iRep.Add(item);
                return "Ekleme basarılı";
            }
            return "Ekleme tarihi kısmında sorunla karsılasıldı";
        }

        public void AddRange(List<T> list)
        {
            _iRep.AddRange(list);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
           return _iRep.Any(exp);
        }

        public void Delete(T item)
        {
            _iRep.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Destroy(T item)
        {
            throw new NotImplementedException();
        }

        public void DestroyRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public List<T> GetActives()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetFirstData()
        {
            throw new NotImplementedException();
        }

        public T GetLastData()
        {
            throw new NotImplementedException();
        }

        public List<T> GetModifieds()
        {
            throw new NotImplementedException();
        }

        public List<T> GetPassives()
        {
            throw new NotImplementedException();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            throw new NotImplementedException();
        }

        public object SelectViaClass<X>(Expression<Func<T, X>> exp)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}
