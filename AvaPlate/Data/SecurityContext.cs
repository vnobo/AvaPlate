using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using AvaPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaPlate.Data;

public class SecurityContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!Directory.Exists(Constants.AppDirectory))
        {
            Directory.CreateDirectory(Constants.AppDirectory);
        }
        options.UseSqlite(Constants.DatabasePath)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .EnableServiceProviderCaching();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.Extend).HasColumnType("json")
            .HasConversion(v => v!.ToJsonString(Constants.JsonSerializerOptions),
                v => JsonSerializer.Deserialize<JsonNode>(v, Constants.JsonSerializerOptions));
    }
}