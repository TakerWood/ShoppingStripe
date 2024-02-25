using Microsoft.EntityFrameworkCore;
using ShoppingStripe.Data.Context;
using ShoppingStripe.Data.Entities;
using ShoppingStripe.Infrastructure;

namespace ShoppingStripe.Services;

public class ProductsService : IProductsService
{
    private readonly MyDbContext _dbContext;

    public ProductsService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ProductEntity>> GetProductsAsync(int page,int pageSize, 
        CancellationToken cancellationToken)
    {
        var response = await _dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);
        
        response = response.Skip(page * pageSize).Take(pageSize).ToList();
        
        //todo check if null + add log
        
        return response;
    }
    
    public async Task SetProductAsync(ProductEntity product, CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            //todo add log
            Console.WriteLine(e.InnerException!.Message);
            throw;
        }

    }
}