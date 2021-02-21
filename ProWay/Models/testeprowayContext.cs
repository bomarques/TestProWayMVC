using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProWay.Models
{
    public partial class testeprowayContext : DbContext
    {
        public testeprowayContext()
        {
        }

        public testeprowayContext(DbContextOptions<testeprowayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Lanchonete> Lanchonetes { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<TurnoLanchonete> TurnoLanchonetes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=testeproway;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lanchonete>(entity =>
            {
                entity.ToTable("Lanchonete");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("Matricula");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.AlunoId)
                    .HasConstraintName("FK__Matricula__Aluno__3A81B327");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.SalaId)
                    .HasConstraintName("FK__Matricula__SalaI__3B75D760");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurnoLanchonete>(entity =>
            {
                entity.HasKey(e => e.IdTurnoLanchonete)
                    .HasName("PK__TurnoLan__FAFF3E5DF62E9D5E");

                entity.ToTable("TurnoLanchonete");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.TurnoLanchonetes)
                    .HasForeignKey(d => d.AlunoId)
                    .HasConstraintName("FK__TurnoLanc__Aluno__403A8C7D");

                entity.HasOne(d => d.Lanchonete)
                    .WithMany(p => p.TurnoLanchonetes)
                    .HasForeignKey(d => d.LanchoneteId)
                    .HasConstraintName("FK__TurnoLanc__Lanch__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
