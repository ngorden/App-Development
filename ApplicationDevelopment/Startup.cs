using ApplicationDevelopment.DAL;
using ApplicationDevelopment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(ApplicationDevelopment.Startup))]
namespace ApplicationDevelopment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedData().Wait();
        }
        #region setupDatabase
        private async Task SeedData()
        {
            using var context = new ApplicationDbContext();
            using var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            using var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!await roleManager.RoleExistsAsync("manager"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "manager" });
                var user = new ApplicationUser
                {
                    Email = "johnsmith@gmail.com",
                    EmailConfirmed = true,
                    UserName = "johnsmith"
                };
                var chkusr = await userManager.CreateAsync(user, "AppDev1!");
                if (chkusr.Succeeded) await userManager.AddToRoleAsync(user.Id, "manager");
            }

            using var db = new BakeryContext();
            var countProducts = db.Products.ToList().Count;
            if (countProducts == 0)
            {
                db.Products.Add(new Product() { Name = "Cake Balls", Description = "1\" ball of moist guooey cake dough dipped in melted frosting" });
                await db.SaveChangesAsync();
            }
        }
        #endregion
    }
}
