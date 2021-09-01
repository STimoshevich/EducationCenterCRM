using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Initializer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationCenterCRM.DAL.Context
{
    public class EducationCenterDatabase : IdentityDbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



        protected EducationCenterDatabase()
        {
        }

        public EducationCenterDatabase(DbContextOptions options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
          
        }

       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
           // optionsBuilder.LogTo(System.Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Group>()
                .HasMany<Student>(x => x.Students)
                .WithOne(x => x.Group)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }

}
