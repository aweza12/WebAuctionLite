using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
