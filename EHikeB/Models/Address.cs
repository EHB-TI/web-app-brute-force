using EHikeB.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Street")]
        public string StreetName { get; set; }
        [Display(Name = "Number")]
        public string StreetNumber { get; set; }
        [Required]
        [ZipValidation(ErrorMessage = "Please enter a valid zip code")]
        [Display(Name = "ZIP code")]
        public string ZipCode { get; set; }
        [NotMapped]
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        public string Country { get => "Belgium";}
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string CustomerId { get; set; }
    }
}
    