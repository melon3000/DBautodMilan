using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBautodMilan.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public ICollection<CarService> CarServices { get; set; }
    }
}
