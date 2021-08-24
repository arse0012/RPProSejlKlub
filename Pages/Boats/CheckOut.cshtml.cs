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
        public User User { get; set; }
        public Boat Boat { get; set; }
        public Order Order { get; set; }
        public SelectList UserIds { get; set; }

        public CheckOutModel(JsonOrderRepository repository, IUserRepository urepo, BookingBoatService brepo)
        {
            repo = repository;
            cart = brepo;


            Dictionary<int, User> users = urepo.GetAllUsers();
            UserIds = new SelectList(users.Values, "Id", "Name");
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
            order.OrderId = 12;
            order.User = User;
            order.Boats = cart.GetOrderedBoat();
            order.DateTime=DateTime.Now;
            repo.AddOrder(order);
            return RedirectToPage("IndexBoats");
        }
        
    }
}