using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBFistExercise2.Model
{
    public partial class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kur> Kurs { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Student;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Kur>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Namn)
                    .HasMaxLength(50)
                    .HasColumnName("namn");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .HasColumnName("efternamn");

                entity.Property(e => e.Fornamn)
                    .HasMaxLength(50)
                    .HasColumnName("fornamn");

                entity.Property(e => e.KursId).HasColumnName("kurs_id");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_Student_Kurs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
