using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;

namespace AvaPlate.Models;

[Table("sys_users")]
public class User
{
    public int Id { get; set; }
    public required Guid code { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required bool Enable { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public string? Bio { get; set; }
    public DateTime LoginTime { get; set; } = DateTime.Now;
    public JsonNode? Extend { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}