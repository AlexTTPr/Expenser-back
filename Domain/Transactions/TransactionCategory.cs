using Domain.Shared;

namespace Domain.Transactions;
public class TransactionCategory : BaseEntity<Guid>
{
	public Guid? UserId { get; init; }

	public string Name { get; init; }

	public TransactionType TransactionType { get; init; }
	//TODO: add corresponding image
}
