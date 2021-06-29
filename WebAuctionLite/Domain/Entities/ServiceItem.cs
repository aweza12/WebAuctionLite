using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Domain.Entities
{
    public class ServiceItem : BaseEntity
    {
        [Required(ErrorMessage = "Fill name of action")]
        [Display(Name = "Name of action")]
        public override string Title { get; set; }

        [Display(Name = "Short name")]
        public override string Subtitle { get; set; }

        [Display(Name = "Full name")]
        public override string Text { get; set; }
    }
}
