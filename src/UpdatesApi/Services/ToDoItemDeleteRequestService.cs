using UpdatesApi.Repositories.Interfaces;
using UpdatesApi.Services.Interfaces;

namespace UpdatesApi.Services
{
    public class ToDoItemDeleteRequestService : IToDoItemDeleteRequestService
    {
        private readonly IToDoItemUpdateRepository _toDoItemUpdateRepository;

        public ToDoItemDeleteRequestService(IToDoItemUpdateRepository toDoItemUpdateRepository)
        {
            _toDoItemUpdateRepository = toDoItemUpdateRepository;
        }

        public void Execute(int toDoItemId)
        {
            _toDoItemUpdateRepository.Update(new Entities.ToDoItemUpdate
            {
                ItemId = toDoItemId,
                State = "Removed"
            });
        }
    }
}
