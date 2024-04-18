using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers;

public class HomeController : Controller
{

    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var featuredArticles = _context.Articles.ToList();
        var sidebarArticles = _context.Articles.ToList();
        var topbarArticles = _context.Articles.ToList();
        var main = _context.Articles.ToList();
        var categories = _context.Categories.ToList();
        var featuredCategories = _context.Categories.ToList();

        HomeVM homeVM = new()
        {
            FeaturedArticles = featuredArticles,
            SidebarArticles = sidebarArticles,
            TopbarArticles = topbarArticles,
            Articles = main,
            Categories  = categories,
            FeaturedCategoris = featuredCategories
        };
        return View(homeVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
