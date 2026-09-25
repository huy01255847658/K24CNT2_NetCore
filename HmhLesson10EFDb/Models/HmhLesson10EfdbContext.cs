using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HmhLesson10EFDb.Models;

public partial class HmhLesson10EfdbContext : DbContext
{
    public HmhLesson10EfdbContext()
    {
    }

    public HmhLesson10EfdbContext(DbContextOptions<HmhLesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HmhMember> HmhMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=HMHuy\\SQLEXPRESS;Database=HmhLesson10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HmhMember>(entity =>
        {
            entity.ToTable("HmhMember");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HmhEmail).HasMaxLength(50);
            entity.Property(e => e.HmhFullName).HasMaxLength(50);
            entity.Property(e => e.HmhPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HmhPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HmhUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
