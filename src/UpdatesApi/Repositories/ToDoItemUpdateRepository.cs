using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;
using UpdatesApi.Entities;
using UpdatesApi.Repositories.Interfaces;

namespace UpdatesApi.Repositories
{
    public class ToDoItemUpdateRepository : IToDoItemUpdateRepository
    {
        private readonly DatabaseSettings _databaseSettings;

        public ToDoItemUpdateRepository(IOptions<DatabaseSettings> databaseSettingsOptions)
        {
            _databaseSettings = databaseSettingsOptions?.Value ?? throw new ArgumentNullException(nameof(databaseSettingsOptions));
        }

        public void Create(ToDoItemUpdate toDoItemUpdate)
        {
            using (var sqlConnection = new SqlConnection(_databaseSettings.ConnectionString))
            {
                sqlConnection.Execute("CreateToDoItemUpdate", new
                {
                    toDoItemUpdate.State,
                    toDoItemUpdate.Title
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Update(ToDoItemUpdate toDoItemUpdate)
        {
            using (var sqlConnection = new SqlConnection(_databaseSettings.ConnectionString))
            {
                sqlConnection.Execute("UpdateToDoItemUpdate", toDoItemUpdate, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
