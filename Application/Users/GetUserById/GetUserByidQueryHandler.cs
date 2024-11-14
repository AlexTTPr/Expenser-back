using Domain.Users;

using Mapster;

using MediatR;

namespace Application.Users.GetUserById;
internal sealed class GetUserByidQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByidQuery, GetUserByidQueryResponse>
{
	public async Task<GetUserByidQueryResponse> Handle(GetUserByidQuery request, CancellationToken cancellationToken)
	{
		var user = await userRepository.GetByIdAsync(request.Id);

		return user.Adapt<GetUserByidQueryResponse>();
	}
}
