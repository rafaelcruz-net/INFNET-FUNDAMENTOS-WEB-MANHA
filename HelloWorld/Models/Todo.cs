using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Todo
    {
        [Required(ErrorMessage = "Campo nome da tarefa deve ser preenchido")]
        public String Nome { get; set; }
        public bool Concluido { get; set; }
    }
}
