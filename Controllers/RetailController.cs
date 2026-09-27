using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;

namespace NEXUS.Controllers;

public class RetailController : Controller
{
    // GET: /Retail/Dashboard
    // Displays retail employee dashboard with quick actions
    public IActionResult Dashboard()
    {
        ViewData["Title"] = "Retail Dashboard - NEXUS";
        ViewData["PageTitle"] = "Retail Dashboard";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "New Customer Order",
            "Customer Search",
            "Order Status",
            "Payment Entry",
            "Customer Details"
        };

        return View();
    }

    // GET: /Retail/NewOrder
    // Displays form for creating new customer order
    public IActionResult NewOrder()
    {
        ViewData["Title"] = "New Customer Order - NEXUS";
        ViewData["PageTitle"] = "New Customer Order";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "New Customer Order",
            "Customer Search",
            "Order Status",
            "Payment Entry",
            "Customer Details"
        };

        return View(new OrderViewModel());
    }

    // POST: /Retail/NewOrder
    // Handles new customer order submission
    [HttpPost]
    public IActionResult NewOrder(OrderViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["SuccessMessage"] = "Order created successfully! Customer ID: NX12345678";
        return RedirectToAction("Dashboard");
    }

    // GET: /Retail/Search
    // Displays customer and order search page
    public IActionResult Search()
    {
        ViewData["Title"] = "Customer Search - NEXUS";
        ViewData["PageTitle"] = "Customer Search";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "New Customer Order",
            "Customer Search",
            "Order Status",
            "Payment Entry",
            "Customer Details"
        };

        return View();
    }
}
