using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasTarefas.Models;

namespace SistemasTarefas.Data.Map
{
    public class TasksMap : IEntityTypeConfiguration<TasksModel>
    {
        public void Configure(EntityTypeBuilder<TasksModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.ProjectId).IsRequired();


        }
    }
}
