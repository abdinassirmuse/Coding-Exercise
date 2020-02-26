using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CodingAssessmentDAL.Models
{
    public partial class CodingAssessmentDBContext : DbContext
    {
        public CodingAssessmentDBContext()
        {
        }

        public CodingAssessmentDBContext(DbContextOptions<CodingAssessmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventList> EventList { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventList>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.AddedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EventEndDate).HasColumnType("date");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventStartDate).HasColumnType("date");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.EventList)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("fk_username_eventadd");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
