using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingdomDataLibrary.Models
{
    public class CitizenModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "You need to keep the Name to a max of 50 characters")]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 characters")]
        public string Name { get; set; }
        [Range(0, 100000, ErrorMessage = "Please choose a value beween 0 and 100.000")]
        public int Age { get; set; }
        [DisplayName("Hair Length")]
        public double HairLength { get; set; }
        [DisplayName("Is Leader Since")]
        public int LeaderSince { get; set; }
        public double Tax { get; set; }
        [DisplayName("Tribe")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a tribe from the list")]
        public int TribeId { get; set; }
    }
}
