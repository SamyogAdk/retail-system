using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyRetailSystem.Models
{
    public partial class MyRetailSystemContext : IdentityDbContext
    {
        public MyRetailSystemContext()
        {
        }

        public MyRetailSystemContext(DbContextOptions<MyRetailSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MyRetailSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__8CB286B9E5C4CA46");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_Number");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__Customer___267ABA7A");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("OrderID");

                entity.ToTable("Order_Line");

                entity.Property(e => e.LineId)
                    .ValueGeneratedNever()
                    .HasColumnName("Line_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Lin__Order__2B3F6F97");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Lin__Produ__2C3393D0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
