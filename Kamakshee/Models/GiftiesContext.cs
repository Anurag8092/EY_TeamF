using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gifties.Models
{
    public partial class GiftiesContext : DbContext
    {
        public GiftiesContext()
        {
        }

        public GiftiesContext(DbContextOptions<GiftiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GiftCategory> GiftCategory { get; set; }
        public virtual DbSet<Gifts> Gifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-T9O1FJN;Database=Gifties;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftCategory>(entity =>
            {
                entity.HasKey(e => e.PkGiftCategoryId);

                entity.ToTable("Gift_category");

                entity.Property(e => e.PkGiftCategoryId).HasColumnName("pk_gift_category_id");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("category_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gifts>(entity =>
            {
                entity.HasKey(e => e.PkGiftId);

                entity.Property(e => e.PkGiftId).HasColumnName("pk_gift_id");

                entity.Property(e => e.FkGiftCategoryId).HasColumnName("fk_gift_category_id");

                entity.Property(e => e.GiftName)
                    .HasColumnName("gift_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GiftPrice)
                    .HasColumnName("gift_price")
                    .HasColumnType("money");

                entity.Property(e => e.GiftQuantity).HasColumnName("gift_quantity");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("image");

                entity.HasOne(d => d.FkGiftCategory)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.FkGiftCategoryId)
                    .HasConstraintName("FK_Gifts_Gift_category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
