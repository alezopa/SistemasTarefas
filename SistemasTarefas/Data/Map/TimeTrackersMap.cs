using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasTarefas.Models;

namespace SistemasTarefas.Data.Map
{
    public class TimeTrackersMap : IEntityTypeConfiguration<TimeTrackersModel>
    {
        public void Configure(EntityTypeBuilder<TimeTrackersModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.TimeZoneId).IsRequired().HasMaxLength(200);
            builder.Property(x => x.TaskId).IsRequired();
            builder.Property(x => x.CollaboratorId).IsRequired();

        }
    }
}
