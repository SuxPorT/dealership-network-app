﻿using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.Entities
{
    public class Sale : BaseEntity
    {
        [Required(ErrorMessage = "The \"price\" field is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The \"vehicleChassisNumber\" field is required")]
        [MaxLength(17, ErrorMessage = "The vehicle chassis number must have a maximum of 17 characters")]
        public string VehicleChassisNumber { get; set; }
        public Vehicle Vehicle { get; set; }

        [Required(ErrorMessage = "The \"sellerId\" field is required")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
