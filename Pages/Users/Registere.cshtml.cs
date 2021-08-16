using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages
{
    public class RegistereModel : PageModel
    {
        //private UserCatalog catalog;
        private IUserRepository catalog;
        [BindProperty]
        public User boatUser{ get; set; }
        public RegistereModel(IUserRepository repository)
        {
            catalog = repository;
        }
        public void OnGet(int id)
        {
            boatUser = catalog.GetUser(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.AddUser(boatUser);
            return RedirectToPage("IndexUser");
        }
    }
}