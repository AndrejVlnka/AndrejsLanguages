using Microsoft.EntityFrameworkCore;
using AndrejsLanguages.Web.Models;

namespace AndrejsLanguages.Web.Data;

public class LanguageDbContext : DbContext
{
	public LanguageDbContext(DbContextOptions<LanguageDbContext> options) : base(options) { }

	public DbSet<Product> Products => Set<Product>();
	public DbSet<ProductType> ProductTypes => Set<ProductType>();
	public DbSet<Review> Reviews => Set<Review>();
	public DbSet<ReviewPhoto> ReviewsPhoto => Set<ReviewPhoto>();
}


