using Domain.Transactions;
using Domain.Users;

using MediatR;

namespace Application.Categories.CreateCategory;
public sealed class CreateCategoryCommandHandler(IUserRepository userRepository, ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
	public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
	{
		if(await userRepository.GetByIdAsync(request.UserId) is null)
			throw new Exception();

		var category = new TransactionCategory(request.UserId, request.Name, request.TransactionType);

		await categoryRepository.AddAsync(category);

		return new CreateCategoryCommandResponse(category.Id);
	}
}