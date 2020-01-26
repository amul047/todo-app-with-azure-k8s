using UpdatesApi.Entities;

namespace UpdatesApi.Repositories.Interfaces
{
    public interface IToDoItemUpdateRepository
    {
        void Create(ToDoItemUpdate toDoItemUpdate);

        void Update(ToDoItemUpdate toDoItemUpdate);
    }
}
