using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Data
{
    public class MyRegisteredUser
    {
        [Key]
        [Required]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        public bool Discounted { get; set; }
        public int Quantity { get; set; }

        // Parent navigation property
        // The question mark enables  nullable navigation properties.
        // You will need this 
        // for Create and Edit scaffolding to work properly.
        public virtual Product? Product { get; set; }
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Produce Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Navigation properties.
        // Child.        
        // The question mark enables nullable navigation properties.
        // You will need this 
        // for Create and Edit scaffolding to work properly.
        public virtual ICollection<Order>? Orders { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyRegisteredUser> MyRegisteredUsers { get; set; }
        public DbSet<WebApplication___Week_5.ViewModels.RoleVM> RoleVM { get; set; } = default!;
        public DbSet<WebApplication___Week_5.ViewModels.UserVM> UserVM { get; set; } = default!;
        public DbSet<WebApplication___Week_5.ViewModels.UserRoleVM> UserRoleVM { get; set; } = default!;

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // REMEMBER TO ADD THIS IF INCLUDING IDENTITY TABLES
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasKey(po => new
                {
                    po.ProductID,
                    po.OrderID
                });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<Order>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(fk => new
                {
                    fk.ProductID
                })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Oranges", Price = 23.48m },
                new Product { ProductID = 2, ProductName = "Apples", Price = 38.45m },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Gary's Peaches",
                    Price = 38.45m
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1000,
                    ProductID = 1,
                    Quantity = 10,
                    Discounted = false
                },
                new Order
                {
                    OrderID = 1001,
                    ProductID = 2,
                    Quantity = 23,
                    Discounted = true
                });
        }

        public DbSet<WebApplication___Week_5.ViewModels.ProductOrderVM> ProductOrderVM { get; set; } = default!;




    }

}