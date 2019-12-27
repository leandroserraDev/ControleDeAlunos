using ControleDeAlunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlunos.Infra.Data.Maps
{
   public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Aluno");
            HasKey(x => x.AlunoId);

            Property(x => x.Nome)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.Matricula)
                .IsRequired();

            Property(x => x.TurmaId)
                .IsOptional();

            HasOptional(x => x.Turma).WithMany();

         
        }
    }
}
