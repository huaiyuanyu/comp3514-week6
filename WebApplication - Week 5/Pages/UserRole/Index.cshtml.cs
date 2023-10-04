using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Pages.UserRole
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication___Week_5.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserVM> UserVM { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserVM != null)
            {
                UserVM = await _context.UserVM.ToListAsync();
            }
        }
    }
}
