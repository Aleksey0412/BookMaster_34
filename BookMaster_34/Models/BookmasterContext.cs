using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookMaster_34.Models;

public partial class BookmasterContext : DbContext
{
    public BookmasterContext()
    {
    }

    public BookmasterContext(DbContextOptions<BookmasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookCover> BookCovers { get; set; }

    public virtual DbSet<BookSubject> BookSubjects { get; set; }

    public virtual DbSet<Circulation> Circulations { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Bookmaster;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.ToTable("Administrator");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.Username).HasMaxLength(32);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Wikipedia).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Subtitle).HasMaxLength(80);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("BookAuthor");

            entity.Property(e => e.BookId).HasMaxLength(128);

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookAuthor_Author");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookAuthor_Book");
        });

        modelBuilder.Entity<BookCover>(entity =>
        {
            entity.ToTable("BookCover");

            entity.Property(e => e.BookId).HasMaxLength(128);

            entity.HasOne(d => d.Book).WithMany(p => p.BookCovers)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCover_Book");

            entity.HasOne(d => d.Cover).WithMany(p => p.BookCovers)
                .HasForeignKey(d => d.CoverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCover_Cover");
        });

        modelBuilder.Entity<BookSubject>(entity =>
        {
            entity.ToTable("BookSubject");

            entity.Property(e => e.BookId).HasMaxLength(128);

            entity.HasOne(d => d.Book).WithMany(p => p.BookSubjects)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookSubject_Book");

            entity.HasOne(d => d.Subject).WithMany(p => p.BookSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookSubject_Subject");
        });

        modelBuilder.Entity<Circulation>(entity =>
        {
            entity.ToTable("Circulation");

            entity.Property(e => e.BookId).HasMaxLength(128);
            entity.Property(e => e.CustomerId).HasMaxLength(128);

            entity.HasOne(d => d.Administrator).WithMany(p => p.Circulations)
                .HasForeignKey(d => d.AdministratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Circulation_Administrator");

            entity.HasOne(d => d.Book).WithMany(p => p.Circulations)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Circulation_Book");

            entity.HasOne(d => d.Customer).WithMany(p => p.Circulations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Circulation_Customer");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.ToTable("Cover");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Zip).HasMaxLength(6);

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Customer_City");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
