using System.ComponentModel.DataAnnotations;

namespace CodeBlue.Data.Entities;

public class User
{
	public Guid Id { get; set; }

	[Required]
	public string Email { get; set; } = "";

	[Required]
	public string PasswordHash { get; set; } = "";

	[Required]
	public string Role { get; set; } = ""; // Office | Technician
}
