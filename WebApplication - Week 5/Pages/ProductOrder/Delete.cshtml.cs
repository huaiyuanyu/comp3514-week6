using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.Repositories;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Pages.ProductOrder
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        ProductOrderVMRepo _productOrderVMRepo = null;

        public DeleteModel(WebApplication___Week_5.Data.ApplicationDbContext context)
        {
            _context = context;
            _productOrderVMRepo = new ProductOrderVMRepo(context);
        }

        [BindProperty]
      public ProductOrderVM ProductOrderVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int OrderID, int ProductID)
        {
            if (_context.ProductOrderVM == null)
            {
                return NotFound();
            }
            var productordervm =
                await _productOrderVMRepo.GetDetail(ProductID, OrderID);
            if (productordervm == null)
            {
                return NotFound();
            }
            else
            {
                // delete code goees here
                ProductOrderVM = productordervm;
            }
            return Page();


        }

        public async Task<IActionResult> OnPostAsync()
        {
            var errors = ModelState.Values;
            // Enable server side validation.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var wasUpdated = _productOrderVMRepo.Delete(ProductOrderVM);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./ProductOrder");
        }

        private bool ProductOrderVMExists(int id)
        {
            return (_context.ProductOrderVM?.Any(e => e.ProductOrderID == id)).GetValueOrDefault();
        }
    }
}
