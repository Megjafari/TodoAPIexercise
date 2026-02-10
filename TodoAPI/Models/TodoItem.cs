namespace TodoAPIexercise.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
        public int Order { get; set; }
    }
}
