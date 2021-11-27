using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagementSystem.Models
{
    public partial class AssetManagementContext : DbContext
    {
        public AssetManagementContext()
        {
        }

        public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetMasterTable> AssetMasterTable { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=NITHINPETER\\SQLEXPRESS; Initial Catalog=AssetManagement; Integrated security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetMasterTable>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED0BFF772B1");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAd)
                    .HasColumnName("am_ad")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmAtypeId)
                    .HasColumnName("am_atype_id")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmFrom)
                    .HasColumnName("am_from")
                    .HasColumnType("date");

                entity.Property(e => e.AmMake)
                    .HasColumnName("am_make")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmMyyear)
                    .HasColumnName("am_myyear")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AmPdate)
                    .HasColumnName("am_pdate")
                    .HasColumnType("date");

                entity.Property(e => e.AmSnumber)
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTo)
                    .HasColumnName("am_to")
                    .HasColumnType("date");

                entity.Property(e => e.AmWarranty)
                    .HasColumnName("am_warranty")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7F2E2A063109225");

                entity.Property(e => e.LId).HasColumnName("l_Id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEAC7AF733C");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_Id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__UserRegist__l_Id__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
