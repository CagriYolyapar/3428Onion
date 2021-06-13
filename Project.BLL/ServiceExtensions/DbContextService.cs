using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    //DbContextPool'umuz böylece StartUp'da DAL'deki bir class'i kullanmadan, sadece BLL'de bu class'ı kullanarak entegre edilecek... Bu sınıfımızın amacı DbContext servisimizi UI'i DAL'e bulastırmadan entegre etmektir...
    public static class DbContextService
    {
        //BU tarz katman bagımsız servis Dependency Injection'larında servislerin icerisine entegre edebileceginiz bir yapı kurmak icin IServiceCollection tipinden yararlanırsınız...

        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            //Sakın IConfiguration kullanırken Castle kütüphanesini kullanmayın..Kullanacagınız kütüphane Microsoft.Extensions.Configurations olmak zorundadır...
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
            return services;
        }
    }
}
