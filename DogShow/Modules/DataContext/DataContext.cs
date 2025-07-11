using DogShow.Modules.Classes;
using DogShow.Modules.Forms;
using DogShow.Modules.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace DogShow.Modules.DataContext
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        //public virtual DbSet<FormForDogs> FormForDogs { get; set; }
        public virtual DbSet<Judge> Judges { get; set; }
        public virtual DbSet<Kennel> Kennels { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        //public virtual DbSet<Person> Persons { get; set; }
        //public virtual DbSet<FormForKennel> FormForKennels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Person
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

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

            // Configure User (inherits from Person)
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            // Judge configuration
            modelBuilder.Entity<Judge>(entity =>
            {
                //entity.HasKey(e => e.Id);
                // Inherits Person properties, no extra fields
            });

            // Owner configuration
            modelBuilder.Entity<Owner>(entity =>
            {
                //entity.HasKey(e => e.Id);
                // Inherits Person properties, no extra fields
            });

            // Dog configuration
            modelBuilder.Entity<Dog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired();

                entity.Property(e => e.Weight)
                    .IsRequired();

                entity.Property(e => e.Size)
                    .IsRequired();

                entity.Property(e => e.Pedigree)
                    .IsRequired();

            });


            OnModelCreatingPartial(modelBuilder); 
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
    }
}