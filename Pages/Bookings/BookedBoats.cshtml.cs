using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Pages.Bookings
{
    public class BookedBoatsModel : PageModel
    {
        private IBookingRepository repo;
        public Dictionary<int, Booking> Bookings { get; private set; }

        public BookedBoatsModel(IBookingRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet()
        {
            Bookings = repo.GetAllBookings();
            return Page();
        }
    }
}