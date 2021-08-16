using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Users
{
    public class IndexUserModel : PageModel
    {
        //private UserCatalog catalog;
        private IUserRepository catalog;
        public Dictionary<int, User> Users { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexUserModel(IUserRepository repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet()
        {
            Users = catalog.GetAllUsers();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Users = catalog.FilterUser(FilterCriteria);
            }
            return Page(); 
        }
    }
}