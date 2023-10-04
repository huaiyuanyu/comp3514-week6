using System.ComponentModel.DataAnnotations;

namespace WebApplication___Week_5.ViewModels
{
    public class UserRoleVM
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }

}
