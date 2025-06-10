using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace DogShow.Modules.DataContext
{
    public class DogShowContext : DbContext
    {
        public DogShowContext(DbContextOptions<DogShowContext> options)
        : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<FormForDogs> FormForDogs { get; set; }
        public virtual DbSet<Judge> Judges { get; set; }
        public virtual DbSet<Kennel> Kennels { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<FormForKennel> FormForKennels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
