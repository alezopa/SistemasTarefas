using Microsoft.EntityFrameworkCore;
using SistemasTarefas.Data;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Repositorio
{
    public class TimeTrackersRepositorio : ITimeTrackersRepositorio
    {

        private readonly SistemaTarefaDBContext _dbContext;
        public TimeTrackersRepositorio(SistemaTarefaDBContext sistemaTarefaDBContext)
        {
            _dbContext = sistemaTarefaDBContext;
        }
        public async Task<TimeTrackersModel> AdicionarTimes(TimeTrackersModel time)
        {

            if (validaAdicionaTime(time))
            { 
                 await _dbContext.TimeTrackers.AddAsync(time);
                 await _dbContext.SaveChangesAsync();
            }
            else
            {
                time = null;
            }

            return time;
        }

        public async Task<TimeTrackersModel> AtualizarTimes(TimeTrackersModel time, int id)
        {

            TimeTrackersModel timeId = await BuscarTimesPorId(id);

            if (timeId == null)
            {
                throw new Exception("Time não encontrado");
            }

            timeId.Name = time.Name;
            timeId.StartDate = time.StartDate;
            timeId.EndDate = time.EndDate;
            timeId.TimeZoneId = time.TimeZoneId;
            timeId.UpdateAt = DateTime.Now;

            _dbContext.TimeTrackers.Update(timeId);
            await _dbContext.SaveChangesAsync();


            return timeId;
        }

        public async Task<List<TimeTrackersModel>> BuscarTimes()
        {
            return await _dbContext.TimeTrackers.ToListAsync();
        }

        public async Task<TimeTrackersModel> BuscarTimesPorId(int id)
        {
            return await _dbContext.TimeTrackers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeletarTimes(int id)
        {
            TimeTrackersModel timeId = await BuscarTimesPorId(id);

            if (timeId == null)
            {
                throw new Exception("time não encontrado");
            }


            _dbContext.TimeTrackers.Remove(timeId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public bool validaAdicionaTime(TimeTrackersModel time)
        {
         bool valida = false;


            List<TimeTrackersModel> times =  BuscarTimes().Result;

           
            if(times.Select(t => time.StartDate >=  t.StartDate  && time.StartDate  <= t.EndDate  && t.CollaboratorId == time.CollaboratorId ).Count() > 0)
            {
                valida = false;
            }
            else if (times.Select(t => time.EndDate >= t.StartDate && time.EndDate <= t.EndDate && t.CollaboratorId == time.CollaboratorId).Count() > 0)
            {
                valida = false;
            }

        //var teste = times.Select(t => t.EndDate <= time.StartDate || t.StartDate >= time.EndDate).ToList();


        //var teste = times.Select(t => t.StartDate <= time.StartDate  || t.EndDate >= time.EndDate).ToList();

        //10 ao 12 dia   



            return valida;
        }
    }
}
