using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWP_API.Models
{
    public partial class JournalContext : DbContext
    {
        public JournalContext()
        {
        }

        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblArticle> TblArticles { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblPayment> TblPayments { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblTransaction> TblTransactions { get; set; } = null!;
        public virtual DbSet<TblTransactionDetail> TblTransactionDetails { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U36E8N1\\DAIDUONG;Database=Journal;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("tblArticle");

                entity.Property(e => e.ArticleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ArticleID")
                    .IsFixedLength();

                entity.Property(e => e.ArticleTitile).HasMaxLength(120);

                entity.Property(e => e.AuthorName).HasMaxLength(50);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID")
                    .IsFixedLength();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblArticles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblArticle_tblCategory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblArticles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblArticle_tblUser");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblCategory");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID")
                    .IsFixedLength();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("tblPayment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID")
                    .IsFixedLength();

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RoleID")
                    .IsFixedLength();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("tblTransaction");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID")
                    .IsFixedLength();

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID")
                    .IsFixedLength();

                entity.Property(e => e.TransDetailId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransDetailID")
                    .IsFixedLength();

                entity.Property(e => e.TransactionName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TblTransactions)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransaction_tblPayment");

                entity.HasOne(d => d.TransDetail)
                    .WithMany(p => p.TblTransactions)
                    .HasForeignKey(d => d.TransDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransaction_tblTransactionDetail");
            });

            modelBuilder.Entity<TblTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransDetailId);

                entity.ToTable("tblTransactionDetail");

                entity.Property(e => e.TransDetailId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransDetailID")
                    .IsFixedLength();

                entity.Property(e => e.ArticleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ArticleID")
                    .IsFixedLength();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransDetailName).HasMaxLength(30);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreateTimed).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID")
                    .IsFixedLength();

                entity.Property(e => e.RoleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RoleID")
                    .IsFixedLength();

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_tblPayment");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_tblRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
