using System;
using BoardManager_Data.BoardManagerContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoardManager_Data.BoardManagerContext
{
    public partial class BoardManagerContext : DbContext
    {
        public BoardManagerContext()
        {
        }

        public BoardManagerContext(DbContextOptions<BoardManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Board { get; set; }
        public virtual DbSet<BoardDetail> BoardDetail { get; set; }
        public virtual DbSet<ColumnBoard> ColumnBoard { get; set; }
        public virtual DbSet<ColumnMappingBoard> ColumnMappingBoard { get; set; }
        public virtual DbSet<FacebookAccount> FacebookAccount { get; set; }
        public virtual DbSet<GoogleAccount> GoogleAccount { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UsersAccount> UsersAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=103.1.210.65;Initial Catalog=BoardManager;Integrated Security=False;Persist Security Info=False;User ID=testDB;Password=1234Bbbb!!@@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.Board)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK__Board__User_Prof__173876EA");
            });

            modelBuilder.Entity<BoardDetail>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.BoardDetail)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK__Board_Det__Board__182C9B23");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.BoardDetail)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("FK__Board_Det__Colum__1920BF5C");
            });

            modelBuilder.Entity<ColumnMappingBoard>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.ColumnMappingBoard)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Column_Mapping_Board_Board");

                entity.HasOne(d => d.ColumnBoard)
                    .WithMany(p => p.ColumnMappingBoard)
                    .HasForeignKey(d => d.ColumnBoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Column_Mapping_Board_Column_Board");
            });

            modelBuilder.Entity<FacebookAccount>(entity =>
            {
                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.FacebookAccount)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK_UserProfile_FacebookAccount");
            });

            modelBuilder.Entity<GoogleAccount>(entity =>
            {
                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.GoogleAccount)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK_UserProfile_GoogleAccount1");
            });

            modelBuilder.Entity<UsersAccount>(entity =>
            {
                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.UsersAccount)
                    .HasForeignKey(d => d.UserProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Account_User_Profile");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
