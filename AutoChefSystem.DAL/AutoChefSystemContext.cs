using System;
using System.Collections.Generic;
using AutoChefSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoChefSystem.DAL;

public partial class AutoChefSystemContext : DbContext
{
    public AutoChefSystemContext()
    {
    }

    public AutoChefSystemContext(DbContextOptions<AutoChefSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Broth> Broths { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Noodle> Noodles { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-39B7IASC\\SQLEXPRESS;Database=AutoChefSystem;Uid=sa;Pwd=1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Broth>(entity =>
        {
            entity.HasKey(e => e.BrothsId).HasName("PK__Broths__9F37327F45A2D929");

            entity.Property(e => e.BrothsName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Phone).HasName("PK__Customer__5C7E359F03449E5C");

            entity.ToTable("Customer");

            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__Dish__18834F50F2AD62CC");

            entity.ToTable("Dish");

            entity.Property(e => e.DishName).HasMaxLength(100);

            entity.HasOne(d => d.Broths).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.BrothsId)
                .HasConstraintName("FK__Dish__BrothsId__59FA5E80");

            entity.HasOne(d => d.Noodles).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.NoodlesId)
                .HasConstraintName("FK__Dish__NoodlesId__59063A47");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6B680CDB9");

            entity.ToTable("Feedback");

            entity.HasIndex(e => e.OrderId, "UQ_FeedbackOrder").IsUnique();

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.UpdateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithOne(p => p.Feedback)
                .HasForeignKey<Feedback>(d => d.OrderId)
                .HasConstraintName("FK__Feedback__OrderI__70DDC3D8");

            entity.HasOne(d => d.PhoneNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Phone)
                .HasConstraintName("FK__Feedback__Phone__6FE99F9F");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25A2BFFBF74");

            entity.ToTable("Ingredient");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasMaxLength(50);
        });

        modelBuilder.Entity<Noodle>(entity =>
        {
            entity.HasKey(e => e.NoodlesId).HasName("PK__Noodles__A38C5092C0E02B25");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NoodlesName).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF668B17E3");

            entity.ToTable("Order");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Dish).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("FK__Order__DishId__14270015");

            entity.HasOne(d => d.PhoneNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Phone)
                .HasConstraintName("FK__Order__Phone__693CA210");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AA8C07C01");

            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(10);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C449E6D91");

            entity.ToTable("User");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
