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

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class CheckOutModel : PageModel
    {
        private JsonOrderRepository repo;
        private BookingBoatService cart;
        [BindProperty]
        public int SelectedId { get; set; }
        public User User { get; set; }
        public Boat Boat { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        public SelectList UserCodes { get; set; }

        private IUserRepository Urepo { get; set; }

        public CheckOutModel(JsonOrderRepository repository, IUserRepository urepo, BookingBoatService brepo)
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
            Order order = new Order();
            order.Code = 12;
            User =Urepo.GetUser(SelectedId);
            order.User = User;
            order.Boats = cart.GetOrderedBoat();
            order.DateTime=DateTime.Now;
            repo.AddOrder(order);
            return RedirectToPage("IndexBoats");
        }
        
    }
}