﻿using System;
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

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeStep> RecipeSteps { get; set; }

    public virtual DbSet<Robot> Robots { get; set; }

    public virtual DbSet<RobotOperationLog> RobotOperationLogs { get; set; }

    public virtual DbSet<RobotTask> RobotTasks { get; set; }

    public virtual DbSet<RobotType> RobotTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StepTask> StepTasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=tcp:autochefdbserver.database.windows.net,1433;Initial Catalog=AutoChefSystem;Persist Security Info=False;User ID=autochefdbserver;Password=@Testpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        => optionsBuilder.UseSqlServer("Server=LAPTOP-39B7IASC\\SQLEXPRESS;Database=AutoChefSystem;Uid=sa;Pwd=1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA49726A610A3");

            entity.ToTable("Location");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFCF563AD0");

            entity.ToTable("Order");

            entity.Property(e => e.CompletedTime).HasColumnType("datetime");
            entity.Property(e => e.OrderedTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Location).WithMany(p => p.Orders)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Location");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Recipe");

            entity.HasOne(d => d.Robot).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RobotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Robot");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipe__FDD988B070C73FCA");

            entity.ToTable("Recipe");

            entity.Property(e => e.Ingredients).HasMaxLength(255);
            entity.Property(e => e.RecipeName).HasMaxLength(100);
        });

        modelBuilder.Entity<RecipeStep>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__RecipeSt__24343357B09B0472");

            entity.ToTable("RecipeStep");

            entity.Property(e => e.StepDescription).HasMaxLength(255);

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeSteps)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeStep_Recipe");
        });

        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.RobotId).HasName("PK__Robot__FBB3324148DE6123");

            entity.ToTable("Robot");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Location).WithMany(p => p.Robots)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Robot_Location");

            entity.HasOne(d => d.RobotType).WithMany(p => p.Robots)
                .HasForeignKey(d => d.RobotTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Robot_RobotType");
        });

        modelBuilder.Entity<RobotOperationLog>(entity =>
        {
            entity.HasKey(e => e.RobotOperationLogId).HasName("PK__RobotOpe__19FE31E8F59DCC6F");

            entity.ToTable("RobotOperationLog");

            entity.Property(e => e.CompletionStatus).HasMaxLength(50);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.RobotOperationLogs)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RobotOperationLog_Order");

            entity.HasOne(d => d.Robot).WithMany(p => p.RobotOperationLogs)
                .HasForeignKey(d => d.RobotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RobotOperationLog_Robot");
        });

        modelBuilder.Entity<RobotTask>(entity =>
        {
            entity.HasKey(e => e.RobotTaskId).HasName("PK__RobotTas__52CCC00BF0F4ACD9");

            entity.ToTable("RobotTask");

            entity.Property(e => e.RobotTaskName).HasMaxLength(100);
            entity.Property(e => e.TaskDescription).HasMaxLength(255);
        });

        modelBuilder.Entity<RobotType>(entity =>
        {
            entity.HasKey(e => e.RobotTypeId).HasName("PK__RobotTyp__B4BB3C4D0B11CC04");

            entity.ToTable("RobotType");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RobotTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AA8C07C01");

            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(10);
        });

        modelBuilder.Entity<StepTask>(entity =>
        {
            entity.HasKey(e => e.StepTaskId).HasName("PK__StepTask__45192A89CDCABAFE");

            entity.ToTable("StepTask");

            entity.HasOne(d => d.Step).WithMany(p => p.StepTasks)
                .HasForeignKey(d => d.StepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StepTask_RecipeStep");

            entity.HasOne(d => d.Task).WithMany(p => p.StepTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StepTask_RobotTask");
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
