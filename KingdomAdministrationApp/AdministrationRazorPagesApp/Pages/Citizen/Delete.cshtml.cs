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
    public class DeleteModel : PageModel
    {
        private readonly ICitizenData _citizenData;
        
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public CitizenModel Citizen { get; set; }

        public DeleteModel(ICitizenData citizenData)
        {
            _citizenData = citizenData;
        }
        public async Task OnGet()
        {
            Citizen = await _citizenData.GetCitizenById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _citizenData.DeleteCitizen(Id);

            return RedirectToPage(".Create");
        }
    }
}