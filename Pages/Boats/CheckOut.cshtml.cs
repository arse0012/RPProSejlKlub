using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Repository;

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class CheckOutModel : PageModel
    {
        private IBoatRepository repo;
        public User boatUser { get; set; }
        public Boat Boat { get; set; }
        public SelectList UserIds { get; set; }

        public CheckOutModel(IBoatRepository repository, IUserRepository urepo)
        {
            repo = repository;
            Dictionary<int, User> users = urepo.GetAllUsers();
            UserIds = new SelectList(users.Values, "Id", "Name");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        
    }
}