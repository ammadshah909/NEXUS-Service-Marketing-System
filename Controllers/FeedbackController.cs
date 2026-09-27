using Microsoft.AspNetCore.Mvc;
using NEXUS.Models.ViewModels;
using NEXUS.Services.Api;

namespace NEXUS.Controllers;

public class FeedbackController : Controller
{
    private readonly IApiService _apiService;

    public FeedbackController(IApiService apiService)
    {
        _apiService = apiService;
    }

    // GET: /Feedback
    // Displays feedback form with star rating
    public IActionResult Index()
    {
        ViewData["Title"] = "Feedback - NEXUS Customer";
        ViewData["PageTitle"] = "Feedback";
        ViewData["SidebarItems"] = new List<string>
        {
            "Dashboard",
            "My Connection",
            "Bills & Payments",
            "Profile",
            "Feedback",
            "Logout"
        };

        return View(new FeedbackViewModel());
    }

    // POST: /Feedback
    // Handles feedback submission
    [HttpPost]
    public async Task<IActionResult> Index(FeedbackViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var feedback = new FeedbackInfo
        {
            CustomerId = "NX12345678",
            Rating = model.Rating,
            Comments = model.Comments
        };

        var result = await _apiService.SubmitFeedbackAsync(feedback);

        if (result)
        {
            TempData["SuccessMessage"] = "Thank you for your feedback! We appreciate your input.";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Failed to submit feedback.");
        return View(model);
    }
}
