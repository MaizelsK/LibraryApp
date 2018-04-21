namespace LibraryApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("LibraryContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<Customers_books> Customers_books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("books_authors"));

            modelBuilder.Entity<Book>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Customers_books)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.Book_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Customers_books)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_id)
                .WillCascadeOnDelete(false);
        }
    }
}
