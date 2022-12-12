using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReadingList_task.Data.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ReadingList_task.Data;

public class ReadingListDbContext : DbContext
{
    public ReadingListDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;
    public virtual DbSet<BooksOfUser> BooksOfUsers { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<Series> Series { get; set; } = null!;
    public virtual DbSet<UserCollection> UserCollections { get; set; } = null!;

    public virtual DbSet<BooksOfUserToCollection> BooksOfUserToCollections { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(b => b.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Language)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.FK_Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.FK_AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Authors");

            entity.HasOne(d => d.FK_Genre)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.FK_GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Genres");

            entity.HasOne(d => d.FK_Series)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.FK_SeriesId)
                .HasConstraintName("FK_Books_Series");
        });

        modelBuilder.Entity<BooksOfUser>(entity =>
        {
            entity.ToTable("BooksOfUser");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.FinishReadingDate).HasColumnType("date");

            entity.Property(e => e.StartReadingDate).HasColumnType("date");

            entity.HasOne(d => d.FK_Book)
                .WithOne(p => p.BooksOfUsers)
                .HasForeignKey<BooksOfUser>(d => d.FK_BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksOfUser_Books");

            entity.Property(b => b.IsFinished)
                .HasDefaultValue(false);
            entity.Property(b => b.ReadingPriority)
                .HasDefaultValue(1);
            entity.Property(b => b.StartReadingDate)
                .HasDefaultValue(DateTime.Today.Date);

        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(g => g.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.GenreName)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.Property(s => s.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.SeriesName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<UserCollection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.CollectionName)
                .HasMaxLength(50)
                .IsFixedLength();
            
        });

        // modelBuilder.Entity<UserRating>(entity =>
        // {
        //     entity.ToTable("UserRating");
        //
        //     entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //
        //     entity.HasOne(d => d.FK_BooksOfUser)
        //         .WithOne(p => p.UserRatings)
        //         .HasForeignKey<UserRating>(d => d.FK_BooksOfUserId)
        //         .OnDelete(DeleteBehavior.ClientSetNull)
        //         .HasConstraintName("FK_UserRating_BooksOfUser");
        // });
        

        modelBuilder.Entity<BooksOfUserToCollection>(entity =>
        {
            entity.ToTable("BooksOfUserToCollections");
            entity.HasKey(bc => new { bc.FK_CollectionId, bc.FK_BookOfUserId });

            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            
            entity.HasOne<UserCollection>(bc => bc.FK_Collection)
                .WithMany(uc => uc.BooksOfUsersToCollections)
                .HasForeignKey(bc => bc.FK_CollectionId);

            entity.HasOne<BooksOfUser>(bc => bc.FK_BookOfUser)
                .WithMany(ub => ub.BooksOfUserToCollections)
                .HasForeignKey(bc => bc.FK_BookOfUserId);
        });
        

        //OnModelCreatingPartial(modelBuilder);
    }

    // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}