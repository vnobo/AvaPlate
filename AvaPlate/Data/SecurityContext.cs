using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using AvaPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaPlate.Data;

public class SecurityContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public string DbPath { get; }
    
    public SecurityContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "security.db3");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}")
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .EnableServiceProviderCaching();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.Extend).HasColumnType("json")
            .HasConversion(v => v!.ToJsonString(Constants.JsonSerializerOptions),
                v => JsonSerializer.Deserialize<JsonNode>(v, Constants.JsonSerializerOptions));
    }

}