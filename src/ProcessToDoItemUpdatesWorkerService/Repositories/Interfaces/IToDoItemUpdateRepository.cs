using ProcessToDoItemUpdatesWorkerService.Entities;
using System.Collections.Generic;

namespace ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces
{
    public interface IToDoItemUpdateRepository
    {
        IEnumerable<ToDoItemUpdate> GetToProcess(int lastProcessedToDoItemUpdateId);

        void MarkAsProcessed(int lastProcessedToDoItemUpdateId);
    }
}
