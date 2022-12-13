using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDHoteles.Models
{
    public partial class cheil2Context : DbContext
    {
        public cheil2Context()
        {
        }

        public cheil2Context(DbContextOptions<cheil2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Hotele> Hoteles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;database=cheil2;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.ToTable("calificaciones");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Calificacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("calificacion");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(250)
                    .HasColumnName("comentario");

                entity.Property(e => e.HotelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("HotelID");
            });

            modelBuilder.Entity<Hotele>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PRIMARY");

                entity.ToTable("hoteles");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.HotelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("HotelID");

                entity.Property(e => e.Categoria).HasMaxLength(250);

                entity.Property(e => e.Foto1)
                    .HasMaxLength(250)
                    .HasColumnName("foto1");

                entity.Property(e => e.Foto2)
                    .HasMaxLength(250)
                    .HasColumnName("foto2");

                entity.Property(e => e.Foto3)
                    .HasMaxLength(250)
                    .HasColumnName("foto3");

                entity.Property(e => e.HotelName).HasMaxLength(250);

                entity.Property(e => e.Precio).HasColumnType("float(11,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
