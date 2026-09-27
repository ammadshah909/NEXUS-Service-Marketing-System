using Microsoft.AspNetCore.Mvc;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class CustomerController : Controller
{
    private readonly IApiService _apiService;

    public CustomerController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Customer/Dashboard
    // Displays customer dashboard with recent activity and connection summary
    public async Task<IActionResult> Dashboard()
    {
        ViewData["Title"] = "Dashboard - NEXUS Customer";
        ViewData["PageTitle"] = "Dashboard";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        var customer = await _apiService.GetCustomerAsync("NX12345678");
        return View(customer);
    }

    // GET: /Customer/MyConnection
    // Displays current connection details and equipment info
    public async Task<IActionResult> MyConnection()
    {
        ViewData["Title"] = "My Connection - NEXUS Customer";
        ViewData["PageTitle"] = "My Connection";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        var customer = await _apiService.GetCustomerAsync("NX12345678");
        return View(customer);
    }
}
