using Domain.Shared;

namespace Domain.Transactions;
public class TransactionCategory : BaseEntity<Guid>
{
	public Guid? UserId { get; init; }

	public string Name { get; init; }

	public TransactionType TransactionType { get; init; }
	//TODO: add corresponding image

	protected TransactionCategory() { } // NOTE: For EF

	public TransactionCategory(Guid? userId, string name, TransactionType transactionType)
	{
		UserId = userId;
		Name = name;
		TransactionType = transactionType;
	}
}
