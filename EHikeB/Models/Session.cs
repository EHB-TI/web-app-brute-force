using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Models
{
    public enum Status
    {
        OPEN,
        CLOSED,
        TERMINATED,
        ARCHIVED
    }
    public enum Paiement
    {
        PAYPAL,
        CASH,
        PAYCONIQ
    }
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        public Customer Driver { get; set; }
        public Car Car { get; set; }
        [Required]
        [Display(Name = "Departure time")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Meeting time at arrival location")]
        public DateTime DeviationTime { get; set; }
        public Address Address { get; set; }
        [Required]
        public Status Status { get; set; }
        public ICollection<Customer> Hikers { get; set; }
        public Paiement PaiementMethod { get; set; }
    }
}
