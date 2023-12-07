using Microsoft.EntityFrameworkCore;
using PruebaDesarrollo.HumanResources.Domain.Models.Entities;
using PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects;

namespace PruebaDesarrollo.Shared.Infrastructure.Configuration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            // Definición de tablas
            modelBuilder.Entity<Trabajador>().ToTable("Trabajadores");
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Distrito>().ToTable("Distrito");
            modelBuilder.Entity<Provincia>().ToTable("Provincia");

            // Definición de primary keys
            modelBuilder.Entity<Trabajador>().HasKey(x => x.Id);
            modelBuilder.Entity<Departamento>().HasKey(x => x.Id);
            modelBuilder.Entity<Distrito>().HasKey(x => x.Id);
            modelBuilder.Entity<Provincia>().HasKey(x => x.Id);

            // Definición de atributos para Trabajador
            modelBuilder.Entity<Trabajador>().Property(t => t.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Trabajador>().Property(t => t.TipoDocumento).HasColumnName("TipoDocumento").HasMaxLength(3);
            modelBuilder.Entity<Trabajador>().Property(t => t.NumeroDocumento).HasColumnName("NumeroDocumento").HasMaxLength(50);
            modelBuilder.Entity<Trabajador>().Property(t => t.Nombres).HasColumnName("Nombres").HasMaxLength(500);
            modelBuilder.Entity<Trabajador>().Property(t => t.Sexo).HasColumnName("Sexo").HasMaxLength(1);
            modelBuilder.Entity<Trabajador>().Property(t => t.IdDepartamento).HasColumnName("IdDepartamento");
            modelBuilder.Entity<Trabajador>().Property(t => t.IdProvincia).HasColumnName("IdProvincia");
            modelBuilder.Entity<Trabajador>().Property(t => t.IdDistrito).HasColumnName("IdDistrito");

            // Definición de atributos para Departamento
            modelBuilder.Entity<Departamento>().Property(d => d.Id).HasColumnName("Id").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.NombreDepartamento).HasColumnName("NombreDepartamento").HasMaxLength(500);

            // Definición de atributos para Distrito
            modelBuilder.Entity<Distrito>().Property(d => d.Id).HasColumnName("Id").IsRequired();
            modelBuilder.Entity<Distrito>().Property(d => d.IdProvincia).HasColumnName("IdProvincia");
            modelBuilder.Entity<Distrito>().Property(d => d.NombreDistrito).HasColumnName("NombreDistrito").HasMaxLength(500);

            // Definición de atributos para Provincia
            modelBuilder.Entity<Provincia>().Property(p => p.Id).HasColumnName("Id").IsRequired();
            modelBuilder.Entity<Provincia>().Property(p => p.IdDepartamento).HasColumnName("IdDepartamento");
            modelBuilder.Entity<Provincia>().Property(p => p.NombreProvincia).HasColumnName("NombreProvincia").HasMaxLength(500);
            
            // Definición de relaciones
            modelBuilder.Entity<Trabajador>().HasOne(t => t.Departamento).WithMany().HasForeignKey(t => t.IdDepartamento);
            modelBuilder.Entity<Trabajador>().HasOne(t => t.Provincia).WithMany().HasForeignKey(t => t.IdProvincia);
            modelBuilder.Entity<Trabajador>().HasOne(t => t.Distrito).WithMany().HasForeignKey(t => t.IdDistrito);
            
            modelBuilder.Entity<Distrito>().HasOne(d => d.Provincia).WithMany().HasForeignKey(d => d.IdProvincia);
            modelBuilder.Entity<Provincia>().HasOne(p => p.Departamento).WithMany().HasForeignKey(p => p.IdDepartamento);
            
            
        }
    }
}
