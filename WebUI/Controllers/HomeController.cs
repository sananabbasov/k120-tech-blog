using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers;
class ScoreDto
{
    public int Key { get; set; }
    public int View { get; set; }
}

public class HomeController : Controller
{

    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        var popularArticles = _context.Articles.Include(x => x.User).Include(x => x.Category).OrderByDescending(a => a.ViewCount).Take(2).ToList().Select(x => { x.Description = StripHTML(x.Description); return x; }).ToList();
        var recentArticles = _context.Articles.OrderByDescending(x => x.Id).Include(y => y.Category).Take(4).ToList();
        var popularCategory = _context.Articles.Select(group => new ScoreDto
        {
            Key = group.CategoryId,
            View = _context.Articles.Where(x=>x.CategoryId == group.CategoryId).Sum(x=>x.ViewCount),
        }).OrderByDescending(x=>x.View).GroupBy(x=>x).Select(x=>x.Key).OrderByDescending(x=>x.View).ToList();
        var popularArticleCategoryOne = _context.Articles.Where(x => x.CategoryId == popularCategory[0].Key).Include(a => a.Category).Take(3).ToList();
        var popularArticleCategoryTwo = _context.Articles.Where(x => x.CategoryId == popularCategory[1].Key).Include(a => a.Category).Take(3).ToList();

        HomeVM homeVM = new()
        {
            PopularArticles = popularArticles,
            RecentArticles = recentArticles,
            PopularArticleOne = popularArticleCategoryOne,
            PopularArticleTwo = popularArticleCategoryTwo
        };
        return View(homeVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }


    private string StripHTML(string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }

}
