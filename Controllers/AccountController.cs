using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class AccountController : Controller
{
    private readonly IApiService _apiService;

    public AccountController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Account/Login
    // Displays customer login screen
    public IActionResult Login()
    {
        ViewData["Title"] = "Login - NEXUS";
        return View(new LoginViewModel());
    }

    // POST: /Account/Login
    // Handles login (frontend only, shows mock success)
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid Account ID and Password combination.");
            return View(model);
        }

        // Mock login - redirect to customer dashboard
        TempData["SuccessMessage"] = "Logged in successfully!";
        return RedirectToAction("Dashboard", "Customer");
    }

    // GET: /Account/Status
    // Displays account status search page with tabs
    public IActionResult Status()
    {
        ViewData["Title"] = "Account Status - NEXUS";
        return View();
    }
}
