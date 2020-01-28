using Microsoft.AspNetCore.Mvc;
using ItemsApi.Services.Interfaces;
using ItemsApi.ViewModels;
using System.Collections.Generic;

namespace ItemsApi.Controllers
{
    /// <summary>
    /// Api to get to do items
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemsController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        /// <summary>
        /// Get all todo items (that have not been removed)
        /// </summary>
        /// <returns>List of to do items</returns>
        [HttpGet]
        public IEnumerable<ToDoItemVm> GetAllToDoItems()
        {
            return _toDoItemService.GetAll();
        }
    }
}
