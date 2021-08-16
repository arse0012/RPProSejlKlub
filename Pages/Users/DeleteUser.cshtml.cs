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
    public class DeleteUserModel : PageModel
    {
        //private UserCatalog catalog;
        private IUserRepository catalog;
        [BindProperty]
        public User boatUser { get; set; }
        public DeleteUserModel(IUserRepository repository)
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
            catalog.DeleteUser(boatUser);
            return RedirectToPage("IndexUser");
        }
    }
}