using AutoMapper;
using ItemsApi.Repositories.Interfaces;
using ItemsApi.Services.Interfaces;
using ItemsApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ItemsApi.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IMapper _mapper;

        public ToDoItemService(IToDoItemRepository toDoItemRepository,
            IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
        }

        public IEnumerable<ToDoItemVm> GetAll()
        {
            return _toDoItemRepository.GetAll()
                .Where(item => !string.Equals(item.State, "Removed", System.StringComparison.OrdinalIgnoreCase))
                .Select(item => _mapper.Map<ToDoItemVm>(item));
        }
    }
}
