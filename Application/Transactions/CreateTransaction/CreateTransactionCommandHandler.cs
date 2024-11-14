using Domain.Transactions;
using Domain.Users;

using MediatR;

namespace Application.Transactions.CreateTransaction;
public class CreateTransactionCommandHandler(ITransactionRepository transactionRepository, ITagRepository tagRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
	: IRequestHandler<CreateTransactionCommand, CreateTransactionCommandResponse>
{
	public async Task<CreateTransactionCommandResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken = default)
	{
		//if(await userRepository.GetByIdAsync(request.CreatorId) is null)


		var tags = new List<Tag>();
		foreach(var tagId in request.TagsIds)
			tags.Add(await tagRepository.GetByIdAsync(tagId));

		var category = await categoryRepository.GetByIdAsync(request.CategoryId);
		var transaction = new Transaction(request.CreatorId, request.TransactionDate, request.Type, category, request.Money, tags);

		await transactionRepository.AddAsync(transaction);

		return new CreateTransactionCommandResponse(transaction.Id);
	}
}
