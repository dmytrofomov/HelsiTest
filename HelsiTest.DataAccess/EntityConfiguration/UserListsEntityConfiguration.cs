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
    public sealed class UserListsEntityConfiguration : BaseEntityTypeConfiguration,
                                                    IEntityTypeConfiguration<UserListEntity>
    {
        public void Configure(EntityTypeBuilder<UserListEntity> entityBuilder)
        {
            entityBuilder.ToTable("userlists");

            AddDefaultColumns(entityBuilder);

            entityBuilder.Property(e => e.UserId).HasColumnName("user_id");
            entityBuilder.Property(e => e.ListId).HasColumnName("list_id");

            // Indexes :
            entityBuilder.HasIndex(e => new { e.ListId, e.UserId }).IsUnique();

            entityBuilder.HasOne(ue => ue.User)
                .WithMany(u => u.UserLists)
                .HasForeignKey(u => u.UserId);

            entityBuilder.HasOne(ue => ue.List)
                .WithMany(ue => ue.ListUsers)
                .HasForeignKey(u => u.ListId);

        }
    }
}