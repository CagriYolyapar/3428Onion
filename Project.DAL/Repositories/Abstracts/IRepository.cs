using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Abstracts
{
    //Todo:DAL Generic Repository paterni tamamlanacak...
    public interface IRepository<T> where T : IEntity
    {
        //List Commands
        void Add(T item);
    }
}
