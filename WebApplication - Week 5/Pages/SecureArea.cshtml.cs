using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication___Week_5.Data;

namespace WebApplication___Week_5.Pages
{
    [Authorize(Roles = "Admin,Manager")]
    public class SecureAreaModel : PageModel
    {
        // Declare class level db context variable.
        private readonly ApplicationDbContext db;

        // Setup constructor with initialization for db context.
        public SecureAreaModel(ApplicationDbContext db) => this.db = db;

        public string userName = "";
        public MyRegisteredUser registeredUser = null;

        // This line must be in the controller.

        public void OnGet()
        {
            // This line of code uses the framework to 
            // determine who the current logged in user is.
            userName = User.Identity.Name;

            // Retrieves data from the custom users table.
            // Usually this section would be in a repository.
            registeredUser = db.MyRegisteredUsers.Where(ru => ru.Email == userName)
                                .FirstOrDefault();//FirstOrDefault() gets 1 item
        }
    }

}
