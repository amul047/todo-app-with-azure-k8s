using AutoMapper;
using UpdatesApi.Entities;
using UpdatesApi.Repositories.Interfaces;
using UpdatesApi.Services.Interfaces;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Services
{
    public class ToDoItemUpdateRequestService : IToDoItemUpdateRequestService
    {
        private readonly IToDoItemUpdateRepository _toDoUpdateRepository;
        private readonly IMapper _mapper;

        public ToDoItemUpdateRequestService(IToDoItemUpdateRepository toDoUpdateRepository,
            IMapper mapper)
        {
            _toDoUpdateRepository = toDoUpdateRepository;
            _mapper = mapper;
        }

        public void Execute(int toDoItemId, ToDoItemVm toDoItemVm)
        {
            var toDoItemUpdate = _mapper.Map<ToDoItemUpdate>(toDoItemVm);
            toDoItemUpdate.ItemId = toDoItemId;
            _toDoUpdateRepository.Update(toDoItemUpdate);
        }
    }
}
