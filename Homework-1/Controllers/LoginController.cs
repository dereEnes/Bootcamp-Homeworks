using HomeworkOne.Models.Entities;
using HomeworkOne.Models.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkOne.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IResult Register(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return new Result
                {
                    Data = "giriş işlemi başarısız",
                    Error = true,
                    Success = false
                };
            }
            else
            {
                return new Result
                {
                    Data = "giriş işlemi başarılı",
                    Error = null,
                    Success = true
                };
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
