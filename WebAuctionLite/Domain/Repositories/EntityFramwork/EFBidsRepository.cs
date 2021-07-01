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
    public class EFBidsRepository : IBidsRepository
    {
        private readonly AppDbContext context;
        public EFBidsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Bid> GetBids()
        {
            return context.Bids;
        }

        public Bid GetBidById(Guid id)
        {
            return context.Bids.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Bid> GetBidsByLotId(Guid id)
        {
            return context.Bids.Where(x => x.Lot.Id == id);
        }

        public IQueryable<Bid> GetBidsByUserId(Guid id)
        {
            return context.Bids.Where(x => x.ApplicationUser.Id == id);
        }

        public void SaveBid(Bid entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBid(Guid id)
        {
            context.Bids.Remove(new Bid() { Id = id });
            context.SaveChanges();
        }
    }
}
