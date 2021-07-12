using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAuctionLite.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Money amount")]
        public decimal MoneyAccount { get; set; }

        public ICollection<Bid> Bids { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Lot> Lots { get; set; }
    }
}
