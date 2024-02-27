using ShoppingStripe.Infrastructure;
using ShoppingStripe.Models;

namespace ShoppingStripe.Services;

public class ProductsService : IProductsService
{
    public List<ProductResponse> GetProductsAsync()
    {
        return new List<ProductResponse>
        {
            new()
            {
                Id = 1,
                Name = "Iphone 11",
                Imageurl = "https://content.rozetka.com.ua/goods/images/big/37399220.jpg",
                Price = 350
            },
            new()
            {
                Id = 2,
                Name = "Iphone XR",
                Imageurl = "https://content1.rozetka.com.ua/goods/images/big/364834195.jpg",
                Price = 630
            },
            new()
            {
                Id = 3,
                Name = "Iphone 12 Pro",
                Imageurl = "https://www.apple.com/newsroom/images/product/iphone/standard/iPhone_XR_white-back_09122018_carousel.jpg.large.jpg",
                Price = 170
            }
        };
    }
}