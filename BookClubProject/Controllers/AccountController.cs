using BookClubProject.Data;
using BookClubProject.Models;
using BookClubProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookClubProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext  _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var responce = new LoginVM();
            return View(responce);
        }



        public IActionResult Register()
        {
            var responce = new RegisterVM();
            return View(responce);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {

                TempData["Error"] = "this email is already in use";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                UserName = registerVM.EmailAddress,
                Email = registerVM.EmailAddress,
                EmailConfirmed = true,


            };
            var newUserResponce = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponce.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("Login");
        }




        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "BookClub");

                        }
                        TempData["Error"] = "wrong credentials entered";
                        return View(loginVM);
                    }

                }
            }
            TempData["Error"] = "wrong credentials entered";
            return View(loginVM);

        }
    }
}
