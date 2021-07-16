using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Lot> Lots { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
