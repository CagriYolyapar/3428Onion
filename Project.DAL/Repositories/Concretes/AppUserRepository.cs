using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        //Sizin kendinize özel Crud işlemleriniz yine var...Ancak unutmayın ki Identity yapısının özel şifrelemeler ve yetkilendirmeleri için hazır async metotları vardır... Bu metotların kullanımı icin ekstra olarak bu Repository'de ayrı alanlar acılması en dogrusudur... Bu metotlar Identity'den gelen Manager sınıfları icerisinde bulunur(UserManager,SignInManager Identity'de gömülü olan sınıflardır). Bu sınıflar Dependency Injection ile calısırlar ve Constructor Based Injection ile entegre edilirler)...(Tabii unutmayın ki bu yapının service olarak Starup.cs'e entegre edilmeleri gerekir...

        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AppUserRepository(MyContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Özel bir Identity Metodu async şekilde tanımlanmalıdır...Cünkü Identity sonucta kendi icinde bir API kullanmaktadır...Ve Request'lerin bloklanmasını engellemek adına asenkron bir yapıda calısmaktadır...Siz o metodu kendi metodunuz icerisinde kullanmak istiyorsanız(bir catı altında toplamak istiyorsanız) sizin yaratacagınız Metot da async olmalıdır ve icerisinde await keyword'u kesinlikle kullanılmalıdır...(Siz async bir metot tanımladıgınız halde icerisinde await keyword'u kullanmazsanız bu metot beklenilen şekilde çalışmaz.) Bir metot icerisinde await keyword'u kullanabilmeniz icin o metodun async tanımlanması gerekir ve Task göndürmesi gerekir...

        public async Task<bool> AddUser(AppUser item)
        {
            //Bizim normal şartlarda Add metodumuz olsa da bu metot Identity'e özgü olan Add metodunu calıstıracaktır(Yani klasik EF Add metodunu degil)

            //Sadece Asenkron olarak yaratılmıs metotlar icinde await kullanabilirsiniz...

            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(item, isPersistent: false);//isPersisten durumu Cookie'de dursun mu durmasın mı
                return true;
            }
            return false;

        }

    }
}
