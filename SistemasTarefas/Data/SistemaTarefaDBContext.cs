using Microsoft.EntityFrameworkCore;
using SistemasTarefas.Data.Map;
using SistemasTarefas.Models;

namespace SistemasTarefas.Data
{
    public class SistemaTarefaDBContext : DbContext
    {

        public SistemaTarefaDBContext(DbContextOptions<SistemaTarefaDBContext> options) : base(options)
        {
        }


        public DbSet<UsersModel> Users { get; set; }
        public DbSet<CollaboratorsModel> Collaborators { get; set; }
        public DbSet<ProjectsModel> Projects { get; set; }
        public DbSet<TasksModel> Tasks { get; set; }
        public DbSet<TimeTrackersModel> TimeTrackers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectsMap());
            modelBuilder.ApplyConfiguration(new TasksMap());
            modelBuilder.ApplyConfiguration(new TimeTrackersMap());
            base.OnModelCreating(modelBuilder);
        }

    }

}

