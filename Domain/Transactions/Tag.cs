using Domain.Shared;

namespace Domain.Transactions;
public class Tag : BaseEntity<Guid>
{
	public string Name { get; init; }

	public Guid UserId { get; init; }

	protected Tag() { } //NOTE: For EF

	public Tag(string name, Guid userId) : base(Guid.NewGuid())
	{
		Name = name;
		UserId = userId;
	}
}
