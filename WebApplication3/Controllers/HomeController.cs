using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Services;
using Infraestructure.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    
    //[Authorize]
    public class HomeController : Controller
    {

        private readonly UsersService _userService;        
     
        public HomeController(UsersService usersService)
        {            
            _userService = usersService;           
        }        
        public IActionResult Index()
        {
            ViewData["Usuarios"] = _userService.Get();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Insert(Users user)
        {
            if (user.Name != null)
                _userService.Create(user);

            ModelState.Clear();
            return View();
        }
        public IActionResult Edit(Users user)
        { 
            if (user.Id != null)
                _userService.Update(user.Id, user);

            ViewData["Usuarios"] = _userService.Get();

            ModelState.Clear();
            return View();
        }              
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
