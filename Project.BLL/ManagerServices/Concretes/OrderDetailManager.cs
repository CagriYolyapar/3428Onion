using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class OrderDetailManager:BaseManager<OrderDetail>,IOrderDetailManager
    {
        public OrderDetailManager(IRepository<OrderDetail> odRep):base(odRep)
        {

        }

        //IOrderDetailRepository _odRep;

        //public OrderDetailManager(IOrderDetailRepository odRep):base(odRep)
        //{
        //    _odRep = odRep;
        //}


    }
}
