using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using InventoryMS.Models;
using System.Threading.Tasks;


namespace InventoryMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        // (Dependency Injection) عشان نقدر نستخدم أدوات Identity
        public AccountController(
            SignInManager<IdentityUser> signInManager,
             UserManager<IdentityUser> userManager,
              RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //-------------------Login----------------------

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("PrintAll", "Product");
                }
                ModelState.AddModelError(string.Empty, "The Email or Password is incorrect");
            }
            return View(model);
        }

        //-------------------Logout----------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //-------------------Register----------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("PrintAll", "Product");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //-------------------Roles----------------------

        // public async Task<string> CreateRoles()
        // {
        //     // فحص إذا دور الـ Admin مش موجود، بيعمله إنشاء
        //     if (!await _roleManager.RoleExistsAsync("Admin"))
        //     {
        //         await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //     }

        //     // فحص إذا دور الـ User مش موجود، بيعمله إنشاء
        //     if (!await _roleManager.RoleExistsAsync("User"))
        //     {
        //         await _roleManager.CreateAsync(new IdentityRole("User"));
        //     }

        //     return "Roles Created Successfully!";
        // }
    }
}
