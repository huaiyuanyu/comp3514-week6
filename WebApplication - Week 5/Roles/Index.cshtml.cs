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

namespace WebApplication___Week_5.Roles
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        RoleRepo _roleRepo = null;

        public IndexModel(WebApplication___Week_5.Data.ApplicationDbContext context)
        {
            _context = context;
            _roleRepo = new RoleRepo(context);
        }

        public List<RoleVM> RoleVM { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoleVM = await _roleRepo.GetAll();
        }
    }

}
