using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class IndexBoatsModel : PageModel
    {
        //private BoatCatalog catalog;
        private IBoatRepository catalog;
        public Dictionary<int, Boat> Boats { get; private set; }
        [BindProperty (SupportsGet =true)]
        public string FilterCriteria { get; set; }
        public IndexBoatsModel(IBoatRepository repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet()
        {
            Boats = catalog.GetAllBoats();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = catalog.FilterBoat(FilterCriteria);
            }
            return Page();
        }
    }
}