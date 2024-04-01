using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    List<Article> articles = new(){
        new Article{
            Id = 1,
            Title = "Bu gun daha 5 nefer imtahandan kesildi"
        },
         new Article{
            Id = 2,
            Title = "Yeni ders ili basladi."
        },
         new Article{
            Id = 3,
            Title = "Dersler bitir"
        },
         new Article{
            Id = 4,
            Title = "Test yazilari yazdiq"
        },
         new Article{
            Id = 5,
            Title = "Bu gun daha 15 nefer imtahandan kesildi"
        },
        
    };


    public IActionResult Index()
    {
        ViewBag.Message = "Salam K120";
        ViewData["Description"] = "MVC dersleri basladi.";
        ViewBag.ProductList = articles;
        ViewData["ProductDatas"] = articles;
       
        return View(articles);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
