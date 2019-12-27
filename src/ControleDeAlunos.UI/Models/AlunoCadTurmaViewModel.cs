using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeAlunos.UI.Models
{
    public class AlunoCadTurmaViewModel
    {
        public AlunoCadTurmaViewModel()
        {
            Matricula = new Random().Next(0, 1000);
        }

        private string Nome { get; set; }

        private int Matricula { get; set; }
        public int? TurmaId { get; set; }

        public string ReturnNome()
        {
            return Nome;
        }
        public int ReturnMatricula()
        {
            return Matricula;
        }
    }
}