namespace ItemsApi.ViewModels
{
    public class ToDoItemVm
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <example>7</example>
        public string Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        /// <example>Check the motorcycle chain</example>
        public string Title { get; set; }

        /// <summary>
        /// State
        /// </summary>
        /// <example>To do</example>
        public string State { get; set; }
    }
}
