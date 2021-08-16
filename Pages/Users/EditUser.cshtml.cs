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
    public class EditUserModel : PageModel
    {
        //private UserCatalog catalog;
        private IUserRepository catalog;
        [BindProperty]
        public User boatUser { get; set; }
        public EditUserModel(IUserRepository repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            boatUser = catalog.GetUser(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateUser(boatUser);
            return RedirectToPage("IndexUser");
        }
    }
}