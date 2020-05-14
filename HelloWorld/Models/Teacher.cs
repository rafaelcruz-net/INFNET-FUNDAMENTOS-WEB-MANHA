using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Teacher
    {
        public String Login { get; set; }
        public String Photo { get; set; } = $"https://robohash.org/${Guid.NewGuid()}.png?size=60x60&bgset=bg1";
        public String Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public String Profissao { get; set; }
        public String Email { get; set; }
        public String InstituicaoEnsino { get; set; }
        public String Biografia { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();  
    }

}
