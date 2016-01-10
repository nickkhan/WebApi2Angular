using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDevQuiz.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]        
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int PassengerSeatingCount { get; set; }
    }
}
