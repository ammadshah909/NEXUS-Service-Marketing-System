using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class OrdersController : Controller
{
    private readonly IApiService _apiService;

    public OrdersController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Orders/New
    // Displays multi-step form for creating a new connection order
    public IActionResult New()
    {
        ViewData["Title"] = "New Connection - NEXUS";
        return View(new OrderViewModel());
    }

    // POST: /Orders/New
    // Handles order form submission with frontend validation
    [HttpPost]
    public async Task<IActionResult> New(OrderViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var order = new OrderInfo
        {
            CustomerName = model.FullName,
            ConnectionType = model.ServiceType,
            Plan = model.PlanName,
            Status = "Pending"
        };

        var result = await _apiService.SubmitOrderAsync(order);

        if (result)
        {
            TempData["SuccessMessage"] = "Order submitted successfully! Order ID: " + order.Id;
            return RedirectToAction("Tracking", new { id = order.Id });
        }

        ModelState.AddModelError("", "Failed to submit order.");
        return View(model);
    }

    // GET: /Orders/Tracking
    // Displays order tracking timeline status
    public async Task<IActionResult> Tracking(string id)
    {
        ViewData["Title"] = "Order Tracking - NEXUS";
        var order = await _apiService.GetOrderAsync(id ?? "NX12345678");
        return View(order);
    }
}
