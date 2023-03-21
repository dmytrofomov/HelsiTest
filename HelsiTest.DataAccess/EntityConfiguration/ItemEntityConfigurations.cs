using DbProject.EntityConfiguration;
using HelsiTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelsiTest.Infrastructure.DataAccess.EntityConfiguration
{
    public sealed class ItemEntityConfigurations : BaseEntityTypeConfiguration,
                                                IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> entityBuilder)
        {
            entityBuilder.ToTable("items");

            AddDefaultColumns(entityBuilder);

            // Properties :
            entityBuilder.Property(e => e.Text).HasColumnName("text").HasMaxLength(500);

            // Indexes :

            entityBuilder.HasOne(ue => ue.List)
                .WithMany(u => u.Items)
                .HasForeignKey(u => u.ListId);
        }
    }
}
