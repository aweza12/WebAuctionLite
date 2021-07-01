using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Domain.Repositories.Abstract;
using WebAuctionLite.Entities;

namespace WebAuctionLite.Domain.Repositories.EntityFramework
{
    public class EFProductsRepository : IProductsRepository
    {
        private readonly AppDbContext context;
        public EFProductsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProductsByUserId(Guid id)
        {
            return context.Products.Where(x => x.ApplicationUser.Id == id);
        }

        public void SaveProduct(Product entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            context.Products.Remove(new Product() { Id = id });
            context.SaveChanges();
        }
    }
}
