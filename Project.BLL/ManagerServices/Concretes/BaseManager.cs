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
            _iRep.DeleteRange(list);
        }

        public void Destroy(T item)
        {
            _iRep.Destroy(item);
        }

        public void DestroyRange(List<T> list)
        {
            _iRep.DestroyRange(list);
        }

        public T Find(int id)
        {
            return _iRep.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _iRep.FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return _iRep.GetActives();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public T GetFirstData()
        {
            return _iRep.GetFirstData();
        }

        public T GetLastData()
        {
            return _iRep.GetLastData();
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp);
        }

        public object SelectViaClass<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.SelectViaClass<X>(exp);
        }

        public string Update(T item)
        {
            if (item.CreatedDate==null)
            {
                return "Olusturulma tarihinde sıkıntı var...Güncelleme iptal edildi";
            }
             _iRep.Update(item);
            return "Güncelleme basarılı";
        }

        public void UpdateRange(List<T> list)
        {
            _iRep.UpdateRange(list);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }
    }
}
