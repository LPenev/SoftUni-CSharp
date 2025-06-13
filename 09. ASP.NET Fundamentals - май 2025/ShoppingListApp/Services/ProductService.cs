using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models.Product;

namespace ShoppingListApp.Services;

public class ProductService : IProductService
{
    private readonly ShoppingListDbContext _context;

    public ProductService(ShoppingListDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddProductAsync(ProductViewModel model)
    {
        Product entity = new Product()
        {
            Name = model.Name,
            Description = model.Description,
        };

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        Console.WriteLine("Start");

        var listOfProducts = await _context.Products
            .AsNoTracking()
            .Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
            }).ToListAsync();
        ;
        return listOfProducts;
    }

    public async Task<ProductViewModel> GetByIdReadonlyAsync(int id)
    {
        return await _context.Products
            .Where(p => p.Id == id)
            .AsNoTracking()
            .Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
            }).FirstAsync();
    }

    public async Task UpdateProductAsync(ProductViewModel model)
    {
        var entity = await _context.Products
            .FirstAsync(p => p.Id == model.Id);

        entity.Name = model.Name;
        entity.Description = model.Description;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        await _context.Products
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }
}
