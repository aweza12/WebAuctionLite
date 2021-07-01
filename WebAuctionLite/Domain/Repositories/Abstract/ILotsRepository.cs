using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface ILotsRepository
    {
        IQueryable<Lot> GetLots();
        Lot GetLotById(Guid id);
        Lot GetLotByUserId(Guid id);
        void SaveLot(Lot entity);
        void DeleteLot(Guid id);
    }
}
