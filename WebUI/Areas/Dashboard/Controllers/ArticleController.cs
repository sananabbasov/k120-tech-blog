using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebUI.Data;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Areas.Dashboard.Controllers;

[Area("Dashboard")]
[Authorize]
public class ArticleController : Controller
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContext;

    public ArticleController(AppDbContext context, IHttpContextAccessor httpContext)
    {
        _context = context;
        _httpContext = httpContext;
    }

    public IActionResult Index()
    {
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        ViewBag.UserId = userId;
        var articles = _context.Articles.Include(x => x.Category).Where(x => x.UserId == userId).ToList();
        return View(articles);
    }

    public IActionResult Create()
    {
        var categories = _context.Categories.ToList();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View();
    }


    [HttpPost]
    public IActionResult Create(Article article)
    {
        try
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            article.UserId = userId;
            article.CreatedDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;
            article.SeoUrl = SeoHelper.CreateSeoUrl(article.Title);
            _context.Articles.Add(article);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var articles = _context.Articles.SingleOrDefault(m => m.Id == id);
        var categories = _context.Categories.ToList();
        ViewBag.Categories = categories;
        
        if (articles == null)
        {
            return NotFound();
        }

        return View(articles);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(Article article)
    {
        try
        {
            article.SeoUrl = SeoHelper.CreateSeoUrl(article.Title);
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            article.UserId = userId;
            _context.Articles.Update(article);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            return View(article);
        }
    }

}
