using BarakahApp.Enumerations;

namespace BarakahApp.Entities
{
    public class UserEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
