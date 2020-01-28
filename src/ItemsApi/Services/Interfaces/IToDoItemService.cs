using ItemsApi.ViewModels;
using System.Collections.Generic;

namespace ItemsApi.Services.Interfaces
{
    public interface IToDoItemService
    {
        IEnumerable<ToDoItemVm> GetAll();
    }
}
