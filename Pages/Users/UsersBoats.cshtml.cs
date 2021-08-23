using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Pages.Users
{
    public class UsersBoatsModel : PageModel
    {
        private IBoatRepository repo;
        public Dictionary<int, Boat> Boats { get; private set; }

        public UsersBoatsModel(IBoatRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boats = new Dictionary<int, Boat>();
            if (ModelState.IsValid)
            {
                return NotFound();
            }

            Boats = repo.SearchBoatsById(id);
            if (Boats == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}