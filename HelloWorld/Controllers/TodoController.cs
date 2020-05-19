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
        public IActionResult Index()
        {
            List<Todo> todos = new List<Todo>();

            todos.Add(new Todo()
            {
                Nome = "Ver Email Trabalho",
                Concluido = true
            });

            todos.Add(new Todo()
            {
                Nome = "Marcar dentista",
                Concluido = false
            });

            todos.Add(new Todo()
            {
                Nome = "Fazer trabalho TP 3",
                Concluido = false
            });

            todos.Add(new Todo()
            {
                Nome = "Limpar a louça",
                Concluido = true
            });


            return View(todos);
        }

        public IActionResult New()
        {
            return View();
        }
    }
}