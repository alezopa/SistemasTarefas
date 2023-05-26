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
            //builder.Property(p => p.CreatedAt).IsRequired(false).HasColumnType("date");
            //builder.Property(p => p.UpdateAt).IsRequired(false).HasColumnType("date");
            //builder.Property(p => p.DeleteAt).IsRequired(false).HasColumnType("date");


            //builder.Property<DateTime>("CreateAt").HasColumnName(@"StartTime").HasColumnType(@"time").IsRequired().HasConversion(v => v.TimeOfDay, v => DateTime.Now.Date.Add(v));
            //builder.Property<DateTime>("UpdateAt").HasColumnName(@"StartTime").HasColumnType(@"time").IsRequired().HasConversion(v => v.TimeOfDay, v => DateTime.Now.Date.Add(v));
            //builder.Property<DateTime>("DeleteAt").HasColumnName(@"StartTime").HasColumnType(@"time").IsRequired().HasConversion(v => v.TimeOfDay, v => DateTime.Now.Date.Add(v));
        }
    }
}
