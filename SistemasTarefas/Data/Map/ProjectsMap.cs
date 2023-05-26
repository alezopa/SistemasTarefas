using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasTarefas.Models;

namespace SistemasTarefas.Data.Map
{
    public class ProjectsMap : IEntityTypeConfiguration<ProjectsModel>
    {
        public void Configure(EntityTypeBuilder<ProjectsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

        }
    }
}
