namespace WeiShopModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeiShopDb : DbContext
    {
        public WeiShopDb()
            : base("name=WeiShopDb")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChis { get; set; }
        public virtual DbSet<OrderBillFath> OrderBillFaths { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProPhoto> ProPhotoes { get; set; }
        public virtual DbSet<ProReview> ProReviews { get; set; }
        public virtual DbSet<RevPhoto> RevPhotoes { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Sort> Sorts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Account>()
                .Property(e => e.BillCode)
                .IsUnicode(false);

            modelBuilder.Entity<Banner>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.OpenId)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderBillFaths)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ProReviews)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShoppingCarts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notice>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.ProCode)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.SunPick)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.OrderPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.ExpressPrice)
                .HasPrecision(3, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.Sunprice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBillFath>()
                .HasMany(e => e.OrderBillChis)
                .WithRequired(e => e.OrderBillFath)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.OrderBillFaths)
                .WithRequired(e => e.Payment1)
                .HasForeignKey(e => e.Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Intro)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.SellPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.CostPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderBillChis)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProPhotoes)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProReviews)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShoppingCarts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stocks)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sorts)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProSort").MapLeftKey("ProCode").MapRightKey("SortCode"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProTag").MapLeftKey("ProCode").MapRightKey("TagId"));

            modelBuilder.Entity<ProPhoto>()
                .Property(e => e.ProCode)
                .IsUnicode(false);

            modelBuilder.Entity<ProReview>()
                .Property(e => e.ProCode)
                .IsUnicode(false);

            modelBuilder.Entity<ProReview>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<ProReview>()
                .HasMany(e => e.RevPhotoes)
                .WithRequired(e => e.ProReview)
                .HasForeignKey(e => e.RevId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevPhoto>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.ProCode)
                .IsUnicode(false);

            modelBuilder.Entity<Sort>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Sort>()
                .Property(e => e.UpCode)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.ProCode)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.BillCode)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Parameter)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.value)
                .IsUnicode(false);
        }
    }
}
