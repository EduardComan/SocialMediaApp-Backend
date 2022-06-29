using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using SocialMediaApp.DataLayer.Entities;

namespace SocialMediaApp.DataLayer
{
    public class EfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Follows> Follows { get; set; }

        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.Development.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Laborator");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}