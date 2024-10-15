using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
