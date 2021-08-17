using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        //private BoatCatalog catalog;
        private readonly IBoatRepository _boatCatalog;
        [BindProperty]
        public Boat Boat { get; set; }
        public EditBoatModel(IBoatRepository repository)
        {
            _boatCatalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boat = _boatCatalog.GetBoat(id);
            if (Boat == null)
            {
                return null;
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _boatCatalog.UpdateBoat(Boat);
            return RedirectToPage("IndexBoats");
        }
    }
}