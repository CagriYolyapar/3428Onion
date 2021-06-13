using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {

        //Burada DependencyInjection'a IRepository sokmak bütün class'ların ortak metotlarına ulasabilmek derken, ICategoryRepository sokmak hem bütün classlar'ın Ortak veritabanı metotlarına hem de sadece Category Class'ının kendine özgü metotlarına da ulasım saglar...

        #region CategorySpesifikMetotKullanimi
        //Eger spesifik bir şekilde Category class'ına has bir metodunuz varsa o zaman o metodun kullanılabilmesi icin ICategoryRepository şeklinde bir kullanıma yönelmelisiniz...


        //ICategoryRepository _crep;

        //public CategoryManager(ICategoryRepository crep):base(crep)
        //{
        //    _crep = crep;
        //} 
        #endregion




        public CategoryManager(IRepository<Category> cRep) : base(cRep)
        {
           

        }

        public override string Add(Category item)
        {


            if (item.CategoryName != null)
            {
                _iRep.Add(item);
                return "Kategori eklendi";
            }
            return "Kategori ismi girilmemiş";
        }

    }
}
