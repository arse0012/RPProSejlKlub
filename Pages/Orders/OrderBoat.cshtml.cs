using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Pages.Orders
{
    public class OrderBoatModel : PageModel
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IBoatRepository _boatRepo;
        [BindProperty]
        public User BoatUser { get; set; }
        public Boat Boat { get; set; }
         
        public Order Order { get; set; }
        public SelectList UserCodes { get; set; }
        public OrderBoatModel(IBoatRepository repository, IUserRepository urepo)
        {
            _boatRepo = repository;

            Dictionary<int, User> users = urepo.GetAllUsers();

            UserCodes = new SelectList(users.Values, "Id","Name");
        }
        public IActionResult OnGet(int id)
        {
            Boat = _boatRepo.GetBoat(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            _orderRepo.AddOrder(Order);
            return Redirect("IndexBoats");
        }
    }
}