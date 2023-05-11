using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDAutosv.Models;

public partial class AutosContext : DbContext
{
    public AutosContext()
    {
    }

    public AutosContext(DbContextOptions<AutosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
      //  => optionsBuilder.UseSqlServer("server=GP-LAPTOPV2; database=Autos; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.IdAuto).HasName("PK__Autos__D8600DCFFE53EC3F");

            entity.Property(e => e.IdAuto)
                .ValueGeneratedNever()
                .HasColumnName("idAuto");
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.Marca).HasMaxLength(255);
            entity.Property(e => e.Modelo).HasMaxLength(255);
            entity.Property(e => e.Patente).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
