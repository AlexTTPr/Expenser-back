using Domain.Transactions;
using Domain.Users;

using MediatR;

namespace Application.Transactions.UpdateTransaction;
public sealed class UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, ITagRepository tagRepository, IUserRepository userRepository, ICategoryRepository categoryRepository) : IRequestHandler<UpdateTransactionCommand, UpdateTransactionCommandResponse>
{
	public async Task<UpdateTransactionCommandResponse> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		var tags = new List<Tag>();
		foreach(var tagId in request.TagsIds)
			tags.Add(await tagRepository.GetByIdAsync(tagId));

		var category = await categoryRepository.GetByIdAsync(request.CategoryId);

		var transaction = await transactionRepository.GetByIdAsync(request.TransactionId);

		if(transaction == null)
			throw new ArgumentNullException(nameof(transaction));

		transaction.TransactionDate = request.TransactionDate;
		transaction.Type = request.Type;
		transaction.Category = category;
		transaction.Money = request.Money;

		await transactionRepository.UpdateAsync(transaction);

		return new UpdateTransactionCommandResponse();
	}
}