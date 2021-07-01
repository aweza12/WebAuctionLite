﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Entities.Enums;

namespace WebAuctionLite.Domain.Entities
{
    public class Lot : BaseEntity
    {
        [DataType(DataType.Time)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Minimum bet move")]
        public decimal MinBetMove { get; set; }

        [Display(Name = "Minimum price of product")]
        public decimal MinPrice { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<Bid> Bids { get; set; }

        //public int BuyerId { get; set; }
        //public Buyer Buyer { get; set; }
        public LotStatus LotStatus { get; set; }
    }
}
