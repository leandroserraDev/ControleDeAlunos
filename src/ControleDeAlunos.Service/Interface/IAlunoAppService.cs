using ControleDeAlunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Service.Interface
{
    public interface IAlunoAppService 
    {
        Aluno GetByMatricula(int matricula);
        void AddAluno(Aluno obj);
        void Edit(int id, Aluno obj);
        void CadastrarNaTurma(int id, Aluno obj);
        void ExcluirDaTurma(int id);

        void Delete(Aluno obj);
        IEnumerable<Aluno> GetAll();
        Aluno GetById(int id);
    }
}
