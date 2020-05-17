using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministrationRazorPagesApp.Models;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Citizen
{
    public class DisplayByIdModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly ITribeData _tribeData;
        private readonly IWeaponData _weaponData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CitizenUpdateModel UpdateModel { get; set; }

        public CitizenModel Citizen { get; set; }
        public string TribeName { get; set; }
        public DisplayByIdModel(ICitizenData citizenData, ITribeData tribeData, IWeaponData weaponData)
        {
            _citizenData = citizenData;
            _tribeData = tribeData;
            _weaponData = weaponData;
        }
        public async Task<IActionResult> OnGet()
        {
            Citizen = await _citizenData.GetCitizenById(Id);

            if (Citizen != null)
            {
                var tribe = await _tribeData.GetTribe();

                TribeName = tribe.Where(x => x.Id == Citizen.TribeId).FirstOrDefault()?.Name;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _citizenData.UpdateCitizenName(UpdateModel.Id, UpdateModel.Name);

            return RedirectToPage("./DisplayById", new { UpdateModel.Id });
        }
    }
}