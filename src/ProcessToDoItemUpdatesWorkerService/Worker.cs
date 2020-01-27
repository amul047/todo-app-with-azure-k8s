using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces;

namespace ProcessToDoItemUpdatesWorkerService
{
    public class Worker : BackgroundService
    {
        private static int _lastProcessedToDoItemUpdateId = 0;
        private readonly ILogger<Worker> _logger;
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IToDoItemUpdateRepository _toDoItemUpdateRepository;

        public Worker(ILogger<Worker> logger, 
            IToDoItemRepository toDoItemRepository,
            IToDoItemUpdateRepository toDoItemUpdateRepository)
        {
            _logger = logger;
            _toDoItemRepository = toDoItemRepository;
            _toDoItemUpdateRepository = toDoItemUpdateRepository;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    foreach (var update in _toDoItemUpdateRepository.GetToProcess(_lastProcessedToDoItemUpdateId).OrderBy(toDoItemUpdate => toDoItemUpdate.Id))
                    {
                        if (update.ToDoItemId.HasValue)
                        {
                            _toDoItemRepository.Update(update.ToDoItemId.Value, new Entities.ToDoItem
                            {
                                State = update.State,
                                Title = update.Title
                            });
                        }
                        else
                        {
                            _toDoItemRepository.Create(new Entities.ToDoItem
                            {
                                State = update.State,
                                Title = update.Title
                            });
                        }
                        _lastProcessedToDoItemUpdateId = update.Id;
                    }
                        
                }catch(Exception exception)
                {
                    _logger.LogError(exception, "Worker encountered an exception");
                }
                finally
                {
                    _toDoItemUpdateRepository.MarkAsProcessed(_lastProcessedToDoItemUpdateId);
                }
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}
