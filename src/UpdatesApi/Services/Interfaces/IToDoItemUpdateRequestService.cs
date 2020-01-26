using UpdatesApi.ViewModels;

namespace UpdatesApi.Services.Interfaces
{
    public interface IToDoItemUpdateRequestService
    {
        void Execute(int toDoItemId, ToDoItemVm toDoItemVm);
    }
}
