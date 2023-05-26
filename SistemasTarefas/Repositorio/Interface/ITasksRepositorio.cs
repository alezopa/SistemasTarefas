using SistemasTarefas.Models;

namespace SistemasTarefas.Repositorio.Interface
{
    public interface ITasksRepositorio
    {

        Task<List<TasksModel>> BuscarTasks();
        Task<TasksModel> BuscarTasksPorId(int id);
        Task<TasksModel> AdicionarTasks(TasksModel task);
        Task<TasksModel> AtualizarTasks(TasksModel task, int id);
        Task<bool> DeletarTasks(int id);
    }
}
