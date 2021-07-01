using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface IBidsRepository
    {
        IQueryable<Bid> GetBids();
        Bid GetBidById(Guid id);
        IQueryable<Bid> GetBidsByLotId(Guid id);
        IQueryable<Bid> GetBidsByUserId(Guid id);
        void SaveBid(Bid entity);
        void DeleteBid(Guid id);
    }
}
