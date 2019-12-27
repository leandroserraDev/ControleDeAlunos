using AutoMapper;
using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeAlunos.UI.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<AlunoCreateViewModel, Aluno>().ReverseMap();
                x.CreateMap<AlunoEditViewModel, Aluno>().ReverseMap();
                x.CreateMap<AlunoCadTurmaViewModel, Aluno>().ReverseMap();
               

             
            });
        }
    }
}