using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministrationRazorPagesApp.Models;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Tribe
{
    public class DisplayByIdModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly ITribeData _tribeData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TribeUpdateModel UpdateModel { get; set; }

        public TribeModel Tribe { get; set; }
        public string LeaderName { get; set; }
        public DisplayByIdModel(ICitizenData citizenData, ITribeData tribeData)
        {
            _citizenData = citizenData;
            _tribeData = tribeData;
        }
        public async Task<IActionResult> OnGet()
        {
            Tribe = await _tribeData.GetTribeById(Id);

            if (Tribe != null)
            {
                var citizen = await _citizenData.GetCitizen();

                LeaderName = citizen.Where(x => x.Id == Tribe.LeaderId).FirstOrDefault()?.Name;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _tribeData.UpdateTribeName(UpdateModel.Id, UpdateModel.Name);

            return RedirectToPage("./DisplayById", new { UpdateModel.Id });
        }
    }
}