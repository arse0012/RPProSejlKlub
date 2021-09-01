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
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Bookings
{
    public class UsersBoatsModel : PageModel
    {
        private IBookingRepository repo;
        public List<Booking> Bookings { get; private set; }
        public UsersBoatsModel(IBookingRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Bookings = new List<Booking>();
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Bookings = repo.SearchBoatByCode(id);
            if (Bookings == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(Booking bookedBoat)
        {
            repo.RemoveBookedBoat(bookedBoat);
            return Page();
        }
    }
}