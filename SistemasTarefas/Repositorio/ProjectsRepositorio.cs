using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemasTarefas.Data;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Repositorio
{

    public class ProjectsRepositorio : IProjectsRepositorio
    {
        private readonly SistemaTarefaDBContext _dbContext;
        public ProjectsRepositorio(SistemaTarefaDBContext sistemaTarefaDBContext)
        {
            _dbContext = sistemaTarefaDBContext;       
        }
        public async Task<ProjectsModel> AdicionarProjetos(ProjectsModel projeto)
        {
               projeto.CreatedAt = DateTime.Now;
             await _dbContext.Projects.AddAsync(projeto);
            await _dbContext.SaveChangesAsync();

            return projeto;
        }

        public async Task<ProjectsModel> AtualizarProjetos(ProjectsModel projeto, int id)
        {
           ProjectsModel   projetoId = await  BuscarProjetosPorId(id);

            if(projetoId == null)
            {
                throw new Exception("Projeto não encontrado");
            }

            projetoId.Name = projeto.Name;
            projetoId.UpdateAt = DateTime.Now;

            _dbContext.Projects.Update(projetoId);
            await _dbContext.SaveChangesAsync();


            return projetoId;   


        }

        public async Task<List<ProjectsModel>> BuscarProjetos()
        {
      

            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<ProjectsModel> BuscarProjetosPorId(int id)
        {
            return await  _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeletarProjetos(int id)
        {
            ProjectsModel projetoId = await BuscarProjetosPorId(id);

            if (projetoId == null)
            {
                throw new Exception("Projeto não encontrado");
            }


            _dbContext.Projects.Remove(projetoId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
