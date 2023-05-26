﻿namespace SistemasTarefas.Models
{
    public class ProjectsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
