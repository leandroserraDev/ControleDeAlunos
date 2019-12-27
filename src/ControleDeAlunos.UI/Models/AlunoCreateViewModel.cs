using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeAlunos.UI.Models
{
    public class AlunoCreateViewModel
    {
        public AlunoCreateViewModel()
        {
            Matricula = new Random().Next(0, 1000);
        }

        public string Nome { get;  set; }

        private int Matricula { get;  set; }
        public int? TurmaId { get;  set; }

       
        public int ReturnMatricula()
        {
            return Matricula;
        }

    }
}