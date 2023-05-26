using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITasksRepositorio _tasksRepositorio;
        public TasksController(ITasksRepositorio tasksRepositorio)
        {
            _tasksRepositorio = tasksRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<TasksModel>> BuscarProjetos()
        {
            List<TasksModel> tasks = await _tasksRepositorio.BuscarTasks();

            return Ok(tasks);
        }

        [HttpGet("id")]
        public async Task<ActionResult<TasksModel>> BuscarProjetosPorId(int id)
        {
            TasksModel task = await _tasksRepositorio.BuscarTasksPorId(id);

            return Ok(task);
        }



        [HttpPost]
        public async Task<ActionResult<TasksModel>> Cadastrar([FromBody] TasksModel projetoModel)
        {
            TasksModel task = await _tasksRepositorio.AdicionarTasks(projetoModel);
            return Ok(task);
        }


        [HttpPut("id")]
        public async Task<ActionResult<TasksModel>> Atualizar([FromBody] TasksModel projetoModel, int id)
        {
            projetoModel.Id = id;
            TasksModel task = await _tasksRepositorio.AtualizarTasks(projetoModel, id);
            return Ok(task);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<TasksModel>> Deletar(int id)
        {

            var retorno = await _tasksRepositorio.DeletarTasks(id);
            return Ok(retorno);
        }







    }



}
