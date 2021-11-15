using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        public Customer Driver { get; set; }
        public Car Car { get; set; }
        [Required]
        [Display(Name = "Departure location")]
        public string StartLocation { get; set; }
        [Required]
        [Display(Name = "Arrival location")]
        public string EndLocation { get; set; }
        [Required]
        [Display(Name = "Departure time")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Meeting time at arrival location")]
        public DateTime DeviationTime { get; set; }
        [Required]
        public Status Status { get; set; }
        public ICollection<Customer> Hikers { get; set; }

        public Session(int sessionID, string startLocation, string endLocation, DateTime startTime, DateTime deviationTime, Status status)
        {
            SessionID = sessionID;
            StartLocation = startLocation;
            EndLocation = endLocation;
            StartTime = startTime;
            DeviationTime = deviationTime;
            Status = status;
        }
    }

}
