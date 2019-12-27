using ControleDeAlunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Turma GetById(int? id);
        IEnumerable<Turma> GetAll();
    }
}
