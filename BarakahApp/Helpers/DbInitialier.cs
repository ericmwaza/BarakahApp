using BarakahApp.Data.Repositories;
using BarakahApp.Entities;
using BarakahApp.Enumerations;
using BarakahApp.Services;
using System;
using System.Threading.Tasks;

namespace BarakahApp.Helpers
{
    public class DbInitialier
    {
        private static IUserService _userService;

        public DbInitialier(IUserService userService)
        {
            _userService = userService;
        }
        public  async Task SeedData()
        { 
            await SeedUsers();
        }
        private  async Task SeedUsers()
        {
            var user = new UserEntity
            {
                FirstName = "Admin",
                Email = Startup.Configuration.GetSection("AdminSettings")["Email"],
                Role = UserRole.Admin,
                UploadDate = DateTime.Now
            };
            var password = Startup.Configuration.GetSection("AdminSettings")["Password"];
            await _userService.Create(user,password);
        }
    }
}
