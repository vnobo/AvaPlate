using System.Collections.Generic;
using System.Threading.Tasks;
using AvaPlate.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AvaPlate.Data;

public class UserRepository(ILogger<UserRepository> logger)
{
    private readonly ILogger _logger = logger;
    private SecurityContext database;

    private void Init()
    {
        if (database is not null)
            return;
        // Get an absolute path to the database file
        database = new SecurityContext();
    }

    public async Task<List<User>> ListAsync()
    {
        Init();

        return await database.Users.ToListAsync();
    }
}