using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Domain.Entities
{
    public class TextField : BaseEntity
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Title")]
        public virtual string Title { get; set; } = "Info page";

        [Display(Name = "Text")]
        public virtual string Text { get; set; } = "Made by admin";
    }
}
