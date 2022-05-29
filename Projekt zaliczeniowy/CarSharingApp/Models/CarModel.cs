﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CarSharingApp.Models
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Car> Car { get; set; }
    }
}
