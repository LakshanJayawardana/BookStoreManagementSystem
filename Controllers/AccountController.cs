using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

public class AccountController : Controller
{
    private UserManager<AppUserEntity> _userManager;
    private SignInManager<AppUserEntity> _signInManager;
    private ApplicationDbContext _context;

    public AccountController(UserManager<AppUserEntity> userManager, SignInManager<AppUserEntity> signInManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }
    public IActionResult Login()
    {
        var response = new LoginViewModel();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View(loginViewModel);

        var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

        if (user != null)
        {
            //User is found, check password
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (passwordCheck)
            {
                //Password correct, sign in
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("AllBookList", "Book");
                }
            }
            //Password is incorrect
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }
        //User not found
        TempData["Error"] = "Wrong credentials. Please try again";
        return View(loginViewModel);
    }

    public IActionResult Register()
    {
        var response = new RegisterViewModel();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid) return View(registerViewModel);
        if (string.IsNullOrWhiteSpace(registerViewModel.EmailAddress))
        {
            TempData["Error"] = "Please provide an email address";
            return View("Home");
        }
        var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
        if (user != null)
        {
            TempData["Error"] = "This email address is already in use";
            return View(registerViewModel);
        }

        var newUser = new AppUserEntity()
        {
            Email = registerViewModel.EmailAddress,
            UserName = registerViewModel.Password
        };
        var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

        if (newUserResponse.Succeeded)
            await _userManager.AddToRoleAsync(newUser, UserRoles.User);

        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Race");
    }

}

