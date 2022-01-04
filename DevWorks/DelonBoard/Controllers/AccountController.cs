using DelonBoard.Entity;
using DelonBoard.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DelonBoard.Controllers
{
    public class AccountController : Controller
    {
        //Inject the usermanager and signinmanager
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
    
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
           
        }
        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   //Sign in the user to check if it succeeds
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    //If it succeeds find the user by email using the email provided
                    if (result.Succeeded)
                    {
                        ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                        // Get the roles of the logged in user
                        var roles = await userManager.GetRolesAsync(user);

                        // Check if the role of the logged in user is in superadmin role returns a boolean
                        //If true redirect to dashboard
                        var userRoles = await userManager.IsInRoleAsync(user, "SuperAdmin");
                        if (userRoles)
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            return RedirectToAction("Index2", "Dashboard");
                        }
                    }
                }
                return View(model);
            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

     


        [HttpGet]
        public async Task<ActionResult> LogOff()
        {
            // Log out the current user from the application and delete the default cookies and identity
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
               
               foreach (var cookieKey in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookieKey);
                }
                return RedirectToAction("Login", "Account");
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }
    }
}
