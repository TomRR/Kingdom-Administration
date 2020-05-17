using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministrationRazorPagesApp.Pages.Citizen
{
    public class CreateModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly ITribeData _tribeData;
        private readonly IWeaponData _weaponData;

        public List<SelectListItem> TribeList { get; set; }

        [BindProperty]
        public CitizenModel Citizen { get; set; }

        public CreateModel(ICitizenData citizenData, ITribeData tribeData)
        {
            _citizenData = citizenData;
            _tribeData = tribeData;
        }

        public async Task OnGet()
        {
            var tribe = await _tribeData.GetTribe();

            TribeList = new List<SelectListItem>();

            tribe.ForEach(x =>
            {
                TribeList.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
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
            int id = await _citizenData.CreateCitizen(Citizen);

            return RedirectToPage("./DisplayById", new { Id = id });
            
        }
    }
}