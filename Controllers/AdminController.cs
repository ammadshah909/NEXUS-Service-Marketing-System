using Microsoft.AspNetCore.Mvc;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class AdminController : Controller
{
    private readonly IApiService _apiService;

    public AdminController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Admin/Dashboard
    // Displays admin dashboard with statistics and charts
    public async Task<IActionResult> Dashboard()
    {
        ViewData["Title"] = "Admin Dashboard - NEXUS";
        ViewData["PageTitle"] = "Admin Dashboard";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "Customers",
            "Employees",
            "Retail Sales",
            "Vendors",
            "Plans",
            "Products / Stock",
            "Orders",
            "Connections",
            "Billing",
            "Reports",
            "Settings"
        };

        return View();
    }

    // GET: /Admin/Reports
    // Displays reports search and generation page
    public IActionResult Reports()
    {
        ViewData["Title"] = "Reports - NEXUS Admin";
        ViewData["PageTitle"] = "Reports";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "Customers",
            "Employees",
            "Retail Sales",
            "Vendors",
            "Plans",
            "Products / Stock",
            "Orders",
            "Connections",
            "Billing",
            "Reports",
            "Settings"
        };

        return View();
    }

    // GET: /Admin/Settings
    // Displays system settings page
    public IActionResult Settings()
    {
        ViewData["Title"] = "Settings - NEXUS Admin";
        ViewData["PageTitle"] = "Settings";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "Customers",
            "Employees",
            "Retail Sales",
            "Vendors",
            "Plans",
            "Products / Stock",
            "Orders",
            "Connections",
            "Billing",
            "Reports",
            "Settings"
        };

        return View();
    }
}
