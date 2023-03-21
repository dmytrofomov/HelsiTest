using HelsiTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HelsiTest.Infrastructure.DataAccess.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.;Database=HelsiDb;TrustServerCertificate=True;MultipleActiveResultSets=True;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<ListEntity> Lists { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserListEntity> UserLists { get; set; }
    }
}
