using Domain.Shared;

namespace Domain.Transactions;
public class Tag : BaseEntity<Guid>
{
	public string Name { get; init; }

	public Guid UserId { get; init; }
}
