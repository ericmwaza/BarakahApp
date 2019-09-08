using BarakahApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarakahApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}
