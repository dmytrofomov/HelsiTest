using DbProject.EntityConfiguration;
using HelsiTest.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsiTest.Infrastructure.DataAccess.EntityConfiguration
{
    public sealed class ListEntityConfigurations : BaseEntityTypeConfiguration,
                                                IEntityTypeConfiguration<ListEntity>
    {
        public void Configure(EntityTypeBuilder<ListEntity> entityBuilder)
        {
            entityBuilder.ToTable("lists");

            AddDefaultColumns(entityBuilder);

            // Properties :
            entityBuilder.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);
            entityBuilder.Property(e => e.OwnerId).HasColumnName("owner_id");

            // Indexes :
            entityBuilder.HasIndex(e => e.Name);
        }
    }
}
