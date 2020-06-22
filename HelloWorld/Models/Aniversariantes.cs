using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Aniversariante
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome da tarefa deve ser preenchido")]
        public String primeiroNome { get; set; }
        public String segundoNome { get; set; }
        public DateTime dataAniversario { get; set; }

    }
}
