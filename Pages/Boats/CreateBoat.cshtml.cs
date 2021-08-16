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
    public class CreateBoatModel : PageModel
    {
        //private BoatCatalog catalog;
        private IBoatRepository catalog;
        [BindProperty]
        public Boat Boat { get; set; }
        public CreateBoatModel(IBoatRepository repository)
        {
            catalog = repository;
        }
        public void OnGet(int id)
        {
            Boat = catalog.GetBoat(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.AddBoat(Boat);
            return RedirectToPage("IndexBoats");
        }
    }
}