using System.Collections.Generic;
using System.Threading.Tasks;
using AvaPlate.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AvaPlate.Data;

public class UserRepository(SecurityContext securityContext)
{
    private readonly SecurityContext _database = securityContext;

    public async Task<List<User>> ListAsync()
    {
        return await _database.Users.ToListAsync();
    }
}