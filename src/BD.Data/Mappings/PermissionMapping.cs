using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BD.Data.Mappings
{
    public class PermissionMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder
                .Property(p => p.Type)
                .HasColumnType("varchar(60)")
                .IsRequired(true);

            builder
                .Property(p => p.Value)
                .HasColumnType("varchar(60)")
                .IsRequired(true);

            builder
              .Property(p => p.CreatedAt);

            builder
                .Property(p => p.LastUpdatedAt);

            builder
                .Property(p => p.DisabledAt)
                .IsRequired(false);

            builder
                .HasIndex(p => new { p.Type, p.Value })
                .IsUnique();

            builder.HasData(FactoryPermissionSeed());

            builder.ToTable("permissions");
        }

        public List<Permission> FactoryPermissionSeed()
        {
            List<Permission> items = null;
            using (StreamReader r = new StreamReader("Seeds/PermissionSeed.json", Encoding.UTF8))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Permission>>(json);
            }

            var permissions = new List<Permission>();
            foreach (var perm in items)
                permissions.Add(new Permission(GetId(), perm.Name, perm.Type, perm.Value));

            return permissions;
        }

        public static int _idForPermission = 1;

        public int GetId()
        {
            var id = _idForPermission;
            _idForPermission++;
            return id;
        }
    }
}
