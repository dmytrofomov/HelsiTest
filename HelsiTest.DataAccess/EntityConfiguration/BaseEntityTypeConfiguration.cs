using HelsiTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.EntityConfiguration
{
    public class BaseEntityTypeConfiguration
    {
        public static void AddDefaultColumns<T>(EntityTypeBuilder<T> entity)
        where T : BaseEntity
        {
            entity.Property(e => e.Id).HasColumnName("id").IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("getdate()").IsRequired(); 

            entity.HasKey(e => e.Id);
        }
    }
}
