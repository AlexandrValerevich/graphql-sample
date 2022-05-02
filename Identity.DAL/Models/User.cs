using System.ComponentModel.DataAnnotations;

namespace Identity.DAL.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public ICollection<Role> Roles { get; set; }
}