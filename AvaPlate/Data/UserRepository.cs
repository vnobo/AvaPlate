using System.Collections.Generic;
using System.Threading.Tasks;
using AvaPlate.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AvaPlate.Data;

public class UserRepository(SecurityContext securityContext)
{
    private bool _hasBeenInitialized;

    private async Task Init()
    {
        if (_hasBeenInitialized)
            return;
        await securityContext.Database.EnsureDeletedAsync();
        await securityContext.Database.EnsureCreatedAsync();
        _hasBeenInitialized = true;
    }

    public async Task<List<User>> ListAsync()
    {
        await Init();
        return await securityContext.Users.ToListAsync();
    }
}