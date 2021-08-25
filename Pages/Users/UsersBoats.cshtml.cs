using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Pages.Users
{
    public class UsersBoatsModel : PageModel
    {
        private IOrderRepository repo;
        public Dictionary<int, Order> Orders { get; private set; }

        public UsersBoatsModel(IOrderRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(User user)
        {
            Orders = new Dictionary<int, Order>();
            if (ModelState.IsValid)
            {
                return NotFound();
            }

            if (Orders == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}