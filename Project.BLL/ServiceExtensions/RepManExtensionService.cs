using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    public static class RepManExtensionService
    {
        public static IServiceCollection AddRepManServices(this IServiceCollection services)
        {
            //Repositories
            //Transient,Scoped,Singleton => Dependency Injection calısırken ilgili class'ların instance'larının ne şekilde alınacağını belirleyen yapılardır...


            //Services kısmında AddSingleton metodu size Singleton Pattern ile belirlediginiz sınıfı sunar...Proje kapanana kadar ilgili instance Ram'de kalır,yeni bir tane yaratılmaz var olan kullanılır...


            //Scoped => Services kısmında AddScoped kullanılır ise bir Request icin sadece bir instance alınması saglanır...Ancak farklı request'lerde farklı instance alınır....


            /*
             
             public Category(ICategoryRepository catRep,ICategoryRepository catRep2)
            {
            }
             
             public IActionResult Deneme(ICategoryRepository catRep)
            {
            }

            public IActionResult Deneme2(){}
             


            //Transient => Services kısmında Transient'e eklenen her tip projede her görüldüğü anda instance'i alınabilecek bir hale gelir


             */

            //Repositories

            //BaseRepository'nin kesinlikle Abstract olmamalı..Yoksa Dependency Injection BaseRepository'nin instance'ini alamaz ve ilgili Interface'e gönderemez...
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            //Managers
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ISpecialUserManager, SpecialUserManager>();
            services.AddScoped<IProfileManager, ProfileManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();

            return services;


        }
    }
}
