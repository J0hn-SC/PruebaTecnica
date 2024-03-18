using DBDatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Tables;

namespace Prueba_técnica.Pages
{
    public class ProductModel : PageModel
    {
        private readonly DatabaseContext _context;
        [BindProperty]
        public Product Product { get; set; }
        
        public IList<Product> Products { get; set; }

        public ProductModel(DatabaseContext context)
        {
            _context = context;
            Products = new List<Product>();
        }
        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Product_ID.HasValue)
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Product");
            }
            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Product");
        }
        public async Task<IActionResult> OnPostEditAsync(int ProductId)
        {

            var productToUpdate = await _context.Products.FindAsync(ProductId);
            if (productToUpdate != null)
            {
                Product = productToUpdate;
                return Page();
            }
            var productUpdate = await _context.Products.FindAsync(Product.Product_ID);
            productUpdate.Name = Product.Name;
            productUpdate.Description = Product.Description;
            productUpdate.Price = Product.Price;
            productUpdate.Category = Product.Category;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Product");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int ProductId)
        {
            var productToDelete = await _context.Products.FindAsync(ProductId);
            if (productToDelete != null)
            {
                return NotFound();
            }
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Product");
        }

        public async Task<IActionResult> OnPostSearchAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToPage("./Product");
            }
            Products = await _context.Products
                        .Where(p => p.Name.Contains(searchTerm))
                        .ToListAsync();
            return Page();
        }

    }
}
