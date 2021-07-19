using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class satyamdbContext : DbContext
    {
        public satyamdbContext()
        {
        }

        public satyamdbContext(DbContextOptions<satyamdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Customer__213EE7742DE92F37");

                entity.ToTable("Customer");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("c_address");

                entity.Property(e => e.CEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("c_email");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("c_name");

                entity.Property(e => e.CPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("c_phoneNumber");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LineItem__A7C7B6F86A7B2F07");

                entity.ToTable("LineItem");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LPId).HasColumnName("l_p_id");

                entity.Property(e => e.LQuantity).HasColumnName("l_quantity");

                entity.Property(e => e.LSId).HasColumnName("l_s_id");

                entity.HasOne(d => d.LP)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.LPId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineItem__l_p_id__628FA481");

                entity.HasOne(d => d.LS)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.LSId)
                    .HasConstraintName("FK__LineItem__l_s_id__656C112C");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__Orders__904BC20E9B0067C5");

                entity.Property(e => e.OId).HasColumnName("o_id");

                entity.Property(e => e.OCId).HasColumnName("o_c_id");

                entity.Property(e => e.OOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("o_order_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OSId).HasColumnName("o_s_id");

                entity.Property(e => e.OTotal).HasColumnName("o_total");

                entity.HasOne(d => d.OC)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OCId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__o_c_id__693CA210");

                entity.HasOne(d => d.OS)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OSId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__o_s_id__68487DD7");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Product__82E06B9100FB12AE");

                entity.ToTable("Product");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("p_name");

                entity.Property(e => e.PPrice).HasColumnName("p_price");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__StoreFro__2F3684F49197F71C");

                entity.ToTable("StoreFront");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.Property(e => e.SAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("s_address");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("s_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
