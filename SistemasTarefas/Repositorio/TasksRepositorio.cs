using Microsoft.EntityFrameworkCore;
using SistemasTarefas.Data;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorio.Interface;

namespace SistemasTarefas.Repositorio
{
    public class TasksRepositorio : ITasksRepositorio
    {

        private readonly SistemaTarefaDBContext _dbContext;
        public TasksRepositorio(SistemaTarefaDBContext sistemaTarefaDBContext)
        {
            _dbContext = sistemaTarefaDBContext;
                
        }
        public async Task<TasksModel> AdicionarTasks(TasksModel task)
        {
            task.CreatedAt = DateTime.Now;  
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TasksModel> AtualizarTasks(TasksModel task, int id)
        {
            TasksModel taskId = await BuscarTasksPorId(id);

            if (taskId == null)
            {
                throw new Exception("task não encontrado");
            }

            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.UpdateAt = DateTime.Now;

            _dbContext.Tasks.Update(taskId);
            await _dbContext.SaveChangesAsync();


            return taskId;
        }

        public async Task<List<TasksModel>> BuscarTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TasksModel> BuscarTasksPorId(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeletarTasks(int id)
        {
            TasksModel taskId = await BuscarTasksPorId(id);

            if (taskId == null)
            {
                throw new Exception("task não encontrado");
            }


            _dbContext.Tasks.Remove(taskId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
