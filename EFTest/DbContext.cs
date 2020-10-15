using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFTest
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(x=> typeof(IEntityBase).IsAssignableFrom(x.ClrType)))
            {
                string entityName = entityType.ClrType.Name;

                var pk = entityType.FindPrimaryKey();
                foreach (var pkProperty in pk.Properties)
                {
                    pkProperty.SetColumnName($"{pkProperty.Name}");
                }


                //foreach (var property in entityType.GetProperties())
                //{
                //    var columnName = property.SqlServer().ColumnName;
                //    if (columnName.Length > 30)
                //    {
                //        throw new InvalidOperationException("Column name is greater than 30 characters - " + columnName);
                //    }
                //}
            }

            
        }
    }

    
}
