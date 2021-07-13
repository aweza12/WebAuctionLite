using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Areas.User.Models
{
    public class AddBidViewModel
    {
        [Required]
        [Display(Name = "Lot id")]
        public Guid LotId { get; set; }
        [Required]
        [Display(Name = "Bid sum")]
        public decimal BidSum { get; set; }
    }
}
