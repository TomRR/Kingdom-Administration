using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Weapon
{
    public class DisplayListModel : PageModel
    {
        private readonly IWeaponData _weaponData;
        private readonly ICitizenData _citizenData;

        public WeaponModel Weapon { get; set; }
        public string Owner { get; set; }

        public List<WeaponModel> Weapons { get; set; }

        public DisplayListModel(IWeaponData weaponData, ICitizenData citizenData)
        {
            _weaponData = weaponData;
            _citizenData = citizenData;
        }
        public async Task OnGet()
        {
            Weapons = await _weaponData.GetWeapon();

        }
    }
}