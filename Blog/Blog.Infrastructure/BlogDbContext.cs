using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class BlogDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public BlogDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = new Guid("DE58C8A3-2B90-4B86-ABFE-3A31E9F2BD05"),
                Name = "General",

            });
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
