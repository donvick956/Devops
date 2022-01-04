using DelonBoard.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelonBoard.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Register model)
        {  if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = model.UserName,
                    
                   Email = model.UserName
                    
                 // Roles = model.Roles
                };

                IdentityResult result = _userManager.CreateAsync(applicationUser, model.Password).Result;
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, DelonRoles.Basic.ToString());
                    return RedirectToAction("Index", "UserRoles");
                }
            }

            return View();
        }
    }
}
