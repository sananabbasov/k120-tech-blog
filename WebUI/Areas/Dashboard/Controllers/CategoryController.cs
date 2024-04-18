using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Areas.Dashboard.Controllers;

[Authorize]
[Area("Dashboard")]
public class CategoryController : Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }



    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch (System.Exception e)
        {
            return View();
        }

    }



    public IActionResult Update(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);
        return View(category);
    }


    [HttpPost]
    public IActionResult Update(Category category)
    {
        try
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            return View();
        }
    }

    public IActionResult Delete(int Id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == Id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Delete(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
