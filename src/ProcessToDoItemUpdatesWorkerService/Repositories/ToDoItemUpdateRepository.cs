using Dapper;
using Microsoft.Extensions.Options;
using ProcessToDoItemUpdatesWorkerService.Entities;
using ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProcessToDoItemUpdatesWorkerService.Repositories
{
    public class ToDoItemUpdateRepository : IToDoItemUpdateRepository
    {
        private readonly DatabaseConnectionStrings _databaseConnectionStrings;

        public ToDoItemUpdateRepository(IOptions<DatabaseConnectionStrings> databaseConnectionStringOptions)
        {
            _databaseConnectionStrings = databaseConnectionStringOptions?.Value ?? throw new ArgumentNullException(nameof(databaseConnectionStringOptions));
        }

        public IEnumerable<ToDoItemUpdate> GetToProcess(int lastProcessedToDoItemUpdateId)
        {
            using(var sqlConnection = new SqlConnection(_databaseConnectionStrings.ToDoItemEvents))
            {
                return sqlConnection.Query<ToDoItemUpdate>("GetToDoItemUpdatesToProcess", new { lastProcessedToDoItemUpdateId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void MarkAsProcessed(int lastProcessedToDoItemUpdateId)
        {
            using (var sqlConnection = new SqlConnection(_databaseConnectionStrings.ToDoItemEvents))
            {
                sqlConnection.Execute("MarkToDoItemUpdatesAsProcessed", new { lastProcessedToDoItemUpdateId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
