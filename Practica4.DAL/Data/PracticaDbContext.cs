using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica4.DAL.Data
{
    public class PracticaDbContext : DbContext
    {
        public PracticaDbContext(DbContextOptions<PracticaDbContext> options) : base(options)
        {

        }
       public DbSet<Entities.Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Estudiante>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Edad).IsRequired();
                entity.Property(e => e.Grado).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Genero).IsRequired().HasMaxLength(20);
            });
        }
    }
}
