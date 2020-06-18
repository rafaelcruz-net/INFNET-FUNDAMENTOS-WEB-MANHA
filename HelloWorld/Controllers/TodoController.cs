using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class TodoController : Controller
    {
        private TodoRepository TodoRepository { get; set; }

        public TodoController(TodoRepository todoRepository)
        {
            this.TodoRepository = todoRepository;
        }

        public IActionResult Index(string? message)
        {
            var result = this.TodoRepository.GetAll();
            ViewBag.Message = message;
            return View(result);
        }

        public IActionResult New()
        {
            return View();
        }
        
        public IActionResult Edit([FromQuery] Guid id)
        {
            var todo = TodoRepository.GetById(id);

            return View(todo);
        }

        public IActionResult Delete([FromQuery] Guid id)
        {
            var todo = TodoRepository.GetById(id);
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
            TodoRepository.Save(model);

            return RedirectToAction("Index", "Todo", new { message = "Tarefa cadastrada com sucesso" });
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Todo model)
        {
            if (ModelState.IsValid == false)
                return View();

            var todoEdit = TodoRepository.GetById(id);

            todoEdit.Nome = model.Nome;
            todoEdit.Concluido = model.Concluido;

            TodoRepository.Update(todoEdit);

            return RedirectToAction("Index", "Todo", new { message = "Tarefa editada com sucesso" });
        }

        [HttpPost]
        public IActionResult DeleteTask(Guid id)
        {
            if (ModelState.IsValid == false)
                return View();

            TodoRepository.Delete(id);

            return RedirectToAction("Index", "Todo", new { message = "Tarefa excluída com sucesso" });
        }


    }
}