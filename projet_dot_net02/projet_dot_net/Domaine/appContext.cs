﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace projet_dot_net.Domaine
{
    public partial class appContext : DbContext
    {
        public appContext()
        {
        }

        public appContext(DbContextOptions<appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConventionStage> ConventionStage { get; set; }
        public virtual DbSet<Enseignant> Enseignant { get; set; }
        public virtual DbSet<Entreprise> Entreprise { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<Proposition> Proposition { get; set; }
        public virtual DbSet<Rdv> Rdv { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=app", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConventionStage>(entity =>
            {
                entity.ToTable("convention_stage");

                entity.HasIndex(e => e.EnseignantId)
                    .HasName("fk_stage_enseignant1_idx");

                entity.HasIndex(e => e.EntrepriseId)
                    .HasName("fk_stage_entreprise_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Durée)
                    .HasColumnName("durée")
                    .HasColumnType("time");

                entity.Property(e => e.EnseignantId).HasColumnName("enseignant_id");

                entity.Property(e => e.EntrepriseId).HasColumnName("entreprise_id");

                entity.Property(e => e.Memoire)
                    .HasColumnName("memoire")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remuneration)
                    .HasColumnName("remuneration")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Sujet)
                    .HasColumnName("sujet")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Enseignant)
                    .WithMany(p => p.ConventionStage)
                    .HasForeignKey(d => d.EnseignantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stage_enseignant1");

                entity.HasOne(d => d.Entreprise)
                    .WithMany(p => p.ConventionStage)
                    .HasForeignKey(d => d.EntrepriseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stage_entreprise");
            });

            modelBuilder.Entity<Enseignant>(entity =>
            {
                entity.ToTable("enseignant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.ToTable("entreprise");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.ToTable("etudiant");

                entity.HasIndex(e => e.StageId)
                    .HasName("fk_etudiant_stage1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StageId).HasColumnName("stage_id");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Etudiant)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_etudiant_stage1");
            });

            modelBuilder.Entity<Proposition>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.StageId })
                    .HasName("PRIMARY");

                entity.ToTable("proposition");

                entity.HasIndex(e => e.EntrepriseId)
                    .HasName("fk_proposition_entreprise1_idx");

                entity.HasIndex(e => e.StageId)
                    .HasName("fk_proposition_stage1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StageId).HasColumnName("stage_id");

                entity.Property(e => e.Duree)
                    .HasColumnName("duree")
                    .HasColumnType("time");

                entity.Property(e => e.EntrepriseId).HasColumnName("entreprise_id");

                entity.Property(e => e.Sujet)
                    .HasColumnName("sujet")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Entreprise)
                    .WithMany(p => p.Proposition)
                    .HasForeignKey(d => d.EntrepriseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_proposition_entreprise1");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Proposition)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_proposition_stage1");
            });

            modelBuilder.Entity<Rdv>(entity =>
            {
                entity.ToTable("rdv");

                entity.HasIndex(e => e.EntrepriseId)
                    .HasName("fk_RDV_entreprise1_idx");

                entity.HasIndex(e => e.EtudiantId)
                    .HasName("fk_RDV_etudiant1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DureeDuStage)
                    .HasColumnName("duree_du_stage")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.EntrepriseId).HasColumnName("entreprise_id");

                entity.Property(e => e.EtudiantId).HasColumnName("etudiant_id");

                entity.Property(e => e.Proposition)
                    .HasColumnName("proposition")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Entreprise)
                    .WithMany(p => p.Rdv)
                    .HasForeignKey(d => d.EntrepriseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RDV_entreprise1");

                entity.HasOne(d => d.Etudiant)
                    .WithMany(p => p.Rdv)
                    .HasForeignKey(d => d.EtudiantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RDV_etudiant1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
