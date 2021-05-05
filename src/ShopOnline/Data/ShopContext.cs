using Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ConfirmStatus> ConfirmStatus { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ImageDetail> ImageDetails { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShopInformation> ShopInformations { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Statistical> Statisticals { get; set; }
        public virtual DbSet<Suppelier> Suppeliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TagProduct> TagProducts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<ImageDetail>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.UrlImage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UrlImage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Moblie)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Instagram)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Youtube)
                .IsUnicode(false);

            modelBuilder.Entity<ShopInformation>()
                .Property(e => e.Zalo)
                .IsUnicode(false);

            modelBuilder.Entity<Statistical>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Suppelier>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Suppelier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
