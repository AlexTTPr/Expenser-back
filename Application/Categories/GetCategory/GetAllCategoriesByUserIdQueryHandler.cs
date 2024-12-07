using Domain.Transactions;
using Domain.Users;

using MediatR;

namespace Application.Categories.GetCategory;
public sealed class GetAllCategoriesByUserIdQueryHandler(IUserRepository userRepository, ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesByUserIdQuery, GetAllCategoriesByUserIdQueryResponse>
{
	public async Task<GetAllCategoriesByUserIdQueryResponse> Handle(GetAllCategoriesByUserIdQuery request, CancellationToken cancellationToken)
	{
		if(await userRepository.GetByIdAsync(request.UserId) is null)
			throw new ArgumentException();

		var categories = await categoryRepository.GetManyAsync((e) => e.UserId == null || e.UserId == request.UserId, false);

		return new GetAllCategoriesByUserIdQueryResponse(categories);
	}
}
