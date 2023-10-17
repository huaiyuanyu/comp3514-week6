using System.ComponentModel.DataAnnotations;

namespace WebApplication___Week_5.ViewModels
{
    public class ProductOrderVM
    {
        [Key]
        // Generating to keep the template engine happy.
        // The template engine demands a [Key] annotation.
        // This field will not store any real data and 
        // I do not plan to display it anywhere.
        public int ProductOrderID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        public bool Discounted { get; set; }
        public int Quantity { get; set; }
    }

}
