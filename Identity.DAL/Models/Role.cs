using System.ComponentModel.DataAnnotations;

namespace Identity.DAL.Models;

public class Role
{
    [Key]
    public int Id { get; set; } = default;

    [Required]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}