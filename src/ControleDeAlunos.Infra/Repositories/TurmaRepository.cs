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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly DataContext _turmaRepository;

        public TurmaRepository(DataContext turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public IEnumerable<Turma> GetAll()
        {
            return _turmaRepository.Turmas.ToList();           
                
        }

        public Turma GetById(int? id)
        {
            var turma = _turmaRepository.Turmas
                .Where(x => x.TurmaId == id)
                .FirstOrDefault();

            return turma;
                
            
        }
    }
}
