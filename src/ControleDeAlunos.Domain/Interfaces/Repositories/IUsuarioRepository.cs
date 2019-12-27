using ControleDeAlunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Interfaces.Repositories
{
   public interface IUsuarioRepository
    {
        bool Autenticar(string login, string senha);
        IEnumerable<Usuario> getall();
    }
}
