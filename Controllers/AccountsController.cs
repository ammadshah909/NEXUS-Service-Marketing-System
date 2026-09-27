using Microsoft.AspNetCore.Mvc;

namespace NEXUS.Controllers;

public class AccountsController : Controller
{
    // GET: /Accounts/Dashboard
    // Displays accounts/billing dashboard with revenue and payment tracking
    public IActionResult Dashboard()
    {
        ViewData["Title"] = "Accounts Dashboard - NEXUS";
        ViewData["PageTitle"] = "Accounts Dashboard";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "Generate Bill",
            "Bill Management",
            "Payment History",
            "Customer Dues",
            "Reports"
        };

        return View();
    }
}
