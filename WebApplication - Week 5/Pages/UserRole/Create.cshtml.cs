using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.Repositories;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Pages.UserRole
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        private IServiceProvider _serviceProvider;

        public CreateModel(WebApplication___Week_5.Data.ApplicationDbContext context,
                IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        [BindProperty]
        public UserRoleVM UserRoleVM { get; set; } = default!;
        public List<UserVM> userVMs { get; set; }
        public List<RoleVM> roleVMs { get; set; }
        public string errorMessage = "";

        public async Task<IActionResult> OnGetAsync()
        {
            string errorMessage = "";
            UserRepo userRepo = new UserRepo(this._context);
            userVMs = await userRepo.All();

            RoleRepo roleRepo = new RoleRepo(this._context);
            roleVMs = await roleRepo.GetAll();

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            UserRepo userRepo = new UserRepo(this._context);
            userVMs = await userRepo.All();

            RoleRepo roleRepo = new RoleRepo(this._context);
            roleVMs = await roleRepo.GetAll();

            if (!ModelState.IsValid)
            { // Server side check.
                errorMessage = "Please ensure that an option from each dropdown is selected and try again.";
                return Page();
            }
            
            UserRoleRepo userRoleRepo = new UserRoleRepo(_serviceProvider);
            var allExistingRolesForUser = await userRoleRepo.GetUserRoles(UserRoleVM.Email);

            foreach (var item in allExistingRolesForUser)
            {
                if(item.RoleName == UserRoleVM.Role)
                {
                    errorMessage = "User already has this role.";
                    return Page();
                }
            }


            await userRoleRepo.AddUserRole(UserRoleVM.Email, UserRoleVM.Role);
            return RedirectToPage("./Index");
        }
    }

}
