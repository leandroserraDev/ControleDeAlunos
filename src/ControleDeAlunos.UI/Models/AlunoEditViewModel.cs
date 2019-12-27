using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeAlunos.UI.Models
{
          public class AlunoEditViewModel
          {
            public AlunoEditViewModel()
            {
                Matricula = new Random().Next(0, 1000);
            }

            public string Nome { get; set; }

            private int Matricula { get; set; }
            private int? TurmaId { get; set; }

            public int? ReturnTurmaId()
            {
                return TurmaId;
            }
            public int ReturnMatricula()
            {
                return Matricula;
            }

        }
    
}