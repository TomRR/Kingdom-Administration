using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DataLibrary.Models
{
    public class WeaponModel
    {
        public int Id { get; set; }
        public string Typ { get; set; }

        public int MagicalValue { get; set; }
    }
}
