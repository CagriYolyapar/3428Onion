using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using Project.MAP.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Context
{
    //Eger kurmak istediginiz Veritabanı yapısında Identity kullanacaksanız DbContext'ten miras alamazsınız... Cünkü Identity kendi tablolarını tamamen hazır bir yapıda sunabilmesi adına sizi IdentityDbContext'ten miras almaya yönlendirir....

    //Burada IdentityDbContext'e generic yapı olarak vereceğiniz sınıfın IdentityUser'dan miras alması gerekir(Eger siz o sınıfı Identity'nin kendi sınıfıyla birleştirmek istiyorsanız)
    public class MyContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {

        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProfileConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }


    }
}
