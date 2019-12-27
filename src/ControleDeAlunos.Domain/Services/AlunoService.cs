using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoService;

        public AlunoService(IAlunoRepository alunoService)
        {
            _alunoService = alunoService;
        }
        public Aluno GetByMatricula(int matricula)
        {
            return _alunoService.GetByMatricula(matricula);
        }

    
        public void Add(Aluno obj)
        {
            _alunoService.Add(obj);
        }

        public void Edit(int id, Aluno obj)
        {
            _alunoService.Edit(id, obj);
        }

        public void CadastrarNaTurma(int id, Aluno obj)
        {
            _alunoService.CadastrarNaTurma(id, obj);
        }

        public void ExcluirDaTurma(int id)
        {
            _alunoService.ExcluirDaTurma(id);
        }

        public void Delete(Aluno obj)
        {
            _alunoService.Delete(obj);
        }

        public IEnumerable<Aluno> GetAll()
        {
           return _alunoService.GetAll();
        }

        public Aluno GetById(int id)
        {
            return _alunoService.GetById(id);
        }
    }
}
