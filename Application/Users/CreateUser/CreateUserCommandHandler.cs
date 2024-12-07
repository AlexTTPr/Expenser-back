using Domain.Users;

using MediatR;

namespace Application.Users.CreateUser;
internal sealed class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
	public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User(request.Name, request.Email, request.Password);
		await userRepository.AddAsync(user);

		return new CreateUserCommandResponse(user.Id);
	}
}