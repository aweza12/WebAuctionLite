using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        public virtual string Title { get; set; }

        [Display(Name = "Short text")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Text")]
        public virtual string Text { get; set; }

        [Display(Name = "Main img")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO Title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "SEO Description")]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "SEO Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
