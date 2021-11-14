using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHikeB.Models
{
    public enum Energy
    {
        DIESEL,
        BENZINE,
        ELECTRICITY
    }
    public class Car
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Brand and model of the car")]
        public string Model { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Number of seats available (including driver)")]
        public int Seats { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Type of Energy (diesel, benzine, electricity)")]
        public Energy Energy { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Plate number of the vehicle")]
        public string Plate { get; set; }
        [Required]
        [NotMapped]
        [Compare(nameof(Plate))]
        [Display(Name = "Retype the plate number")]
        public string PlateControl { get; set; }

    
    }
}
