using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class TodoController : Controller
    {
        public static List<Todo> Todos { get; set; } = new List<Todo>();

        public IActionResult Index()
        {
            return View(Todos);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Todo model)
        {
            if (ModelState.IsValid == false)
                return View();

            Todos.Add(model);
            return RedirectToAction("Index", "Todo");
        }
    }
}