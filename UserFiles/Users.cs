using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FullPetflix.AnimalFiles;
using FullPetflix.UserFiles;
using FullPetflix.ProductFiles;
using FullPetflix.OrderFiles;

namespace FullPetflix.UserFiles
{
    public class Users
    {
        [Key]
        public int userId { get; set; }

        public bool? isAdmin { get; set; } = false;

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [EmailAddress]
        [StringLength(120)]
        public string email { get; set; } = string.Empty;

        [StringLength(60)]
        public string? password { get; set; } // Hash this before saving

        public string? location { get; set; }
        public string? delivery_method { get; set; }
        public Gender? gender { get; set; }

        [StringLength(15)]
        public string? phone { get; set; }

        [JsonIgnore]
        public DateTime? birthDay { get; set; }

        [JsonPropertyName("birthDay")]
        public string? BirthDayFormatted
        {
            get => birthDay?.ToString("yyyy-MM-dd");
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedDate))
                {
                    // Ensure UTC
                    birthDay = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);
                }
            }
        }

        public string? ProfilePic { get; set; }
        public string? availableDays { get; set; }
        public string? availableHours { get; set; }
        public double? rating { get; set; } = 0;
        public string? bio { get; set; }

        public List<Animal> Animals { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        public List<Order>? Orders { get; set; } = new(); // Add this

    }
}