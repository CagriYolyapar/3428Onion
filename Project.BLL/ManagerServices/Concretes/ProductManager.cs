using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        public ProductManager(IRepository<Product> prep):base(prep)
        {

        }

        //Kalan Manager'lar hem kendi metotları yoksa en efektif nasıl kullanılır hem de kendi metotlarına sahiplerse nasıl kullanılmaları gerekir Syntax'larini olusturan bir Manager System

        //IProductRepository _proRep;

        //public ProductManager(IProductRepository proRep):base(proRep)
        //{
        //    _proRep = proRep;
        //}

        public override string Add(Product item)
        {
            if (item.UnitPrice<500)
            {
                return "Fiyat konusunda giriş sıkıntısı var...Fiyat 500'den kücük olamaz";
            }
            _iRep.Add(item);
            return "Ekleme basarılı";
        }

    }
}
