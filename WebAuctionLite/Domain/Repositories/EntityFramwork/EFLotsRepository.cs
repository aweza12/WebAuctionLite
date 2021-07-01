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
    public class EFLotsRepository : ILotsRepository
    {
        private readonly AppDbContext context;
        public EFLotsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Lot> GetLots()
        {
            return context.Lots;
        }

        public Lot GetLotById(Guid id)
        {
            return context.Lots.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Lot> GetLotsByUserId(Guid id)
        {
            return context.Lots.Where(x => x.ApplicationUser.Id == id);
        }

        public void SaveLot(Lot entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteLot(Guid id)
        {
            context.Lots.Remove(new Lot() { Id = id });
            context.SaveChanges();
        }
    }
}
