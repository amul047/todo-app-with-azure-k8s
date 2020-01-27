using AutoMapper;
using UpdatesApi.Entities;
using UpdatesApi.Repositories.Interfaces;
using UpdatesApi.Services.Interfaces;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Services
{
    public class ToDoItemUpdateRequestService : IToDoItemUpdateRequestService
    {
        private readonly IToDoItemUpdateRepository _toDoItemUpdateRepository;
        private readonly IMapper _mapper;

        public ToDoItemUpdateRequestService(IToDoItemUpdateRepository toDoItemUpdateRepository,
            IMapper mapper)
        {
            _toDoItemUpdateRepository = toDoItemUpdateRepository;
            _mapper = mapper;
        }

        public void Execute(int toDoItemId, ToDoItemVm toDoItemVm)
        {
            var toDoItemUpdate = _mapper.Map<ToDoItemUpdate>(toDoItemVm);
            toDoItemUpdate.ItemId = toDoItemId;
            _toDoItemUpdateRepository.Update(toDoItemUpdate);
        }
    }
}
