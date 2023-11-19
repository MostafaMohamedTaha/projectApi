using core.entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace repo.data
{
    public class Context : DbContext
    {
        #region ctor

        public Context(DbContextOptions<Context> options) : base(options) { }
        #endregion

        #region set
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        #endregion

        #region on create
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region fluent api
            //modelBuilder.ApplyConfiguration(new ProductConfiguration()); //custom
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion
        }
        #endregion
    }
}
