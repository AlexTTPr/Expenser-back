using Domain.Users;

using Mapster;

using MediatR;

namespace Application.Users.CreateUser;
internal sealed class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
	public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var user = request.Adapt<User>();
		await userRepository.AddAsync(user);

		return new CreateUserCommandResponse(user.Id);
	}
}