using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class BoatDetailModel : PageModel
    {
        private readonly IBoatRepository repo;
        public Dictionary<int, Boat> Boats { get; set; }
        [BindProperty]
        public Boat Boat { get; set; }
        public BoatDetailModel(IBoatRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boat = repo.GetBoat(id);
            return Page();
        }
    }
}