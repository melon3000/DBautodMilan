using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBautodMilan.Models
{
    public class CarService
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        [Required]
        public DateTime DateOfService { get; set; }

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        public bool Done { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal PriceCharged { get; set; }
    }
}
