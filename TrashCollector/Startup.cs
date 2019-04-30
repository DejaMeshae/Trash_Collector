using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrashCollector.Models;

[assembly: OwinStartupAttribute(typeof(TrashCollector.Startup))]
namespace TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup i am creating first Employee Role and creating a default Employee User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Employee rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Employee user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "John";
                user.Email = "John@gmail.com";

                string userPWD = "A@Z200711";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }

                // creating Creating Manager role    
                if (!roleManager.RoleExists("Employee"))
                {
                    var thing = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Employee";
                    roleManager.Create(role);
                }

                // creating Creating Employee role    
                if (!roleManager.RoleExists("Customer"))
                {
                    var thing = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    thing.Name = "Customer";
                    roleManager.Create(role);

                }
            }
        }
    }
}