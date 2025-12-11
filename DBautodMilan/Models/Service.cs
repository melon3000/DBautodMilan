using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBautodMilan.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        // Инициализация коллекции для предотвращения NRE
        public ICollection<CarService> CarServices { get; set; } = new List<CarService>();
    }
}
