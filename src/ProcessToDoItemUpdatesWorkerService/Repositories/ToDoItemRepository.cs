using Dapper;
using Microsoft.Extensions.Options;
using ProcessToDoItemUpdatesWorkerService.Entities;
using ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces;
using System;
using System.Data.SqlClient;

namespace ProcessToDoItemUpdatesWorkerService.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly DatabaseConnectionStrings _databaseConnectionStrings;

        public ToDoItemRepository(IOptions<DatabaseConnectionStrings> databaseConnectionStringOptions)
        {
            _databaseConnectionStrings = databaseConnectionStringOptions?.Value ?? throw new ArgumentNullException(nameof(databaseConnectionStringOptions));
        }

        public void Create(ToDoItem toDoItem)
        {
            using (var sqlConnection = new SqlConnection(_databaseConnectionStrings.ToDoItemProjections))
            {
                sqlConnection.Execute("CreateToDoItem", toDoItem, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Update(int id, ToDoItem toDoItem)
        {
            using (var sqlConnection = new SqlConnection(_databaseConnectionStrings.ToDoItemProjections))
            {
                sqlConnection.Execute("UpdateToDoItem", new
                {
                    Id = id,
                    toDoItem.Title,
                    toDoItem.State
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
