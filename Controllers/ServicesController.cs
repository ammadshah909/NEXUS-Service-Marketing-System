using Microsoft.AspNetCore.Mvc;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class ServicesController : Controller
{
    private readonly IApiService _apiService;

    public ServicesController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Services
    // Displays all available services (Dial-Up and Broadband)
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Services - NEXUS";
        var services = await _apiService.GetServicesAsync();
        return View(services);
    }
}
