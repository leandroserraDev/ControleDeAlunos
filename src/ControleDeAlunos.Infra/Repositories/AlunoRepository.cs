using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _alunoRepository;

        public AlunoRepository(DataContext alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Add(Aluno obj)
        {

            _alunoRepository.Alunos.Add(obj);
            _alunoRepository.SaveChanges();
        }

        public void Delete(Aluno obj)
        {
            var aluno =_alunoRepository.Alunos.Find(obj.AlunoId);
            _alunoRepository.Alunos.Remove(aluno);
            _alunoRepository.SaveChanges();
        }

        public  void Edit(int id, Aluno obj)
        {
            var alunoBanco = _alunoRepository.Alunos.Where(x => x.AlunoId == id).FirstOrDefault();

            alunoBanco.AlterarNome(obj.Nome);
            
            _alunoRepository.SaveChanges();
        }
        public void CadastrarNaTurma(int id, Aluno obj)
        {
            var alunoBanco = _alunoRepository.Alunos.Where(x => x.AlunoId == id).FirstOrDefault();
            
            alunoBanco.CadTurma(obj.TurmaId);

            _alunoRepository.SaveChanges();
        }
        public void ExcluirDaTurma(int id)
        {
            var alunoBanco = _alunoRepository.Alunos.Where(x => x.AlunoId == id).FirstOrDefault();
            alunoBanco.ExcluirDaTurma();

            _alunoRepository.SaveChanges();
        }

        public IEnumerable<Aluno> GetAll()
        {
            var alunos = _alunoRepository.Alunos
                .Include(x => x.Turma)
                .ToList();
            
            return alunos;
        }

        public Aluno GetById(int id)
        {
            return _alunoRepository.Alunos
                .Where(x => x.AlunoId == id)
                .Include(x => x.Turma)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Aluno GetByMatricula(int matricula)
        {
            return _alunoRepository.Alunos
                .Where(x => x.Matricula == matricula)
                .Include(x => x.Turma)
                .AsNoTracking()
                .FirstOrDefault();
        }
    }
}
