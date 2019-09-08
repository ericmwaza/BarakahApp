using BarakahApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarakahApp.Services
{
    public interface IUserService
    {
        UserEntity Authenticate(string email, string password);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
        Task<UserEntity> Create(UserEntity user, string password);
        Task Update(UserEntity user, string password = null);
        Task Delete(int id);
    }
}
