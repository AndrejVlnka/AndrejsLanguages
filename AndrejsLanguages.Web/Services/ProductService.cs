using Microsoft.EntityFrameworkCore;
using AndrejsLanguages.Web.Data;
using AndrejsLanguages.Web.Models;

namespace AndrejsLanguages.Web.Services;

public class ProductService
{
    private readonly LanguageDbContext productContext;

    public ProductService(LanguageDbContext context)
    {
        productContext = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await productContext
            .Products
            .Include(p => p.ProductType)
            .AsNoTracking()
            .ToListAsync();          
    }

    public async Task<Product> GetProductById(int productId)
    {
        return await productContext.Products.Where(p => p.Id == productId).AsNoTracking().FirstOrDefaultAsync();
    }
}
