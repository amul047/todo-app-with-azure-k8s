using ItemsApi.Entities;
using System.Linq;

namespace ItemsApi.Repositories.Interfaces
{
    public interface IToDoItemRepository
    {
        IQueryable<ToDoItem> GetAll();
    }
}
