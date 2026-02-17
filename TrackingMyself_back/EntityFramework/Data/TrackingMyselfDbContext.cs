using System;
using System.Collections.Generic;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data;

public partial class TrackingMyselfDbContext : DbContext
{
    public TrackingMyselfDbContext()
    {
    }

    public TrackingMyselfDbContext(DbContextOptions<TrackingMyselfDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<BudgetExecution> BudgetExecutions { get; set; }

    public virtual DbSet<ExpenseDetail> ExpenseDetails { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrackingMyself;Integrated Security=True;Encrypt=True;TrustServerCertificate=False;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("Budget");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTimeNavigation).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.IdTime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Budget_Time");
        });

        modelBuilder.Entity<BudgetExecution>(entity =>
        {
            entity.ToTable("BudgetExecution");

            entity.HasOne(d => d.IdBudgetNavigation).WithMany(p => p.BudgetExecutions)
                .HasForeignKey(d => d.IdBudget)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BudgetExecution_Budget");
        });

        modelBuilder.Entity<ExpenseDetail>(entity =>
        {
            entity.ToTable("ExpenseDetail");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpenseInserted).HasColumnType("datetime");

            entity.HasOne(d => d.IdExpenseTypeNavigation).WithMany(p => p.ExpenseDetails)
                .HasForeignKey(d => d.IdExpenseType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpenseDetail_ExpenseType");
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.ToTable("ExpenseType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.ToTable("Time");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TimeTense).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
