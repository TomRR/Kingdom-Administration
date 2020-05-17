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
    }
}