using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;
using ItemsApi.Entities;
using ItemsApi.Repositories.Interfaces;
using System.Linq;

namespace ItemsApi.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly DatabaseSettings _databaseSettings;

        public ToDoItemRepository(IOptions<DatabaseSettings> databaseSettingsOptions)
        {
            _databaseSettings = databaseSettingsOptions?.Value ?? throw new ArgumentNullException(nameof(databaseSettingsOptions));
        }

        public IQueryable<ToDoItem> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_databaseSettings.ConnectionString))
            {
                return sqlConnection.Query<ToDoItem>("GetAllToDoItems", commandType: System.Data.CommandType.StoredProcedure)
                    // TODO: use an orm instead of prcoedure call
                    // The queryable interface will then actually be useful by narrowing data set on retrieval
                    .AsQueryable();
            }
        }
    }
}
