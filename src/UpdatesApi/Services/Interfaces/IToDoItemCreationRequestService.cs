using UpdatesApi.ViewModels;

namespace UpdatesApi.Services.Interfaces
{
    public interface IToDoItemCreationRequestService
    {
        void Execute(ToDoItemVm toDoItemVm);
    }
}
