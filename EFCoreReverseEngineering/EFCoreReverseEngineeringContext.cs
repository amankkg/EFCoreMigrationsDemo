using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreReverseEngineering
{
    public partial class EFCoreReverseEngineeringContext : DbContext
    {
        public EFCoreReverseEngineeringContext()
        {
        }

        public EFCoreReverseEngineeringContext(DbContextOptions<EFCoreReverseEngineeringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Residents> Residents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=AMANK-XPS-9360\\SQLEXPRESS; Database=EFCoreReverseEngineering; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residents>(entity =>
            {
                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
