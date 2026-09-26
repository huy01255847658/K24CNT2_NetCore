using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HoangManhHuy2410900040_exam.Models;

public partial class HmhEmployee2410900040DbSqlContext : DbContext
{
    public HmhEmployee2410900040DbSqlContext()
    {
    }

    public HmhEmployee2410900040DbSqlContext(DbContextOptions<HmhEmployee2410900040DbSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HmhEmployee> HmhEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=HMHuy\\SQLEXPRESS;Database=HmhEmployee_2410900040_Db.sql;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HmhEmployee>(entity =>
        {
            entity.ToTable("HmhEmployee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.HmhActive)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HmhEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HmhName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
