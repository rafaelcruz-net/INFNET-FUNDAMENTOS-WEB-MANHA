using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Interacao(string nome, string ultimoNome)
        {
            if (!String.IsNullOrWhiteSpace(nome) && !String.IsNullOrWhiteSpace(ultimoNome))
            {
                ViewBag.NomeCompleto = $"{nome} {ultimoNome}";
                return View("Xpto");
            }

            return View();
        }

        public IActionResult AboutMe()
        {
            Teacher teacher = new Teacher()
            {
                Nome = "Rafael Cruz",
                DtNascimento = new DateTime(1981, 03, 13),
                Biografia = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                Email = "rafael.cruz@prof.infnet.edu.br",
                InstituicaoEnsino = "Infnet",
                Profissao = "Professor"
            };

            teacher.Turmas.Add(new Turma()
            {
                Nome = "Projeto de Bloco",
                Horario = "07:00-9:30",
                Materia = "Projeto de Bloco .NET"
            });

            teacher.Turmas.Add(new Turma()
            {
                Nome = "Fundamentos da Web - ASP.NET",
                Horario = "07:00-9:30",
                Materia = "Fundamentos do Desenvolvimento de Aplicações Web ASP.NET"
            });


            return View(teacher);
        }

    }
}