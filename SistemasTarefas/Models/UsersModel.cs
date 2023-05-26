namespace SistemasTarefas.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}
