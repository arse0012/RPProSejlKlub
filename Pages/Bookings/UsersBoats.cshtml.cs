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

namespace ProtoBoatRazorPage.Pages.Bookings
{
    public class UsersBoatsModel : PageModel
    {
        private IBookingRepository repo;
        public Dictionary<int, Booking> Bookings { get; private set; }
        public Boat usersBoat { get; set; }
        public SelectList UserList { get; set; }

        public UsersBoatsModel(IBookingRepository repository, IBookingRepository brepo)
        {
            repo = repository;
            Dictionary<int, Booking> bookings = brepo.GetAllBookings();
            UserList = new SelectList(bookings.Values, "Id");
        }
        public IActionResult OnGet(int id)
        {
            //Bookings = repo.GetAllBookings();
            //return Page();
            Bookings = new Dictionary<int, Booking>();
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
    }
}