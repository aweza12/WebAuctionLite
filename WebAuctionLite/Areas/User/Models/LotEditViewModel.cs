using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Areas.User.Models
{
    public class LotEditViewModel
    {
        [Required]
        [Display(Name = "End of lot")]
        [DataType(DataType.Time)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Minimum bet move")]
        public decimal MinBetMove { get; set; }

        [Required]
        [Display(Name = "Minimum price of product")]
        public decimal MinPrice { get; set; }

        [Required]
        [Display(Name = "Id of product")]
        public Guid ProductId { get; set; }
    }
}
