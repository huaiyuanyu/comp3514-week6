using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
    }

}