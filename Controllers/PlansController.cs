using Microsoft.AspNetCore.Mvc;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class PlansController : Controller
{
    private readonly IApiService _apiService;

    public PlansController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Plans
    // Displays pricing page with plan tabs (Dial-Up and Broadband)
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Plans & Pricing - NEXUS";
        var plans = await _apiService.GetPlansAsync();
        return View(plans);
    }

    // GET: /Plans/Details/{id}
    // Displays detailed information about a specific plan
    public async Task<IActionResult> Details(string id)
    {
        ViewData["Title"] = "Plan Details - NEXUS";
        var plans = await _apiService.GetPlansAsync();
        var plan = plans.FirstOrDefault(p => p.Id == id);

        if (plan == null)
            return NotFound();

        return View(plan);
    }
}
