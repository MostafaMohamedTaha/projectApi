using core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace repo.data.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        #region config

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region prop

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PictureUrl).IsRequired();
            #endregion

            #region foreign key

            builder.HasOne(p => p.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany()
              .HasForeignKey(p => p.ProductTypeId);

            #endregion
        }
        #endregion
    }

}