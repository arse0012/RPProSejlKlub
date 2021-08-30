using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Bookings
{
    public class BookBoatModel : PageModel
    {
        private readonly IBoatRepository repo;
        public BookingBoatService service { get; }
        public Dictionary<int, Boat> BookedBoats { get; set; }
        public Boat Boat { get; set; }

        public BookBoatModel(IBoatRepository repository, BookingBoatService boatOrder)
        {
            repo = repository;
            service = boatOrder;
            BookedBoats = new Dictionary<int, Boat>();
        }
        public IActionResult OnGet(int id)
        {
            Boat boat = repo.GetBoat(id);
            service.Add(boat);
            BookedBoats = service.GetBookedBoat();
            return Page();
        }
        public IActionResult OnPostDelete(int id)
        {
            service.RemoveBooking(id);
            BookedBoats = service.GetBookedBoat();
            return Page();
        }
    }
}