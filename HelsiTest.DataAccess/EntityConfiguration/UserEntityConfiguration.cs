using DbProject.EntityConfiguration;
using HelsiTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelsiTest.Infrastructure.DataAccess.EntityConfiguration;

public sealed class UserEntityConfiguration : BaseEntityTypeConfiguration,
                                                IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> entityBuilder)
    {
        entityBuilder.ToTable("users");

        AddDefaultColumns(entityBuilder);

        // Properties :
        entityBuilder.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);

        // Indexes :
        entityBuilder.HasIndex(e => e.Name);

    }
}