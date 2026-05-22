using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employment.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignTask> AssignTasks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-5RUPPFV; Database=Employment;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AssignTa__3214EC27D7FAFB9B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmplyeeId).HasColumnName("EmplyeeID");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Emplyee).WithMany(p => p.AssignTasks)
                .HasForeignKey(d => d.EmplyeeId)
                .HasConstraintName("FK__AssignTas__Emply__5441852A");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC272EB5F4EF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.MangerId).HasColumnName("MangerID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Manger).WithMany(p => p.Employees)
                .HasForeignKey(d => d.MangerId)
                .HasConstraintName("FK__Employees__Mange__4BAC3F29");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Managers__3214EC2782EFFA0C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
