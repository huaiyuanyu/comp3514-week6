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

namespace WebApplication___Week_5.Pages.ProductOrder
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        ProductOrderVMRepo _productOrderVMRepo = null;

        public IndexModel(WebApplication___Week_5.Data.ApplicationDbContext context)
        {
            _context = context;
            _productOrderVMRepo = new ProductOrderVMRepo(context);
        }

        [BindProperty]
        public List<ProductOrderVM> productMfgVMs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IList<ProductOrderVM> productmfgvm = await _productOrderVMRepo.All();
            if (productmfgvm == null)
            {
                return NotFound();
            }
            productMfgVMs = productmfgvm.ToList(); // converting 
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            var x = productMfgVMs; // This is the data
            return RedirectToPage("./Index");
        }
    }


}
