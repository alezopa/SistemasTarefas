using SistemasTarefas.Models;

namespace SistemasTarefas.Repositorio.Interface
{
    public interface IProjectsRepositorio
    {

        Task<List<ProjectsModel>> BuscarProjetos();
        Task<ProjectsModel> BuscarProjetosPorId(int id);
        Task<ProjectsModel> AdicionarProjetos(ProjectsModel projeto);
        Task<ProjectsModel> AtualizarProjetos(ProjectsModel projeto, int id);
        Task<bool> DeletarProjetos(int id);
    }
}
