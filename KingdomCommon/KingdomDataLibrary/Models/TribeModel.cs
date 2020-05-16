using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingdomDataLibrary.Models
{
    public class TribeModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Tribe Name")]
        [MaxLength(50, ErrorMessage = "You need to keep the Name to a max of 50 characters")]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 characters")]
        public string Name { get; set; }
        [DisplayName("Exist Since")]
        public string ExistSince { get; set; }
        [DisplayName("Leader Id")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Citizen from the list")]
        public int LeaderId { get; set; }
    }
}