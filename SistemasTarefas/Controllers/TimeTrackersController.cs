using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackersController : ControllerBase
    {

        private readonly ITimeTrackersRepositorio  _timeRepositorio;
        public TimeTrackersController(ITimeTrackersRepositorio timeRepositorio)
        {
            _timeRepositorio = timeRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<TimeTrackersModel>> BuscarTimes()
        {
            List<TimeTrackersModel> projetos = await _timeRepositorio.BuscarTimes();

            return Ok(projetos);
        }

        [HttpGet("id")]
        public async Task<ActionResult<TimeTrackersModel>> BuscarTimesPorId(int id)
        {
            TimeTrackersModel projeto = await _timeRepositorio.BuscarTimesPorId(id);

            return Ok(projeto);
        }



        [HttpPost]

        public async Task<ActionResult<TimeTrackersModel>> Cadastrar([FromBody] TimeTrackersModel projetoModel)
        {

            TimeZone localZone = TimeZone.CurrentTimeZone;

            projetoModel.TimeZoneId = localZone.StandardName;
          



            TimeTrackersModel projeto = await _timeRepositorio.AdicionarTimes(projetoModel);
            return Ok(projeto);
        }


        [HttpPut("id")]
        public async Task<ActionResult<TimeTrackersModel>> Atualizar([FromBody] TimeTrackersModel projetoModel, int id)
        {
            projetoModel.Id = id;
            TimeTrackersModel projeto = await _timeRepositorio.AtualizarTimes(projetoModel, id);
            return Ok(projeto);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<TimeTrackersModel>> Deletar(int id)
        {

            var retorno = await _timeRepositorio.DeletarTimes(id);
            return Ok(retorno);
        }





    }
}
