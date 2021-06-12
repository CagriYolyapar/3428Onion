using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.MAP.Configurations
{
    public class AppUserConfiguration: BaseConfiguration<AppUser>
    {

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            //Bizim AppUser class'ımızın bizim yazdığımız property'lerin yanı sıra Microsoft'un Identity kütüphanesinden gelen property'leri de vardır...Identity'den gelen bu property'lerin icerisinde primary key olan ve Id ismine sahip olan bir property daha olacaktır...Dolayısıyla bu class tabloya cevrilirken hem bizim ID property'mizii hem de Identity'nin gönderdigi Id property'si Sql'deki Incasesensitive durum yüzünden aynı sütun sayılarak size migration durumunda bir tabloda aynı isimde iki sütun olmaz diye hata cıkaracaktır...Dolayısıyla bizim burada ID'imiz C#'ta kalsa da biz onu (kendi ID'imizi) Sql'e göndermememiz gerekecektir...

            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID); //birebir ilişki ayarımız icin talimat
            builder.Ignore(x => x.ID);

        }


    }
}
