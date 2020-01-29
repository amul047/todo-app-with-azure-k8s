using AutoMapper;
using ItemsApi.ViewModels;

namespace ItemsApi.Entities
{
    public class ToDoItem
    {
        /// <summary>
        /// ID of the to do item this relates to. Set to null to create a new item.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// State of the to do item- can be "To do", "Doing", "Done"
        /// </summary>
        public string State { get; set; }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<ToDoItem, ToDoItemVm>();
            }
        }
    }
}
