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
    public class BookBoatModel : PageModel
    {
        private readonly IBoatRepository repo;
        public BookingBoatService service { get; }
        public Dictionary<int, Boat> OrderedBoats { get; set; }
        public Boat Boat { get; set; }

        //public Order Order { get; set; }
        //public SelectList UserCodes { get; set; }
        public BookBoatModel(IBoatRepository repository, BookingBoatService boatOrder)
        {
            repo = repository;
            service = boatOrder;
            OrderedBoats = new Dictionary<int, Boat>();

            //Dictionary<int, User> users = urepo.GetAllUsers();

            //UserCodes = new SelectList(users.Values, "Id","Name");
        }
        public IActionResult OnGet(int id)
        {
            Boat boat = repo.GetBoat(id);
            service.Add(boat);
            OrderedBoats = service.GetOrderedBoat();
            return Page();
        }
        public IActionResult OnPostDelete(int id)
        {
            service.RemoveOrder(id);
            OrderedBoats = service.GetOrderedBoat();
            return Page();
        }
    }
}