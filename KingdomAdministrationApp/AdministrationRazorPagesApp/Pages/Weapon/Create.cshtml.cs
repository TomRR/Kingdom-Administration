using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministrationRazorPagesApp.Pages.Weapon
{
    public class CreateModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly IWeaponData _weaponData;

        public List<SelectListItem> CitizenList { get; set; }

        [BindProperty]
        public WeaponModel Weapon { get; set; }

        public CreateModel(ICitizenData citizenData, IWeaponData weaponData)
        {
            _citizenData = citizenData;
            _weaponData = weaponData;
        }

        public async Task OnGet()
        {
            var citizen = await _citizenData.GetCitizen();

            CitizenList = new List<SelectListItem>();

            citizen.ForEach(x =>
            {
                CitizenList.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            //Tax spaeter errechnen lassen - moeglich machen waffe zu erstellen wahren und rasse auswaehlen
            //var weapon = await _weaponData.GetWeapon();
            //if (Citizen.Race == "Dwarf")
            //{
            //    Citizen.Tax = Tax.TaxRat * weapon.Where(x => x.CitizenId == Citizen.Id).First().MagicalValue;
            //}
            //if (Citizen.Race == "Elb")
            //{
            //    Citizen.Tax = Citizen.HairLength * Tax.TaxRate;
            //}
            int id = await _weaponData.CreateWeapon(Weapon);

            return RedirectToPage("./DisplayById", new { Id = id });

        }
    }
}