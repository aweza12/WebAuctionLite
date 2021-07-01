using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(Guid id);
        Product GetProductByLotId(Guid id);
        IQueryable<Product> GetProductByUserId(Guid id);
        void SaveProduct(Product entity);
        void DeleteProduct(Guid id);
    }
}
