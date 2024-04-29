using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebUI.Data;
using WebUI.ViewModels;

namespace WebUI.Controllers;

public class ArticleController : Controller
{
    private readonly AppDbContext _conext;

    public ArticleController(AppDbContext conext)
    {
        _conext = conext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {

        var artcile = _conext.Articles.Include(x=>x.Category).Include(x=>x.User).SingleOrDefault(x=>x.Id == id);
        artcile.ViewCount +=1;
        _conext.Articles.Update(artcile);
        _conext.SaveChanges();
        DetailVM vm = new()
        {
            Article = artcile
        };
        return View(vm);
    }

}
