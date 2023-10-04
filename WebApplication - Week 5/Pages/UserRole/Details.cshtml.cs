using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.Repositories;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Pages.UserRole
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        UserRoleRepo _userRepo = null;

        // Needed to access built-in methods of the Identity framework.
        private IServiceProvider _serviceProvider;

        public DetailsModel(WebApplication___Week_5.Data.ApplicationDbContext context,
                            IServiceProvider serviceProvider)
        {
            _context = context;
            _userRepo = new UserRoleRepo(serviceProvider);
            _serviceProvider = serviceProvider;
        }

        //  public RoleVM RoleVM { get; set; } = default!;
        public List<RoleVM> RoleVM { get; set; } = default!;
        public string requestedUser { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(string id)
        {
            requestedUser = id;
            RoleVM = await _userRepo.GetUserRoles(id);
            return Page();
        }
    }

}
