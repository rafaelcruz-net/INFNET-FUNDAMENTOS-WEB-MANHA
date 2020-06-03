using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Conhecendo/{nome}/{ultimoNome}")]
        public IActionResult Interacao(string nome, string ultimoNome)
        {
            if (!String.IsNullOrWhiteSpace(nome) && !String.IsNullOrWhiteSpace(ultimoNome))
            {
                ViewBag.NomeCompleto = $"{nome} {ultimoNome}";
                return View("Xpto");
            }

            return View();
        }

        [Route("AboutMe")]
        public IActionResult AboutMe()
        {
            Teacher teacher = new Teacher()
            {
                Nome = "Rafael Cruz",
                DtNascimento = new DateTime(1981, 03, 13),
                Biografia = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                Email = "rafael.cruz@prof.infnet.edu.br",
                InstituicaoEnsino = "Infnet",
                Profissao = "Professor",
                Login = "rafael.cruz"
            };

            teacher.Turmas.Add(new Turma()
            {
                Nome = "Projeto de Bloco",
                Horario = "07:00-9:30",
                Materia = "Projeto de Bloco .NET",
                Codigo = "20GRPEDC01BNT504"
            });

            teacher.Turmas.Add(new Turma()
            {
                Nome = "Fundamentos da Web - ASP.NET",
                Horario = "07:00-9:30",
                Materia = "Fundamentos do Desenvolvimento de Aplicações Web ASP.NET",
                Codigo = "20GRPEDC01BNT204"

            });

            return View(teacher);
        }
        [Route("AboutMe1")]
        public IActionResult AboutMe1()
        {
            Teacher AlunoAbout = new Teacher()
            {
                Nome = "Natan Borges",
                DtNascimento = new DateTime(2000, 12, 21),
                Biografia = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                Email = "natan.borges.al@infnet.edu.br",
                InstituicaoEnsino = "Infnet",
                Profissao = "estudante",
                Login = "natan.borges"
            };

            AlunoAbout.Turmas.Add(new Turma()
            {
                Nome = "Projeto de Bloco",
                Horario = "07:00-9:30",
                Materia = "Projeto de Bloco .NET",
                Professor = "Rafael Cruz"
            });
            AlunoAbout.Turmas.Add(new Turma()
            {
                Nome = "Fundamentos C#",
                Horario = "07:00-9:30",
                Materia = "Fundamentos C#",
                Professor = "Vitor Fitzner"
            });

            AlunoAbout.Turmas.Add(new Turma()
            {
                Nome = "Fundamentos da Web - ASP.NET",
                Horario = "07:00-9:30",
                Materia = "Fundamentos do Desenvolvimento de Aplicações Web ASP.NET",
                Professor = "Rafael Cruz"

            });

            return View(AlunoAbout);
        }

        [Route("{loginProfessor}/{codigoMateria}/Students")]
        public IActionResult Students(String loginProfessor, String codigoMateria)
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                students.Add(new Student()
                {
                    CodigoTurma = codigoMateria,
                    LoginProfessor = loginProfessor,
                    Email = $"fulano{i}_{codigoMateria}@teste.com.br",
                    Nome = $"fulano{i}_{codigoMateria}",
                });
            }

            return View(students);
       
        }

    }
}