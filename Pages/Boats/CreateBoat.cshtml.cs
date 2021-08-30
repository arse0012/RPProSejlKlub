﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using ProtoBoatRazorPage.Services;

namespace ProtoBoatRazorPage.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private readonly IBoatRepository _boatCatalog;
        [BindProperty]
        public Boat Boat { get; set; }
        public CreateBoatModel(IBoatRepository repository)
        {
            _boatCatalog = repository;
        }
        public void OnGet(int id)
        {
            Boat = _boatCatalog.GetBoat(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _boatCatalog.AddBoat(Boat);
            return RedirectToPage("IndexBoats");
        }
    }
}