using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(Guid id);
        IQueryable<Product> GetProductsByUserId(Guid id);
        void SaveProduct(Product entity);
        void DeleteProduct(Guid id);
    }
}
