using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _usuarioRepository;

        public UsuarioRepository(DataContext usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Autenticar(string login, string senha)
        {
            var usuario = _usuarioRepository.Usuario.Where(x => x.NomeLogin.ToUpper() == login.ToUpper() && x.Password.ToUpper() == senha.ToUpper()).FirstOrDefault();

            if (usuario == null)
                return false;

            return true;



        }

        public IEnumerable<Usuario> getall()
        {
            return _usuarioRepository.Usuario.ToList();
        }
    }
}
