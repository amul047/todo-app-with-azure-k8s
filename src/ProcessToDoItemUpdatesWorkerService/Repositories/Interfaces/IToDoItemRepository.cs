using ProcessToDoItemUpdatesWorkerService.Entities;

namespace ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces
{
    public interface IToDoItemRepository
    {
        public void Create(ToDoItem toDoItem);

        public void Update(int id, ToDoItem toDoItem);
    }
}
