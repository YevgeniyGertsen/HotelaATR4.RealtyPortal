using HotelaATR4.RealtyPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HotelaATR4.RealtyPortal.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _usermanager;
        private SignInManager<AppUser> _signInManager;
        private TokenService _tokenService;

        public AccountController(UserManager<AppUser> usermanager, 
            SignInManager<AppUser> signInManager,
            TokenService tokenService)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> AddUser()
        {
            AppUser user = new AppUser();
            user.UserName = "admin";
            user.Email = "gersen.e.a@gmail.com";
            var result = await _usermanager.CreateAsync(user, "Gg110188@");

            if (result.Succeeded)
            {

            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLogin)
        {
            var user = await _usermanager.FindByEmailAsync(userLogin.UserName);

            if (user != null)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(user, userLogin.Password, false, false);

                if(result.Succeeded)
                {
                    var jwtToken = await _tokenService.GenerateAccessToken(user);
                    Response.Cookies.Append("jwtToken", jwtToken);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(userLogin);
        }
    }
}
