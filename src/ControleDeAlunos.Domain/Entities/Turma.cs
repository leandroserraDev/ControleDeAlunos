using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Domain.Entities
{
   public class Turma
    {
        public Turma(string descricao)
        {
            Descricao = descricao;
        }
        protected Turma()
        {

        }

        public int TurmaId { get; private set; }
        public string Descricao { get; private set; }
        public virtual IEnumerable<Aluno> Alunos{ get;  set; }


    }
}
