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
        private readonly IUserRepository _userCatalog;
        [BindProperty]
        public User BoatUser { get; set; }
        public DeleteUserModel(IUserRepository repository)
        {
            _userCatalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            BoatUser = _userCatalog.GetUser(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            _userCatalog.DeleteUser(BoatUser);
            return RedirectToPage("IndexUser");
        }
    }
}