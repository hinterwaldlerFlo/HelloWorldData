using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HelloWorldData.Models
{
    public partial class HelloDataContext : DbContext
    {
        public virtual DbSet<WeatherForecast> WeatherForecast { get; set; }

        public HelloDataContext(DbContextOptions<HelloDataContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>(entity =>
            {
                entity.Property(e => e.DateFormatted)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}