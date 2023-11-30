using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vetrinaria.Models;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comida> Comidas { get; set; }

    public virtual DbSet<Dueño> Dueños { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=STEVEN\\SQLEXPRESS;Database=Veterinaria; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comida>(entity =>
        {
            entity.HasKey(e => e.IdComida);

            entity.Property(e => e.IdComida).HasColumnName("idComida");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dueño>(entity =>
        {
            entity.HasKey(e => e.IdDueños);

            entity.Property(e => e.IdDueños).HasColumnName("idDueños");
            entity.Property(e => e.IdMascotas).HasColumnName("idMascotas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascotas);

            entity.Property(e => e.IdMascotas).HasColumnName("idMascotas");
            entity.Property(e => e.IdDueño).HasColumnName("idDueño");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Raza)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
