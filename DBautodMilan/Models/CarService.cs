using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBautodMilan.Models
{
    public class CarService
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime DateOfService { get; set; }
        public int Mileage { get; set; }
    }
}
