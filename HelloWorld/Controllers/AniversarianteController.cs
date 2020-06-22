using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class AniversarianteController : Controller
    {
        private TodoRepository TodoRepository { get; set; }

        public AniversarianteController(TodoRepository todoRepository)
        {
            this.TodoRepository = todoRepository;
        }

        public IActionResult Index(string? message, string? searchName)
        {
            ViewBag.Message = message;

            if (!String.IsNullOrEmpty(searchName))
            {
                var Encontrados = TodoRepository.Pesquisar(searchName);
                return View(Encontrados);
            }
            //https://stackoverflow.com/questions/37845354/creating-a-search-bar-c-sharp-mvc// 
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
            var Aniversariante = TodoRepository.GetById(id);

            return View(Aniversariante);
        }

        public IActionResult Delete([FromQuery] Guid id)
        {
            var aniversariante = TodoRepository.GetById(id);
            return View(aniversariante);
        }


        [HttpPost]
        public IActionResult Save(Aniversariante model)
        {
            if (ModelState.IsValid == false)
                return View();

            //Criando identificador unico
            model.Id = Guid.NewGuid();

            //Adicionando na "Tabela"
            TodoRepository.Save(model);

            return RedirectToAction("Index", "Aniversariante", new { message = "Aniversariante cadastrado com sucesso" });
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Aniversariante model)
        {
            if (ModelState.IsValid == false)
                return View();

            var todoEdit = TodoRepository.GetById(id);

            todoEdit.primeiroNome = model.primeiroNome;
            todoEdit.segundoNome = model.segundoNome;
            Convert.ToString(todoEdit.dataAniversario = model.dataAniversario);

            TodoRepository.Update(todoEdit);

            return RedirectToAction("Index", "Aniversariante", new { message = "Aniversariante editado com sucesso" });
        }

        [HttpPost]
        public IActionResult DeleteTask(Guid id)
        {
            if (ModelState.IsValid == false)
                return View();

            TodoRepository.Delete(id);

            return RedirectToAction("Index", "Aniversariante", new { message = "Aniversariante excluído com sucesso" });
        }


    }
}