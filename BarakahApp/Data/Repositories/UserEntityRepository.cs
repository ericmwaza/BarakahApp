using BarakahApp.Entities;

namespace BarakahApp.Data.Repositories
{
    public class UserEntityRepository : BaseRepository<UserEntity>, IUserEntityRepository
    {
        public UserEntityRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
    public interface IUserEntityRepository : IBaseRepository<UserEntity> { }
}
