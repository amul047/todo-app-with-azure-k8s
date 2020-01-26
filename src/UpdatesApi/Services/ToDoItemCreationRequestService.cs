using AutoMapper;
using UpdatesApi.Entities;
using UpdatesApi.Repositories.Interfaces;
using UpdatesApi.Services.Interfaces;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Services
{
    public class ToDoItemCreationRequestService : IToDoItemCreationRequestService
    {
        private readonly IToDoItemUpdateRepository _toDoUpdateRepository;
        private readonly IMapper _mapper;

        public ToDoItemCreationRequestService(IToDoItemUpdateRepository toDoUpdateRepository,
            IMapper mapper)
        {
            _toDoUpdateRepository = toDoUpdateRepository;
            _mapper = mapper;
        }

        public void Execute(ToDoItemVm toDoItemVm)
        {
            _toDoUpdateRepository.Create(_mapper.Map<ToDoItemUpdate>(toDoItemVm));
        }
    }
}
