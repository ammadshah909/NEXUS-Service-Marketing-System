using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;

namespace NEXUS.Controllers;

public class ProfileController : Controller
{
    // GET: /Profile
    // Displays customer profile information and documents
    public IActionResult Index()
    {
        ViewData["Title"] = "Profile - NEXUS Customer";
        ViewData["PageTitle"] = "Profile";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        var profile = new ProfileViewModel
        {
            FullName = "Ahmed Khan",
            Email = "ahmed.khan@example.com",
            Phone = "+92 300 1234567",
            Cnic = "42101-1234567-1",
            Address = "House 18, Gulshan-e-Iqbal, Karachi"
        };

        return View(profile);
    }
}
