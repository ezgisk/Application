using Application.Entitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{

    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(p => p.User);
        }
    }
    }
