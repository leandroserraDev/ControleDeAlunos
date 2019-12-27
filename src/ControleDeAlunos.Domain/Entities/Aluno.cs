using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Entities
{
   public class Aluno
    {
        public Aluno(string nome, int? turmaId)
        {
            Nome = nome;
            Matricula = new Random().Next(0, 1000);
            TurmaId = turmaId;

        }
        protected Aluno()
        {

        }

        public int AlunoId { get;  private set; }
        public string Nome { get; private set; }
        public int Matricula { get; private set; }

        public int? TurmaId { get; private set; }
        public Turma Turma { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void CadTurma(int? turmaId)
        {
            if (turmaId == null)
                TurmaId = turmaId;
            else
            TurmaId = turmaId;
        }

        public void ExcluirDaTurma()
        {
            TurmaId = null;
        }

    }
}
