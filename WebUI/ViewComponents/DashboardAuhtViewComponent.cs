using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents;

public class DashboardAuhtViewComponent : ViewComponent
{

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContext;

    public DashboardAuhtViewComponent(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContext = httpContext;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var loggedUserId =  _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await _userManager.FindByIdAsync(loggedUserId);
        return View(user);
    }
}
