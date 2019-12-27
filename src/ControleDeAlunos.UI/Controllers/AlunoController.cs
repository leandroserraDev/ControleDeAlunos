using AutoMapper;
using ControleDeAlunos.Domain.Entities;
using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Infra.Repositories;
using ControleDeAlunos.Service.Interface;
using ControleDeAlunos.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ControleDeAlunos.UI.Controllers
{
  [Authorize]
    public class AlunoController : ApiController
    {
        private readonly IAlunoAppService _alunoService;
        private readonly ITurmaRepository _turmaRepository;

        public AlunoController(IAlunoAppService alunoRepository,
                               ITurmaRepository turmaRepository)
        
        {                   


            _alunoService = alunoRepository;
            _turmaRepository = turmaRepository;

        }

        // GET: api/Aluno
        /// <summary>
        /// Retorna todos os Alunos cadastrados
        /// </summary>
        /// <returns></returns>
        [Route("api/aluno")]
        [HttpGet]
        public  IEnumerable<Aluno> GetAll()
        {
        var alunos = _alunoService.GetAll();

            if (alunos.Count() == 0)
                BadRequest("Nenhum aluno cadastrado");

            return alunos;
        }

      
      

        // GET: api/Aluno/5
        /// <summary>
        /// Retorna um aluno por sua Identificação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/aluno/{id}")]
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
           
         var alunoId = _alunoService.GetById(id);


            if (alunoId == null)
                return BadRequest("Aluno não encontrado!");

            return Ok(alunoId);

        }

        // POST: api/Aluno
        /// <summary>
        /// Cadastra um Aluno 
        /// </summary>
        /// <param name="obj"></param>
       
        /// <returns></returns>
        [Route("api/aluno/Cadastrar")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]AlunoCreateViewModel obj)
        {
            var alunoBanco =  _alunoService.GetByMatricula(obj.ReturnMatricula());
            var turma = _turmaRepository.GetById(obj.TurmaId);


            if (alunoBanco != null)
                return BadRequest("Um aluno já possui essa matrícula, por favor tente outra matrícula!");

            if (_alunoService.GetAll().Where(x => x.TurmaId != null && x.TurmaId == obj.TurmaId).Count() >= 5)
                return BadRequest("A turma atingiu a capacidade máxima de 5 alunos");

            if (obj.TurmaId != 1 && obj.TurmaId != 2 && obj.TurmaId != 3 && obj.TurmaId != null)
                return BadRequest("Digite um id válido ou null");

                var alunoSalvar = Mapper.Map<AlunoCreateViewModel, Aluno>(obj);

            _alunoService.AddAluno(alunoSalvar);

            return Ok(_alunoService.GetByMatricula(alunoSalvar.Matricula));
       
        }

        // PUT: api/Aluno/5
        /// <summary>
        /// Editar um aluno 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("api/aluno/Editar/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoEditViewModel obj)
        {
            var alunoEdit = _alunoService.GetById(id);

            if(alunoEdit == null)
                return BadRequest("Aluno não encontrado");

            
            _alunoService.Edit(id, Mapper.Map<AlunoEditViewModel, Aluno>(obj));
                
            return StatusCode(HttpStatusCode.NoContent);

        }

        // DELETE: api/Aluno/5
        /// <summary>
        /// Exclui um aluno po sua identificação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/aluno/Excluir/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            //VARIÁVEIS
            var aluno = _alunoService.GetById(id);

            //Verificações
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            if (aluno.TurmaId != null)
                return BadRequest("Impossível excluir um aluno cadastrado em uma turma, por favor primeiro exclua o aluno da turma!");

            //OK
            _alunoService.Delete(aluno);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Cadastrar Aluno na Turma: api/Aluno/CadastrarNaTurma/5
        /// <summary>
        /// Cadastra um aluno na turma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>

        [Route("api/aluno/CadastrarNaTurma/{id}")]
        [HttpPatch]
        public IHttpActionResult CadastrarNaTurma(int id, [FromBody]AlunoCadTurmaViewModel obj)
        {
            //Variáveis
            var aluno = _alunoService.GetById(id);
            var turma = _turmaRepository.GetById(obj.TurmaId);

            //Verificações
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            if (obj.TurmaId != 1 && obj.TurmaId != 2 && obj.TurmaId != 3 || turma == null)
                return BadRequest("Turma não encontrada. Escolha 1 para turma do inglês básico - 2 para intermediário - 3 para avançado");

            if (aluno.TurmaId == obj.TurmaId || aluno.TurmaId != null)
                return BadRequest("O aluno já está cadastrado em uma turma!");

            if (_alunoService.GetAll().Where(x => x.TurmaId != null && x.TurmaId == obj.TurmaId).Count() >= 5)
                return BadRequest("A turma atingiu a capacidade máxima de 5 alunos");


            //OK
            var alunoEdit = Mapper.Map<AlunoCadTurmaViewModel, Aluno>(obj);
            _alunoService.CadastrarNaTurma(id, alunoEdit);

            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete Aluno da Turma: api/Aluno/ExcuirDaTurma/5
        /// <summary>
        /// Exclui um aluno da turma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/aluno/ExcluirDaTurma/{id}")]
        [HttpPatch]
        public IHttpActionResult DeletarTurma(int id)
        {
            //Variáveis
            var alunoId = _alunoService.GetById(id);

            //Verificações
            if (alunoId == null)
                return BadRequest("Aluno não encontrado!");

            if (alunoId.TurmaId == null)
                return BadRequest("Aluno não está matriculado em nenhuma turma!");

            //OK
            _alunoService.ExcluirDaTurma(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

       
        
    }
}
