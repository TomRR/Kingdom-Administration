using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingdomDataLibrary.Models
{
    public class WeaponModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "You need to keep the typ to a max of 50 characters")]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 characters")]
        public string Typ { get; set; }
        [Required]
        [DisplayName("Magical Value")]
        [Range(0, 100000, ErrorMessage = "Please choose a value beween 0 and 100.000")]
        public int MagicalValue { get; set; }
    }
}
