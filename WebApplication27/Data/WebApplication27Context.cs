using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Models;

namespace WebApplication27.Data
{
    public class WebApplication27Context : DbContext
    {
        public WebApplication27Context (DbContextOptions<WebApplication27Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication27.Models.Page> Page { get; set; }

        public DbSet<WebApplication27.Models.Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersGroups>()
                .HasKey(t => new { t.UserId, t.GroupId });

            modelBuilder.Entity<UsersGroups>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UsersGroups)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UsersGroups>()
                .HasOne(pt => pt.Group)
                .WithMany(t => t.UsersGroups)
                .HasForeignKey(pt => pt.GroupId);
        }

        public DbSet<WebApplication27.Models.Group> Group { get; set; }

        public DbSet<WebApplication27.Models.User> User { get; set; }

        public DbSet<WebApplication27.Models.UsersGroups> UsersGroups { get; set; }
    }
}
