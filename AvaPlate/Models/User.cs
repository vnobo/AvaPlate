using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace AvaPlate.Models;

/// <summary>
/// 系统用户实体类
/// </summary>
[Table("sys_users")]
public class User
{
    /// <summary>
    /// 用户ID（主键）
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 用户唯一标识符
    /// </summary>
    [Required(ErrorMessage = "用户编码不能为空")]
    [Column(TypeName = "uuid")]
    [MaxLength(64, ErrorMessage = "编码长度不能超过64个字符")]
    public required Guid Code { get; set; }

    /// <summary>
    /// 用户名（登录账号）
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    [MaxLength(256, ErrorMessage = "用户名长度不能超过256个字符")]
    public required string Username { get; set; }

    /// <summary>
    /// 密码（加密存储）
    /// </summary>
    [Required(ErrorMessage = "密码不能为空")]
    [MaxLength(1024, ErrorMessage = "密码长度不能超过1024个字符")]
    public required string Password { get; set; }

    /// <summary>
    /// 用户状态（是否启用）
    /// </summary>
    public required bool Enable { get; set; } = true;

    /// <summary>
    /// 用户真实姓名
    /// </summary>
    [MaxLength(64, ErrorMessage = "姓名长度不能超过64个字符")]
    public string? Name { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    [MaxLength(64, ErrorMessage = "昵称长度不能超过64个字符")]
    public string? Nickname { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [MaxLength(256, ErrorMessage = "邮箱长度不能超过256个字符")]
    public string? Email { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [Phone(ErrorMessage = "电话格式不正确")]
    [MaxLength(20, ErrorMessage = "电话长度不能超过20个字符")]
    public string? Phone { get; set; }

    /// <summary>
    /// 用户头像URL
    /// </summary>
    [Url(ErrorMessage = "头像URL格式不正确")]
    [MaxLength(2048, ErrorMessage = "头像URL长度不能超过2048个字符")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 个人简介
    /// </summary>
    [MaxLength(2048, ErrorMessage = "个人简介长度不能超过2048个字符")]
    public string? Bio { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTime LoginTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 扩展信息（JSON格式）
    /// </summary>
    [Column(TypeName = "json")] 
    public JsonNode? Extend { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    [MaxLength(64, ErrorMessage = "创建人长度不能超过64个字符")]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// 更新人
    /// </summary>
    [MaxLength(64, ErrorMessage = "更新人长度不能超过64个字符")]
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
