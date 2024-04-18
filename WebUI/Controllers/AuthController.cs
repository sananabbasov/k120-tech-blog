using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Data;
using WebUI.Dtos.UserDto;
using WebUI.Models;

namespace WebUI.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var findUser = await _userManager.FindByEmailAsync(loginDto.Email);
        if (findUser == null)
        {
            return View();
        }
        var result = await _signInManager.PasswordSignInAsync(findUser, loginDto.Password, true,true);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto register)
    {
        var findUser = await _userManager.FindByEmailAsync(register.Email);
        if (findUser != null)
        {
            return View();
        }
        User user = new()
        {
            Email = register.Email,
            UserName = register.Email,
            FirstName = register.FirstName,
            LastName = register.LastName,
            About = ""
        };

        var result = await _userManager.CreateAsync(user, register.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Login");
        }

        return View();

    }

    public IActionResult ResetPassword()
    {
        return View();
    }

    public IActionResult ForgotPassword()
    {
        return View();
    }


}
