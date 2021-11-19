using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public float lng { get; set; }
        public float lat { get; set; }
    }
}
