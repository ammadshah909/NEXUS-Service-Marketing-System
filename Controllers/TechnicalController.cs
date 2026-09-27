using Microsoft.AspNetCore.Mvc;

namespace NEXUS.Controllers;

public class TechnicalController : Controller
{
    // GET: /Technical/Dashboard
    // Displays technical staff dashboard with pending orders and assignments
    public IActionResult Dashboard()
    {
        ViewData["Title"] = "Technical Dashboard - NEXUS";
        ViewData["PageTitle"] = "Technical Dashboard";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "Pending Orders",
            "Feedback",
            "Complaints",
            "Connection Status",
            "Equipment",
            "Reports"
        };

        return View();
    }
}
