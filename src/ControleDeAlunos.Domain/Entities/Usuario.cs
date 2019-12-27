using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Entities
{
    public class Usuario
    {
        protected Usuario ()

        { }


        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string NomeLogin { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
  
    }
}
