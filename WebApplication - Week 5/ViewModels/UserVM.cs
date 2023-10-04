using System.ComponentModel.DataAnnotations;

namespace WebApplication___Week_5.ViewModels
{
    public class UserVM
    {
        [Key]
        public string Email { get; set; }
    }

}
