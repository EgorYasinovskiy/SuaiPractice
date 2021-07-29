using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
    public class Picture
    {
        [Key]
        public Guid Id { get; set; }
        public string PicturePath { get; set; }
    }
}
