using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CitizenModel
    {
        public int Id { get; set; }
        public string CitizenName { get; set; }
        public int Age { get; set; }
        public double HairLength { get; set; }
        public double Height { get; set; }
        public int LeaderSince { get; set; }
        public double Tax { get; set; }
        public int TribeId { get; set; }
    }
}
