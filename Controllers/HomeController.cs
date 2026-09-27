using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApiService _apiService;

    public HomeController(ILogger<HomeController> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    // GET: /
    // Displays the landing/home page with hero section and feature overview
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Home - NEXUS";
        return View();
    }

    // GET: /Home/Error
    // Displays error page
    public IActionResult Error()
    {
        return View();
    }
}
