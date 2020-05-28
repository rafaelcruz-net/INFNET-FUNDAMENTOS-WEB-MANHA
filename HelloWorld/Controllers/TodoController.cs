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

        public IActionResult Index(string? message)
        {
            ViewBag.Message = message;
            return View(Todos);
        }

        public IActionResult New()
        {
            return View();
        }


        public IActionResult Edit([FromQuery] Guid id)
        {
            var todo = Todos.Where(x => x.Id == id).FirstOrDefault();

            return View(todo);
        }

        [HttpPost]
        public IActionResult Save(Todo model)
        {
            if (ModelState.IsValid == false)
                return View();

            //Criando identificador unico
            model.Id = Guid.NewGuid();

            //Adicionando na "Tabela"
            Todos.Add(model);

            return RedirectToAction("Index", "Todo", new { message = "Tarefa cadastrada com sucesso" });
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Todo model)
        {
            if (ModelState.IsValid == false)
                return View();

            var todoEdit = Todos.Where(x => x.Id == id).FirstOrDefault();

            todoEdit.Nome = model.Nome;
            todoEdit.Concluido = model.Concluido;

            Todos.Remove(todoEdit);
            Todos.Add(todoEdit);

            return RedirectToAction("Index", "Todo", new { message = "Tarefa editada com sucesso" });
        }


    }
}