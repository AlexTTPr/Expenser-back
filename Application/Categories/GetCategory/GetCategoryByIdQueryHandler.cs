using Domain.Transactions;
using Domain.Users;

using Mapster;

using MediatR;

namespace Application.Categories.GetCategory;
public sealed class GetCategoryByIdQueryHandler(IUserRepository userRepository, ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponse>
{
	public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
	{
		if(await userRepository.GetByIdAsync(request.UserId) is null)
			throw new ArgumentException();

		var category = await categoryRepository.GetByIdAsync(request.CategoryId);

		if(category is null || category.UserId is not null && category.UserId == request.UserId)
			throw new ArgumentException();

		return category.Adapt<GetCategoryByIdQueryResponse>();
	}
}
