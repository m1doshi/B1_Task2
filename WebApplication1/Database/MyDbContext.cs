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
            //Регистрация сущностей для работы с ними    
        public DbSet<ClassEntity> Classes { get; set; } 
        public DbSet<NewAccountEntity> Accounts { get; set; }  
        public DbSet<OutgoingSaldoEntity> OutgoingSaldos { get; set; }  
        public DbSet<IncomingSaldoEntity> IncomingSaldos { get; set; }
        public DbSet<TurnoverEntity> Turnovers { get; set; }
        public DbSet<FileInfoEntity> FileInfos { get; set; }
    }
}
