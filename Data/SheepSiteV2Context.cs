using System;
using Sheep.SiteV2.Api.Controllers;
using Sheep.SiteV2.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Sheep.SiteV2.Api.Data{
    public class SheepSiteV2Context : DbContext
    {
        public SheepSiteV2Context(DbContextOptions<SheepSiteV2Context> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Pregnancy> Pregnancies { get; set; }
    }
}