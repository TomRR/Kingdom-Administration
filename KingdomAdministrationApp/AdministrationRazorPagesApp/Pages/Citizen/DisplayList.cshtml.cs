using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Citizen
{
    public class DisplayListModel : PageModel
    {
        private readonly ICitizenData _citizenData;

        public List<CitizenModel> Citizens { get; set; }

        public DisplayListModel(ICitizenData citizenData)
        {
            _citizenData = citizenData;
        }
        public async Task OnGet()
        {
            Citizens = await _citizenData.GetCitizen();
        }
    }
}