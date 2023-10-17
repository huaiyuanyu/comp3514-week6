using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.Repositories;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Pages.ProductOrder
{
    public class EditModel : PageModel
    {
        private readonly WebApplication___Week_5.Data.ApplicationDbContext _context;
        ProductOrderVMRepo _productOrderVMRepo = null;

        public EditModel(WebApplication___Week_5.Data.ApplicationDbContext context)
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
                var wasUpdated = _productOrderVMRepo.Edit(ProductOrderVM);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderVMExists(ProductOrderVM.ProductOrderID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Edit", new
            {
                ProductID = ProductOrderVM.ProductID,
                OrderID = ProductOrderVM.OrderID
            });
        }

        private bool ProductOrderVMExists(int id)
        {
            return (_context.ProductOrderVM?.Any(e => e.ProductOrderID == id)).GetValueOrDefault();
        }
    }

}
