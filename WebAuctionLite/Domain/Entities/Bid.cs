using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Entities.Enums;

namespace WebAuctionLite.Domain.Entities
{
    public class Bid : BaseEntity
    {

        [DataType(DataType.Time)]
        public DateTime BetTime { get; set; }

        [Display(Name = "Bid sum")]
        public decimal BidSum { get; set; }

        public BidStatus BidStatus { get; set; }
        public string BuyerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid LotId { get; set; }
        public Lot Lot { get; set; }
    }
}
