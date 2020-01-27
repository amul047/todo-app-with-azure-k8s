using Microsoft.AspNetCore.Mvc;
using UpdatesApi.Services.Interfaces;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Controllers
{
    /// <summary>
    /// Api to request creation or updates to to do items
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemUpdatesController : ControllerBase
    {
        private readonly IToDoItemCreationRequestService _toDoItemCreationRequestService;
        private readonly IToDoItemUpdateRequestService _toDoItemUpdateRequestService;
        private readonly IToDoItemDeleteRequestService _toDoItemDeleteRequestService;

        public ToDoItemUpdatesController(IToDoItemCreationRequestService toDoItemCreationRequestService, 
            IToDoItemUpdateRequestService toDoItemUpdateRequestService,
            IToDoItemDeleteRequestService toDoItemDeleteRequestService)
        {
            _toDoItemCreationRequestService = toDoItemCreationRequestService;
            _toDoItemUpdateRequestService = toDoItemUpdateRequestService;
            _toDoItemDeleteRequestService = toDoItemDeleteRequestService;
        }

        /// <summary>
        /// Request creation of a to do item
        /// </summary>
        /// <param name="toDoItemVm">To do item</param>
        [HttpPost]
        public void RequestCreationOfToDoItem(ToDoItemVm toDoItemVm)
        {
            _toDoItemCreationRequestService.Execute(toDoItemVm);
        }

        /// <summary>
        /// Request update to an to do item
        /// </summary>
        /// <param name="toDoItemId">To do item id</param>
        /// <param name="toDoItemVm">To do item</param>
        [HttpPut("{toDoItemId}")]
        public void RequestUpdateOfToDoItem([FromRoute] int toDoItemId, ToDoItemVm toDoItemVm)
        {
            _toDoItemUpdateRequestService.Execute(toDoItemId, toDoItemVm);
        }
        
        /// <summary>
        /// Request update to remove an to do item
        /// </summary>
        /// <param name="toDoItemId">To do item id</param>
        [HttpDelete("{toDoItemId}")]
        public void RequestRemovalOfToDoItem([FromRoute] int toDoItemId)
        {
            _toDoItemDeleteRequestService.Execute(toDoItemId);
        }
    }
}
