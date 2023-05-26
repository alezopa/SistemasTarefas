using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsRepositorio _projetoRepositorio;
        public ProjectsController(IProjectsRepositorio projectsRepositorio)
        {
            _projetoRepositorio = projectsRepositorio;
        }

        [HttpGet]
        public  async  Task<ActionResult<ProjectsModel>> BuscarProjetos()
        {
            List<ProjectsModel> projetos = await _projetoRepositorio.BuscarProjetos();

            return Ok(projetos);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProjectsModel>> BuscarProjetosPorId(int id)
        {
            ProjectsModel projeto = await _projetoRepositorio.BuscarProjetosPorId( id );

            return Ok(projeto);
        }



        [HttpPost]
        public  async  Task< ActionResult<ProjectsModel>>   Cadastrar([FromBody] ProjectsModel projetoModel)
        {
            ProjectsModel projeto = await _projetoRepositorio.AdicionarProjetos(projetoModel);
            return Ok(projeto);
        }


        [HttpPut("id")]
        public async Task<ActionResult<ProjectsModel>> Atualizar([FromBody] ProjectsModel projetoModel, int id)
        {
            projetoModel.Id = id;   
            ProjectsModel projeto = await _projetoRepositorio.AtualizarProjetos(projetoModel, id);
            return Ok(projeto);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<ProjectsModel>> Deletar(int id)
        {

            var retorno =  await _projetoRepositorio.DeletarProjetos( id);
            return Ok(retorno);
        }



    }
}
