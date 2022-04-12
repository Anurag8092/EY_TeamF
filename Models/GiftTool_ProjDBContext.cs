using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gift_Auth.Models
{
    public partial class GiftTool_ProjDBContext : DbContext
    {
        public GiftTool_ProjDBContext()
        {
        }

        public GiftTool_ProjDBContext(DbContextOptions<GiftTool_ProjDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gifts> Gifts { get; set; }
        public virtual DbSet<LoginUser> LoginUser { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-66SGHCF;Database=GiftTool_ProjDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gifts>(entity =>
            {
                entity.HasKey(e => e.GiftId);

                entity.Property(e => e.GiftId).HasColumnName("gift_id");

                entity.Property(e => e.GiftImg)
                    .HasColumnName("gift_img")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GiftName)
                    .HasColumnName("gift_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("login_user");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAuth).HasColumnName("isAuth");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetId);

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDetId).HasColumnName("order_det_Id");

                entity.Property(e => e.GiftId).HasColumnName("gift_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("order_id");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.LoginId).HasColumnName("login_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
