using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KitStemHub.Repositories.Models;

public partial class KitStemHubWpfContext : DbContext
{
    public KitStemHubWpfContext()
    {
    }

    public KitStemHubWpfContext(DbContextOptions<KitStemHubWpfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Kit> Kits { get; set; }

    public virtual DbSet<KitOrder> KitOrders { get; set; }

    public virtual DbSet<Method> Methods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=KitStemHubWpf;Persist Security Info=True;User ID=sa;Password=12345;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.KitId }).HasName("PK__Cart__7B1E220606C8EA79");

            entity.ToTable("Cart");

            entity.HasOne(d => d.Kit).WithMany(p => p.Carts)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__KitId__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__UserId__4E88ABD4");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07267B60EE");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Kit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kit__3214EC077EFB4AEB");

            entity.ToTable("Kit");

            entity.Property(e => e.Breif).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Kits)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Kit__CategoryId__3F466844");
        });

        modelBuilder.Entity<KitOrder>(entity =>
        {
            entity.HasKey(e => new { e.KitId, e.OrderId }).HasName("PK__KitOrder__2557E11B4BD6FB58");

            entity.ToTable("KitOrder");

            entity.HasOne(d => d.Kit).WithMany(p => p.KitOrders)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KitOrder__KitId__4AB81AF0");

            entity.HasOne(d => d.Order).WithMany(p => p.KitOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KitOrder__OrderI__4BAC3F29");
        });

        modelBuilder.Entity<Method>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Method__3214EC07E825D79F");

            entity.ToTable("Method");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NormalizedName).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC070247DA3B");

            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddress).HasMaxLength(100);
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__UserId__440B1D61");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC075F759071");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Method).WithMany(p => p.Payments)
                .HasForeignKey(d => d.MethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__MethodI__47DBAE45");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payment__OrderId__46E78A0C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC0785EE4B47");

            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NormalizedName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07543A7864");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4BB2F83B3").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534CB685BD4").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
