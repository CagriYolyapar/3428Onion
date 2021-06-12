using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ENTITIES.Models
{
    //Asagıdaki yapı Identity ile birleşecek bir yapıdır...Normal şartlarda Identity kütüphanesi kullanıldığında tüm kullanıcı sınıfları, roller,yetkiler hazır gelmektedir...Ancak bu hazır gelen kullanıcı sınıfı sizin istediginiz ayrı bir property kümesine sahip olacaksa o zaman siz Identity'i saf bir şekilde miras alıp kullanmaktansa kendiniz Identity sınıfı ile birleşmesini düşündüğünüz sınıfınızı açıp o sınıfa Identity'den miras vermelisiniz...(Normal şartlarda sadece Context sınıfınız Identity'den miras alır)...

    //Sizin sınıfınız Identity sınıfından generic olmayan bir şekilde miras alırsa Identity kütüphanesi ilgili sınıfların primary key'ini nvarchar tipinde acar... (Normal şartlarda Identity yapısı bütün primary key'leri Sql'e nvarchar olarak gönderir.) Ancak siz IdentityUser'a generic olarak bir int tipi verdiginizde Identity yapısının olusturacagı tablolar int tipinde bir primary key'e sahip olacaklardır...
    public class AppUser:IdentityUser<int>,IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DataStatus? Status { get; set; }

        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
