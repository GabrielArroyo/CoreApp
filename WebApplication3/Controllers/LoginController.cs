using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Services;
using Infraestructure.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _LoginService;

        public LoginController(LoginService LoginService)
        {
            _LoginService = LoginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(RegisterUsers user)
        {

            var getUser = _LoginService.Get(user);           


            if (getUser != null)
            {
                return RedirectToAction("Index" , "Home");
            }
            else
            {

                ModelState.AddModelError(string.Empty, "Este usuario no esta registrado");

                return View("Index");
            }
            
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterBBDD(RegisterUsers user)
        {


            _LoginService.Create(user);


            return RedirectToAction("Index", "Login");
        }

    }
}