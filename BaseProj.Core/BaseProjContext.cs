using BaseProj.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseProj.Core
{
    public class BaseProjContext : DbContext
    {
        public BaseProjContext(DbContextOptions<BaseProjContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
