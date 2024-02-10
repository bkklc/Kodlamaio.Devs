using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<PLanguage> ProgrammingLanguages { get; set; }
        public DbSet<SoftwareTech> SoftwareTeches { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(c => c.SoftwareTeches);
            });

            modelBuilder.Entity<SoftwareTech>(a =>
            {
                a.ToTable("SoftwareTechs").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.PLanguageId).HasColumnName("PLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasOne(c => c.PLanguage);
            });


            PLanguage[] pLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<PLanguage>().HasData(pLanguageEntitySeeds);
            
            SoftwareTech[] softwareTechesEntitySeeds = { new(1,1, "Asp.Net"), new(2,2, "Spring") };
            modelBuilder.Entity<SoftwareTech>().HasData(softwareTechesEntitySeeds);

           
        }
    }
}
