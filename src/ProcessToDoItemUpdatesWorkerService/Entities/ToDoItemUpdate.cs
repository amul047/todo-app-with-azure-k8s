namespace ProcessToDoItemUpdatesWorkerService.Entities
{
    public class ToDoItemUpdate
    {
        public int Id { get; set; }

        public int? ToDoItemId { get; set; }

        public string Title { get; set; }

        public string State { get; set; }
    }
}
