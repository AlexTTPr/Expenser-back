using Domain.Users;

using MediatR;

namespace Application.Users.GetUserById;
public sealed class GetUserByEmailAndPasswordQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailAndPasswordQuery, GetUserByEmailAndPasswordQueryResponse>
{
	public async Task<GetUserByEmailAndPasswordQueryResponse> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
	{
		var user = await userRepository.GetAsync(e => e.Email == request.Email && e.PasswordHash == request.Password);

		return new GetUserByEmailAndPasswordQueryResponse(user?.Id);
	}
}
