using AutoMapper;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Entities
{
    public class ToDoItemUpdate
    {
        /// <summary>
        /// ID of the to do item this relates to. Set to null to create a new item.
        /// </summary>
        public int? ItemId { get; set; }

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
                CreateMap<ToDoItemVm, ToDoItemUpdate>()
                    .ForMember(update => update.ItemId, options => options.Ignore());
            }
        }
    }
}
