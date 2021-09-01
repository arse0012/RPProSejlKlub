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
    public class CheckOutModel : PageModel
    {
        private IBookingRepository repo;
        private BookingBoatService cart;
        [BindProperty]
        public int SelectedId { get; set; }
        public User BookedUser { get; set; }
        public Boat Boat { get; set; }
        [BindProperty]
        public Booking Order { get; set; }
        public SelectList UserCodes { get; set; }

        private IUserRepository Urepo { get; set; }

        public CheckOutModel(IBookingRepository repository, IUserRepository urepo, BookingBoatService brepo)
        {
            repo = repository;
            cart = brepo;
            Urepo = urepo;
            Dictionary<int, User> users = urepo.GetAllUsers();
            UserCodes = new SelectList(users.Values, "Id", "Name");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking booking = new Booking();
            booking.Code = Int32.MaxValue;
            BookedUser =Urepo.GetUser(SelectedId);
            booking.User = BookedUser;
            booking.Boats = cart.GetBookedBoat();
            booking.DateTime=DateTime.Now;
            repo.BookBoat(booking);
            return RedirectToPage("/Boats/IndexBoats");
        }
        
    }
}