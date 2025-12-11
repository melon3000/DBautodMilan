using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBautodMilan.Models
{
    public class CarService
    {
        // Явный первичный ключ — упрощает CRUD и миграции EF
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        // Дата и время посещения сервиса
        [Required]
        public DateTime DateOfService { get; set; }

        [Range(0, int.MaxValue)]
        public int Labisoit { get; set; }

        // Признак, что сервис уже проведён
        public bool Valmis { get; set; }

        // Цена за услугу в момент выполнения (кешируем цену, чтобы исторически хранить стоимость)
        [Range(0, (double)decimal.MaxValue)]
        public decimal PriceCharged { get; set; }
    }
}
