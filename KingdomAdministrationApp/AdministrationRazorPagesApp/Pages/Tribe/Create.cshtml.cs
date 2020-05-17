using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministrationRazorPagesApp.Pages.Tribe
{
    public class CreateModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        private readonly ITribeData _tribeData;

        public List<SelectListItem> CitizenList { get; set; }

        [BindProperty]
        public TribeModel Tribe { get; set; }

        public CreateModel(ICitizenData citizenData, ITribeData tribeData)
        {
            _citizenData = citizenData;
            _tribeData = tribeData;
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

            int id = await _tribeData.CreateTribe(Tribe);

            return RedirectToPage("./DisplayById", new { Id = id });

        }
    }
}