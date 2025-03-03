﻿using CarSharingApp.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CarSharingApp.Models
{
    public class CarBrand
    {
        [Key]
        public int CarBrandId { get; set; }
        [Required]
        [CarBrandValidation]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Car>? Car {get; set;}
    }
}
