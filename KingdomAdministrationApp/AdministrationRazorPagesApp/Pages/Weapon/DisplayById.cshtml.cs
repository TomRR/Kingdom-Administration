using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministrationRazorPagesApp.Models;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Weapon
{
    public class DisplayByIdModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly IWeaponData _weaponData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public WeaponUpdateModel UpdateModel { get; set; }

        public WeaponModel Weapon { get; set; }
        public string CitizenName { get; set; }
        public DisplayByIdModel(ICitizenData citizenData, IWeaponData weaponData)
        {
            _citizenData = citizenData;
            _weaponData = weaponData;
        }
        public async Task<IActionResult> OnGet()
        {
            Weapon = await _weaponData.GetWeaponById(Id);

            if (Weapon != null)
            {
                var citizen = await _citizenData.GetCitizen();

                CitizenName = citizen.Where(x => x.Id == Weapon.CitizenId).FirstOrDefault()?.Name;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _weaponData.UpdateMagicalValue(UpdateModel.Id, UpdateModel.MagicalValue);

            return RedirectToPage("./DisplayById", new { UpdateModel.Id });
        }
    }
}