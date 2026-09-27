using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class BillsController : Controller
{
    private readonly IApiService _apiService;

    public BillsController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Bills
    // Displays bills and payment history tabs
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Bills & Payments - NEXUS Customer";
        ViewData["PageTitle"] = "Bills & Payments";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        var bills = await _apiService.GetBillsAsync();
        return View(bills);
    }

    // GET: /Bills/Details/{id}
    // Displays detailed bill breakdown and payment options
    public async Task<IActionResult> Details(string id)
    {
        ViewData["Title"] = "Bill Details - NEXUS Customer";
        ViewData["PageTitle"] = "Bill Details";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        var bill = await _apiService.GetBillAsync(id ?? "B-2025-09");
        var billViewModel = new BillViewModel
        {
            BillNumber = bill.BillNumber,
            BillingPeriod = bill.BillingPeriod,
            DueDate = bill.DueDate,
            Status = bill.Status,
            MonthlyRental = 2000m,
            SecurityDeposit = 500m,
            PreviousDues = 0m,
            Adjustments = -50m,
            TotalAmount = bill.Amount
        };

        return View(billViewModel);
    }
}
