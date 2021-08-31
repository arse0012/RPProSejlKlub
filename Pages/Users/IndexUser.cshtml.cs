using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Repository;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Users
{
    public class IndexUserModel : PageModel
    {
        private readonly IUserRepository _userCatalog;
        private IBookingRepository bookRepo;
        public List< Booking> Bookings { get; private set; }
        public Dictionary<int, User> Users { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexUserModel(IUserRepository repository, IBookingRepository bookBoatRepository)
        {
            _userCatalog = repository;
            bookRepo = bookBoatRepository;
        }
        public IActionResult OnGet(int id)
        {
            Bookings = new List<Booking>();
            Users = _userCatalog.GetAllUsers();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Users = _userCatalog.FilterUser(FilterCriteria);
            }
            Bookings = bookRepo.SearchBoatByCode(id);
            return Page(); 
        }
    }
}