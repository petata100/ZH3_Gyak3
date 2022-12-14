using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class ReceptContext : DbContext
{
    public ReceptContext()
    {
    }

    public ReceptContext(DbContextOptions<ReceptContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fogasok> Fogasok { get; set; }

    public virtual DbSet<MennyisegiEgysegek> MennyisegiEgysegek { get; set; }

    public virtual DbSet<Nyersanyagok> Nyersanyagok { get; set; }

    public virtual DbSet<Receptek> Receptek { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Desktop\\3.félév\\Softtech\\ZH3_Gyak3\\FormsApp\\Database1.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fogasok>(entity =>
        {
            entity.HasKey(e => e.FogasId);

            entity.Property(e => e.FogasId).HasColumnName("FogasID");
            entity.Property(e => e.FogasNev).HasMaxLength(50);
            entity.Property(e => e.Kep).HasColumnType("image");
        });

        modelBuilder.Entity<MennyisegiEgysegek>(entity =>
        {
            entity.HasKey(e => e.MennyisegiEgysegId);

            entity.Property(e => e.MennyisegiEgysegId)
                .ValueGeneratedNever()
                .HasColumnName("MennyisegiEgysegID");
            entity.Property(e => e.EgysegNev).HasMaxLength(50);
        });

        modelBuilder.Entity<Nyersanyagok>(entity =>
        {
            entity.HasKey(e => e.NyersanyagId);

            entity.Property(e => e.NyersanyagId).HasColumnName("NyersanyagID");
            entity.Property(e => e.Egysegar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.MennyisegiEgysegId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("MennyisegiEgysegID");
            entity.Property(e => e.NyersanyagNev).HasMaxLength(50);

            entity.HasOne(d => d.MennyisegiEgyseg).WithMany(p => p.Nyersanyagok)
                .HasForeignKey(d => d.MennyisegiEgysegId)
                .HasConstraintName("FK_Nyersanyagok_MennyisegiEgysegek");
        });

        modelBuilder.Entity<Receptek>(entity =>
        {
            entity.HasKey(e => e.ReceptId);

            entity.Property(e => e.ReceptId).HasColumnName("ReceptID");
            entity.Property(e => e.FogasId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("FogasID");
            entity.Property(e => e.Mennyiseg4fo)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Mennyiseg_4fo");
            entity.Property(e => e.NyersanyagId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("NyersanyagID");

            entity.HasOne(d => d.Fogas).WithMany(p => p.Receptek)
                .HasForeignKey(d => d.FogasId)
                .HasConstraintName("FK_Receptek_Fogasok");

            entity.HasOne(d => d.Nyersanyag).WithMany(p => p.Receptek)
                .HasForeignKey(d => d.NyersanyagId)
                .HasConstraintName("FK_Receptek_Nyersanyagok");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
