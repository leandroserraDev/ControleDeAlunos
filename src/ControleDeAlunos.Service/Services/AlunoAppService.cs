using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.Domain.Interfaces.Services;
using ControleDeAlunos.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Service.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

       
        public void AddAluno(Aluno obj)
        {
            _alunoService.Add(obj);
        }

        public void CadastrarNaTurma(int id, Aluno obj)
        {
            _alunoService.CadastrarNaTurma(id, obj);
        }

        public void Delete(Aluno obj)
        {
            _alunoService.Delete(obj);
        }

        public void Edit(int id, Aluno obj)
        {
            _alunoService.Edit(id, obj);
        }

        public void ExcluirDaTurma(int id)
        {
            _alunoService.ExcluirDaTurma(id);
        }

        public IEnumerable<Aluno> GetAll()
        {
           return _alunoService.GetAll();
        }

        public Aluno GetById(int id)
        {
            return _alunoService.GetById(id);
        }

        public Aluno GetByMatricula(int matricula)
        {
            return _alunoService.GetByMatricula(matricula);
        }
    }
}
