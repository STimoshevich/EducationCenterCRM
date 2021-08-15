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

        public DbSet<Student> students { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }





        public EducationCenterDatabase(DbContextOptions options) : base(options)
        {

            Database.EnsureCreated();
        }

        protected EducationCenterDatabase()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasMany<Student>(x => x.Students).WithOne(x => x.Group);


          //  modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }

}
