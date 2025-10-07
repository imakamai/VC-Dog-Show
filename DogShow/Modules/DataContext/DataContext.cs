using DogShow.Modules.Classes;
using DogShow.Modules.Forms;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DogShow.Modules.DataContext
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Judge> Judges { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<FormForDogs> FormForDogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20); 

                entity.Property(e => e.Address)
                    .HasMaxLength(255); 

                entity.Property(e => e.City)
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20); 

                entity.Property(e => e.State)
                    .HasMaxLength(100); 
            });

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Breed).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
                entity.Property(e => e.Size).IsRequired();
                entity.Property(e => e.Pedigree).IsRequired();
            });

            modelBuilder.Entity<Judge>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.YearsOfExperience).IsRequired();
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AcquisitionDate).IsRequired();
                entity.Property(e => e.AcquisitionTime).IsRequired();
                entity.Property(e => e.AcquisitionPlace).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Judges)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CompetitionJudge",
                    j => j.HasOne<Judge>().WithMany().HasForeignKey("JudgeId"),
                    c => c.HasOne<Competition>().WithMany().HasForeignKey("CompetitionId"),
                    je =>
                    {
                        je.HasKey("CompetitionId", "JudgeId");
                        je.ToTable("CompetitionJudge");
                    }
                );

            modelBuilder.Entity<FormForDogs>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Dog)
                    .WithMany(d => d.Forms)
                    .HasForeignKey("DogId")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}