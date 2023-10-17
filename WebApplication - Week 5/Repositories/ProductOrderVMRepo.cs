using Microsoft.EntityFrameworkCore;
using WebApplication___Week_5.Data;
using WebApplication___Week_5.ViewModels;

namespace WebApplication___Week_5.Repositories
{
    public class ProductOrderVMRepo
    {
        ApplicationDbContext _context = null;
        public ProductOrderVMRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // You could potentially place this in an Order repository
        // instead. Whatever you do try to be consistent and try
        // to eliminate code duplication where possible.
        public async Task<bool> Edit(ProductOrderVM model)
        {
            Order order = await _context.Orders.Where(po => po.OrderID == model.OrderID
                        && po.ProductID == model.ProductID).FirstOrDefaultAsync();

            // Note that only quanity is being modified here.
            order.Quantity = model.Quantity;
            order.Discounted = model.Discounted;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; // Something went wrong. 
            }
        }

        public async Task<bool> Delete(ProductOrderVM model)
        {
            Order order = await _context.Orders.Where(po => po.OrderID == model.OrderID
                        && po.ProductID == model.ProductID).FirstOrDefaultAsync();


            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            } else { return false; }
            
        }

        public async Task<IList<ProductOrderVM>> All()
        {
            var query = from p in _context.Products
                        from o in _context.Orders
                        where p.ProductID == o.ProductID
                        select new ProductOrderVM()
                        {
                            Discounted = o.Discounted,
                            Price = p.Price,
                            OrderID = o.OrderID,
                            ProductID = o.ProductID,
                            ProductName = p.ProductName,
                            ProductOrderID = 0,
                            Quantity = o.Quantity,
                        };

            // <-- notice the `await` here. 
            var productOrderList = await query.ToListAsync();

            // Must add unique fake key for view model to keep template happy.
            int counter = 0;
            foreach (var row in productOrderList)
            {
                row.ProductOrderID = counter++;
            }
            return productOrderList;
        }

        public async Task<ProductOrderVM> GetDetail(int ProductID, int OrderID)
        {

            var query = from p in _context.Products
                        from o in _context.Orders
                        where p.ProductID == o.ProductID
                        && o.ProductID == ProductID && o.OrderID == OrderID
                        select new ProductOrderVM()
                        {
                            Discounted = o.Discounted,
                            Price = p.Price,
                            OrderID = o.OrderID,
                            ProductID = o.ProductID,
                            ProductName = p.ProductName,
                            ProductOrderID = 0,
                            Quantity = o.Quantity,
                        };

            // <-- notice the `await` here. 
            var productOrder = await query.FirstOrDefaultAsync().ConfigureAwait(true);
            return productOrder;
        }

    }

}
