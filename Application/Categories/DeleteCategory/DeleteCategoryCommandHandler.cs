using Domain.Transactions;
using Domain.Users;

using MediatR;

namespace Application.Categories.DeleteCategory;
public sealed class DeleteCategoryCommandHandler(IUserRepository userRepository, ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
	public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
	{
		if(await userRepository.GetByIdAsync(request.UserId) is null)
			throw new ArgumentException();
		var category = await categoryRepository.GetByIdAsync(request.CategoryId);
		if(category is null || category.UserId is null || category.UserId != request.UserId)
			throw new ArgumentException();
		await categoryRepository.RemoveAsync(request.CategoryId);
	}
}