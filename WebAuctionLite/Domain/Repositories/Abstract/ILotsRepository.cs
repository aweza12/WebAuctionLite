using System;
using System.Linq;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Entities.Enums;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface ILotsRepository
    {
        IQueryable<Lot> GetLots();
        Lot GetLotById(Guid id);
        Lot GetLotByProductId(Guid id);
        IQueryable<Lot> GetLotsByUserId(Guid id);
        IQueryable<Lot> GetLotsByEndDateTime(DateTime dateTime);
        void ChangeStatus(Lot entity, LotStatus lotStatus);
        void SaveLot(Lot entity);
        void DeleteLot(Guid id);
    }
}
