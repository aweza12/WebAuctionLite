using Microsoft.EntityFrameworkCore;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Domain.Repositories.Abstract;

namespace WebAuctionLite.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public ILotsRepository Lots { get; set; }
        public IBidsRepository Bids { get; set; }
        public IProductsRepository Products { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, ILotsRepository lotsRepository, IBidsRepository bidsRepository, IProductsRepository productsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            Lots = lotsRepository;
            Bids = bidsRepository;
            Products = productsRepository;
        }
    }
}
