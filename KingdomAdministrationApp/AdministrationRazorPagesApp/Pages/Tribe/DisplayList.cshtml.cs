using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingdomDataLibrary.Data;
using KingdomDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministrationRazorPagesApp.Pages.Tribe
{
    public class DisplayListModel : PageModel
    {
        private readonly ITribeData _tribeData;
        private readonly ICitizenData _citizenData;

        public TribeModel Tribe { get; set; }
        public string LeaderName { get; set; }

        public List<TribeModel> Tribes { get; set; }

        public DisplayListModel(ITribeData tribeData, ICitizenData citizenData)
        {
            _tribeData = tribeData;
            _citizenData = citizenData;
        }
        public async Task OnGet()
        {
            Tribes = await _tribeData.GetTribe();

        }
    }
}