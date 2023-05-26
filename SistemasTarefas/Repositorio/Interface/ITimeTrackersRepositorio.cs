using SistemasTarefas.Models;

namespace SistemasTarefas.Repositorio.Interface
{
    public interface ITimeTrackersRepositorio
    {

        Task<List<TimeTrackersModel>> BuscarTimes();
        Task<TimeTrackersModel> BuscarTimesPorId(int id);
        Task<TimeTrackersModel> AdicionarTimes(TimeTrackersModel time);
        Task<TimeTrackersModel> AtualizarTimes(TimeTrackersModel time, int id);
        Task<bool> DeletarTimes(int id);

    }
}
