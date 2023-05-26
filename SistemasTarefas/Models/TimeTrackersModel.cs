namespace SistemasTarefas.Models
{
    public class TimeTrackersModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TimeZoneId { get; set; }
        public int TaskId { get; set; }
        public int CollaboratorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
