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
        private IBoatRepository catalog;
        [BindProperty]
        public Boat Boat { get; set; }
        public EditBoatModel(IBoatRepository repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boat = catalog.GetBoat(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateBoat(Boat);
            return RedirectToPage("IndexBoats");
        }
    }
}