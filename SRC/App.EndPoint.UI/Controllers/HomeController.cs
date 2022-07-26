﻿using App.Domain.Core.BaseData.Entity;
using App.EndPoint.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoint.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;  
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(ILogger<HomeController> logger,
               UserManager<AppUser> userManager,
                RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> SeedData()

        {
            var adminCroleCreation = await _roleManager.CreateAsync(new IdentityRole<int>("AdminRole"));
            var customerCroleCreation = await _roleManager.CreateAsync(new IdentityRole<int>("CustomerRole"));


            var adminResult = await _userManager.CreateAsync(new AppUser("admin"), "1234567");
            if (adminResult.Succeeded)
            {
                var adminUser = await _userManager.FindByNameAsync("admin");
                var addAdminRole = await _userManager.AddToRoleAsync(adminUser, "AdminRole");
            }

            var customer1Result = await _userManager.CreateAsync(new AppUser("cutomer1"), "1234567");
            if (customer1Result.Succeeded)
            {
                var customer1User = await _userManager.FindByNameAsync("cutomer1");
                var addCustomerRole = await _userManager.AddToRoleAsync(customer1User, "CustomerRole");
            }
            return Ok();
        }

    }
}