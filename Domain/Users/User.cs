using Domain.Shared;

namespace Domain.Users;
public class User : BaseEntity<Guid>
{
	public string Name { get; init; }

	public string Email { get; init; }
	public string PasswordHash { get; init; }

	public User(string name, string email, string passwordHash) : base(Guid.NewGuid())
	{
		Name = name;
		Email = email;
		PasswordHash = passwordHash;
	}
}
