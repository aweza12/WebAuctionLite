using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface ILotsRepository
    {
        IQueryable<Lot> GetLots();
        Lot GetLotById(Guid id);
        Lot GetLotByProductId(Guid id);
        IQueryable<Lot> GetLotsByUserId(Guid id);
        void SaveLot(Lot entity);
        void DeleteLot(Guid id);
    }
}
