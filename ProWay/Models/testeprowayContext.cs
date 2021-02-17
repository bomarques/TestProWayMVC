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
        public virtual DbSet<Cafeteria> Cafeteria { get; set; }
        public virtual DbSet<EtapaSala> EtapaSalas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<TurnoCafeteria> TurnoCafeteria { get; set; }

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
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Alunos__92579F310B0C8D57");

                entity.Property(e => e.IdAluno).HasColumnName("Id_Aluno");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cafeteria>(entity =>
            {
                entity.HasKey(e => e.IdCafeteria)
                    .HasName("PK__Cafeteri__1F059AE7B478A03C");

                entity.Property(e => e.IdCafeteria).HasColumnName("Id_Cafeteria");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EtapaSala>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EtapaSala");

                entity.Property(e => e.IdAluno).HasColumnName("Id_Aluno");

                entity.Property(e => e.IdSala).HasColumnName("Id_Sala");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__EtapaSala__Id_Al__398D8EEE");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__EtapaSala__Id_Sa__3A81B327");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__Salas__ACDC9E2322D173EA");

                entity.Property(e => e.IdSala).HasColumnName("Id_Sala");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurnoCafeteria>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdAluno).HasColumnName("Id_Aluno");

                entity.Property(e => e.IdCafeteria).HasColumnName("Id_Cafeteria");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__TurnoCafe__Id_Al__3E52440B");

                entity.HasOne(d => d.IdCafeteriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCafeteria)
                    .HasConstraintName("FK__TurnoCafe__Id_Ca__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
