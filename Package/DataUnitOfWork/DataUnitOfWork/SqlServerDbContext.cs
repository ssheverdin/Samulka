using System.Linq;
using System.Reflection;
using DataUnitOfWork.Base;
using Microsoft.EntityFrameworkCore;

namespace DataUnitOfWork
{
    public abstract class SqlServerDbContext : DbContext
    {
        protected SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var baseType = typeof(EntityBase);
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(i => i.IsClass && i != baseType && baseType.IsAssignableFrom(i)).ToList();
            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type).HasKey("Id");
            }
            modelBuilder.EnableAutoHistory(null);

            base.OnModelCreating(modelBuilder);
        }

    }
}